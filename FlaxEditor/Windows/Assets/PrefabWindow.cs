// Copyright (c) 2012-2018 Wojciech Figat. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using FlaxEditor.Content;
using FlaxEditor.CustomEditors;
using FlaxEditor.Gizmo;
using FlaxEditor.GUI;
using FlaxEditor.SceneGraph;
using FlaxEditor.SceneGraph.GUI;
using FlaxEditor.Viewport;
using FlaxEngine;
using FlaxEngine.GUI;

namespace FlaxEditor.Windows.Assets
{
    /// <summary>
    /// Prefab window allows to view and edit <see cref="Prefab"/> asset.
    /// </summary>
    /// <seealso cref="Prefab" />
    /// <seealso cref="FlaxEditor.Windows.Assets.AssetEditorWindow" />
    public sealed class PrefabWindow : AssetEditorWindowBase<Prefab>
    {
        /// <summary>
        /// The prefab hierarchy tree control.
        /// </summary>
        /// <seealso cref="FlaxEditor.GUI.Tree" />
        public class PrefabTree : Tree
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="PrefabTree"/> class.
            /// </summary>
            public PrefabTree()
            : base(true)
            {
            }
        }

        private readonly SplitPanel _split1;
        private readonly SplitPanel _split2;
        private readonly PrefabTree _tree;
        private readonly PrefabWindowViewport _viewport;
        private readonly CustomEditorPresenter _propertiesEditor;

        private readonly ToolStripButton _saveButton;
        private readonly ToolStripButton _toolStripUndo;
        private readonly ToolStripButton _toolStripRedo;
        private readonly ToolStripButton _toolStripTranslate;
        private readonly ToolStripButton _toolStripRotate;
        private readonly ToolStripButton _toolStripScale;

        private Undo _undo;
        private bool _focusCamera;
        private bool _isUpdatingSelection;

        /// <summary>
        /// Gets the prefab hierarchy tree control.
        /// </summary>
        public PrefabTree Tree => _tree;

        /// <summary>
        /// Gets the viewport.
        /// </summary>
        public PrefabWindowViewport Viewport => _viewport;

        /// <summary>
        /// Gets the undo system used by this window for changes tracking.
        /// </summary>
        public Undo Undo => _undo;

        /// <summary>
        /// The current selection (readonly).
        /// </summary>
        public readonly List<SceneGraphNode> Selection = new List<SceneGraphNode>();

        /// <summary>
        /// Occurs when selection gets changed.
        /// </summary>
        public event Action SelectionChanged;

        /// <summary>
        /// The local scene nodes graph used by the prefab editor.
        /// </summary>
        public readonly LocalSceneGraph Graph;

        /// <inheritdoc />
        public PrefabWindow(Editor editor, AssetItem item)
        : base(editor, item)
        {
            // Undo
            _undo = new Undo();
            _undo.UndoDone += UpdateToolstrip;
            _undo.RedoDone += UpdateToolstrip;
            _undo.ActionDone += UpdateToolstrip;

            // Split Panel 1
            _split1 = new SplitPanel(Orientation.Horizontal, ScrollBars.Both, ScrollBars.None)
            {
                DockStyle = DockStyle.Fill,
                SplitterValue = 0.2f,
                Parent = this
            };

            // Split Panel 2
            _split2 = new SplitPanel(Orientation.Horizontal, ScrollBars.None, ScrollBars.Vertical)
            {
                DockStyle = DockStyle.Fill,
                SplitterValue = 0.6f,
                Parent = _split1.Panel2
            };

            // Prefab structure tree
            Graph = new LocalSceneGraph();
            _tree = new PrefabTree();
            _tree.Margin = new Margin(0.0f, 0.0f, -14.0f, 0.0f); // Hide root node
            _tree.AddChild(Graph.Root.TreeNode);
            _tree.SelectedChanged += OnTreeSelectedChanged;
            //_tree.RightClick += Tree_OnRightClick;
            _tree.Parent = _split1.Panel1;

            // Prefab viewport
            _viewport = new PrefabWindowViewport(this)
            {
                Parent = _split2.Panel1
            };
            _viewport.TransformGizmo.OnModeChanged += UpdateToolstrip;

            // Prefab properties editor
            _propertiesEditor = new CustomEditorPresenter(_undo, "Loading...");
            _propertiesEditor.Panel.Parent = _split2.Panel2;
            _propertiesEditor.Modified += MarkAsEdited;

            // Toolstrip
            _saveButton = (ToolStripButton)_toolstrip.AddButton(Editor.UI.GetIcon("Save32"), Save).LinkTooltip("Save");
            _toolstrip.AddSeparator();
            _toolStripUndo = (ToolStripButton)_toolstrip.AddButton(Editor.UI.GetIcon("Undo32"), _undo.PerformUndo).LinkTooltip("Undo (Ctrl+Z)");
            _toolStripRedo = (ToolStripButton)_toolstrip.AddButton(Editor.UI.GetIcon("Redo32"), _undo.PerformRedo).LinkTooltip("Redo (Ctrl+Y)");
            _toolstrip.AddSeparator();
            _toolStripTranslate = (ToolStripButton)_toolstrip.AddButton(Editor.UI.GetIcon("Translate32"), () => _viewport.TransformGizmo.ActiveMode = TransformGizmo.Mode.Translate).LinkTooltip("Change Gizmo tool mode to Translate (1)");
            _toolStripRotate = (ToolStripButton)_toolstrip.AddButton(Editor.UI.GetIcon("Rotate32"), () => _viewport.TransformGizmo.ActiveMode = TransformGizmo.Mode.Rotate).LinkTooltip("Change Gizmo tool mode to Rotate (2)");
            _toolStripScale = (ToolStripButton)_toolstrip.AddButton(Editor.UI.GetIcon("Scale32"), () => _viewport.TransformGizmo.ActiveMode = TransformGizmo.Mode.Scale).LinkTooltip("Change Gizmo tool mode to Scale (3)");

            Editor.Prefabs.PrefabApplied += OnPrefabApplied;
        }

        private void OnTreeSelectedChanged(List<TreeNode> before, List<TreeNode> after)
        {
            // Check if lock events
            if (_isUpdatingSelection)
                return;

            if (after.Count > 0)
            {
                // Get actors from nodes
                var actors = new List<SceneGraphNode>(after.Count);
                for (int i = 0; i < after.Count; i++)
                {
                    if (after[i] is ActorTreeNode node && node.Actor)
                        actors.Add(node.ActorNode);
                }

                // Select
                Select(actors);
            }
            else
            {
                // Deselect
                Deselect();
            }
        }

        private void OnPrefabApplied(Prefab prefab, Actor instance)
        {
            if (prefab == Asset)
            {
                ClearEditedFlag();

                _item.RefreshThumbnail();
            }
        }

        /// <summary>
        /// Called when selection gets changed.
        /// </summary>
        /// <param name="before">The selection before the change.</param>
        public void OnSelectionChanged(SceneGraphNode[] before)
        {
            Undo.AddAction(new SelectionChangeAction(before, Selection.ToArray(), OnSelectionUndo));

            OnSelectionChanges();
        }

        private void OnSelectionUndo(SceneGraphNode[] toSelect)
        {
            Selection.Clear();
            Selection.AddRange(toSelect);

            OnSelectionChanges();
        }

        private void OnSelectionChanges()
        {
            _isUpdatingSelection = true;

            // Update tree
            var selection = Selection;
            if (selection.Count == 0)
            {
                _tree.Deselect();
            }
            else
            {
                // Find nodes to select
                var nodes = new List<TreeNode>(selection.Count);
                for (int i = 0; i < selection.Count; i++)
                {
                    if (selection[i] is ActorNode node)
                    {
                        nodes.Add(node.TreeNode);
                    }
                }

                // Select nodes
                _tree.Select(nodes);

                // For single node selected scroll view so user can see it
                if (nodes.Count == 1)
                {
                    ScrollViewTo(nodes[0]);
                }
            }

            // Update properties editor
            var objects = Selection.ConvertAll(x => x.EditableObject).Distinct();
            _propertiesEditor.Select(objects);

            _isUpdatingSelection = false;

            // Send event
            SelectionChanged?.Invoke();
        }

        /// <inheritdoc />
        public override void Save()
        {
            // Check if don't need to push any new changes to the orginal asset
            if (!IsEdited)
                return;

            // Simply update changes
            Editor.Prefabs.ApplyAll(_viewport.Instance);
        }

        /// <inheritdoc />
        protected override void UpdateToolstrip()
        {
            var undoRedo = _undo;
            var gizmo = _viewport.TransformGizmo;

            _saveButton.Enabled = IsEdited;
            _toolStripUndo.Enabled = undoRedo.CanUndo;
            _toolStripRedo.Enabled = undoRedo.CanRedo;
            //
            var gizmoMode = gizmo.ActiveMode;
            _toolStripTranslate.Checked = gizmoMode == TransformGizmo.Mode.Translate;
            _toolStripRotate.Checked = gizmoMode == TransformGizmo.Mode.Rotate;
            _toolStripScale.Checked = gizmoMode == TransformGizmo.Mode.Scale;

            base.UpdateToolstrip();
        }

        /// <inheritdoc />
        protected override void OnAssetLoaded()
        {
            _viewport.Prefab = _asset;
            Graph.MainActor = _viewport.Instance;
            _focusCamera = true;
            _undo.Clear();
            Selection.Clear();
            Select(Graph.Main);
            Graph.Root.TreeNode.ExpandAll(true);

            base.OnAssetLoaded();
        }

        /// <inheritdoc />
        protected override void UnlinkItem()
        {
            Deselect();
            Graph.Dispose();
            _viewport.Prefab = null;
            _undo?.Clear();
            
            base.UnlinkItem();
        }

        /// <inheritdoc />
        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            if (_focusCamera && _viewport.Task.FrameCount > 1)
            {
                _focusCamera = false;

                // Auto fit
                BoundingSphere bounds;
                Editor.GetActorEditorSphere(_viewport.Instance, out bounds);
                _viewport.ViewPosition = bounds.Center - _viewport.ViewDirection * (bounds.Radius * 1.2f);
            }
        }

        /// <inheritdoc />
        public override bool OnKeyDown(Keys key)
        {
            // Base
            bool result = base.OnKeyDown(key);
            if (!result)
            {
                if (Root.GetKey(Keys.Control))
                {
                    switch (key)
                    {
                    case Keys.Z:
                        _undo.PerformUndo();
                        Focus();
                        return true;
                    case Keys.Y:
                        _undo.PerformRedo();
                        Focus();
                        return true;
                    case Keys.X:
                        Cut();
                        break;
                    case Keys.C:
                        Copy();
                        break;
                    case Keys.V:
                        Paste();
                        break;
                    case Keys.D:
                        Duplicate();
                        break;
                    }
                }
                else
                {
                    switch (key)
                    {
                    case Keys.Delete:
                        Delete();
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Selects the specified nodes collection.
        /// </summary>
        /// <param name="nodes">The nodec.</param>
        public void Select(List<SceneGraphNode> nodes)
        {
            if (nodes == null || nodes.Count == 0)
            {
                Deselect();
                return;
            }
            if (Utils.ArraysEqual(Selection, nodes))
                return;

            var before = Selection.ToArray();
            Selection.Clear();
            Selection.AddRange(nodes);
            OnSelectionChanged(before);
        }

        /// <summary>
        /// Selects the specified node.
        /// </summary>
        /// <param name="node">The node.</param>
        public void Select(SceneGraphNode node)
        {
            if (node == null)
            {
                Deselect();
                return;
            }
            if (Selection.Count == 1 && Selection[0] == node)
                return;

            var before = Selection.ToArray();
            Selection.Clear();
            Selection.Add(node);
            OnSelectionChanged(before);
        }

        /// <summary>
        /// Clears the selection.
        /// </summary>
        public void Deselect()
        {
            if (Selection.Count == 0)
                return;

            var before = Selection.ToArray();
            Selection.Clear();
            OnSelectionChanged(before);
        }

        /// <summary>
        /// Cuts selected objects.
        /// </summary>
        public void Cut()
        {
            throw new NotImplementedException("TODO: Cut");
        }

        /// <summary>
        /// Copies selected objects to system clipboard.
        /// </summary>
        public void Copy()
        {
            throw new NotImplementedException("TODO: Copy");
        }

        /// <summary>
        /// Pastes objects from the system clipboard.
        /// </summary>
        public void Paste()
        {
            throw new NotImplementedException("TODO: Paste");
        }

        /// <summary>
        /// Duplicates selected objects.
        /// </summary>
        public void Duplicate()
        {
            throw new NotImplementedException("TODO: Duplicate");
        }

        /// <summary>
        /// Deletes selected objects.
        /// </summary>
        public void Delete()
        {
            throw new NotImplementedException("TODO: Delete");
        }

        /// <inheritdoc />
        public override bool UseLayoutData => true;

        /// <inheritdoc />
        public override void OnLayoutSerialize(XmlWriter writer)
        {
            writer.WriteAttributeString("Split1", _split1.SplitterValue.ToString());
            writer.WriteAttributeString("Split2", _split2.SplitterValue.ToString());
        }

        /// <inheritdoc />
        public override void OnLayoutDeserialize(XmlElement node)
        {
            float value1;

            if (float.TryParse(node.GetAttribute("Split1"), out value1))
                _split1.SplitterValue = value1;
            if (float.TryParse(node.GetAttribute("Split2"), out value1))
                _split2.SplitterValue = value1;
        }

        /// <inheritdoc />
        public override void OnLayoutDeserialize()
        {
            _split1.SplitterValue = 0.2f;
            _split2.SplitterValue = 0.6f;
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            if (IsDisposing)
                return;

            _undo.Dispose();
            _undo = null;

            base.Dispose();
        }
    }
}
