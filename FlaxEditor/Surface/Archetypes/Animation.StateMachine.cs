// Copyright (c) 2012-2018 Wojciech Figat. All rights reserved.

using System;
using System.Collections.Generic;
using FlaxEditor.GUI;
using FlaxEngine;
using FlaxEngine.GUI;

namespace FlaxEditor.Surface.Archetypes
{
    public static partial class Animation
    {
        /// <summary>
        /// Customized <see cref="SurfaceNode" /> for the state machine output node.
        /// </summary>
        /// <seealso cref="FlaxEditor.Surface.SurfaceNode" />
        /// <seealso cref="FlaxEditor.Surface.ISurfaceContext" />
        public class StateMachine : SurfaceNode, ISurfaceContext
        {
            private IntValueBox _maxTransitionsPerUpdate;
            private CheckBox _reinitializeOnBecomingRelevant;
            private CheckBox _skipFirstUpdateTransition;

            /// <summary>
            /// Flag for editor UI updating. Used to skip value change events to prevent looping data flow.
            /// </summary>
            protected bool _isUpdatingUI;

            /// <summary>
            /// Gets or sets the node title text.
            /// </summary>
            public string StateMachineTitle
            {
                get => (string)Values[0];
                set
                {
                    if (!string.Equals(value, (string)Values[0], StringComparison.Ordinal))
                    {
                        SetValue(0, value);
                    }
                }
            }

            /// <summary>
            /// Gets or sets the maximum amount of active transitions per update.
            /// </summary>
            public int MaxTransitionsPerUpdate
            {
                get => (int)Values[2];
                set => SetValue(2, value);
            }

            /// <summary>
            /// Gets or sets a value indicating whether reinitialize state machine on becoming relevant (used for blending, etc.).
            /// </summary>
            public bool ReinitializeOnBecomingRelevant
            {
                get => (bool)Values[3];
                set => SetValue(3, value);
            }

            /// <summary>
            /// Gets or sets a value indicating whether skip any triggered transitions durig first animation state machine update.
            /// </summary>
            public bool SkipFirstUpdateTransition
            {
                get => (bool)Values[4];
                set => SetValue(4, value);
            }

            /// <inheritdoc />
            public StateMachine(uint id, VisjectSurface surface, NodeArchetype nodeArch, GroupArchetype groupArch)
            : base(id, surface, nodeArch, groupArch)
            {
                var marginX = FlaxEditor.Surface.Constants.NodeMarginX;
                var uiStartPosY = FlaxEditor.Surface.Constants.NodeMarginY + FlaxEditor.Surface.Constants.NodeHeaderSize;

                var renameButton = new Button(marginX, uiStartPosY, 120, 20);
                renameButton.Text = "Rename";
                renameButton.Parent = this;
                renameButton.Clicked += StartRenaming;

                var editButton = new Button(renameButton.Right + 4, renameButton.Y, 120, 20);
                editButton.Text = "Edit";
                editButton.Parent = this;
                editButton.Clicked += Edit;

                var maxTransitionsPerUpdateLabel = new Label(marginX, renameButton.Bottom + 4, 153, TextBox.DefaultHeight);
                maxTransitionsPerUpdateLabel.HorizontalAlignment = TextAlignment.Near;
                maxTransitionsPerUpdateLabel.Text = "Max Transitions Per Update:";
                maxTransitionsPerUpdateLabel.Parent = this;

                _maxTransitionsPerUpdate = new IntValueBox(3, maxTransitionsPerUpdateLabel.Right + 4, maxTransitionsPerUpdateLabel.Y, 40, 1, 32, 0.1f);
                _maxTransitionsPerUpdate.ValueChanged += () => MaxTransitionsPerUpdate = _maxTransitionsPerUpdate.Value;
                _maxTransitionsPerUpdate.Parent = this;

                var reinitializeOnBecomingRelevantLabel = new Label(marginX, maxTransitionsPerUpdateLabel.Bottom + 4, 185, TextBox.DefaultHeight);
                reinitializeOnBecomingRelevantLabel.HorizontalAlignment = TextAlignment.Near;
                reinitializeOnBecomingRelevantLabel.Text = "Reinitialize On Becoming Relevant:";
                reinitializeOnBecomingRelevantLabel.Parent = this;

                _reinitializeOnBecomingRelevant = new CheckBox(reinitializeOnBecomingRelevantLabel.Right + 4, reinitializeOnBecomingRelevantLabel.Y, true, TextBox.DefaultHeight);
                _reinitializeOnBecomingRelevant.StateChanged += (checkbox) => ReinitializeOnBecomingRelevant = checkbox.Checked;
                _reinitializeOnBecomingRelevant.Parent = this;

                var skipFirstUpdateTransitionLabel = new Label(marginX, reinitializeOnBecomingRelevantLabel.Bottom + 4, 152, TextBox.DefaultHeight);
                skipFirstUpdateTransitionLabel.HorizontalAlignment = TextAlignment.Near;
                skipFirstUpdateTransitionLabel.Text = "Skip First Update Transition:";
                skipFirstUpdateTransitionLabel.Parent = this;

                _skipFirstUpdateTransition = new CheckBox(skipFirstUpdateTransitionLabel.Right + 4, skipFirstUpdateTransitionLabel.Y, true, TextBox.DefaultHeight);
                _skipFirstUpdateTransition.StateChanged += (checkbox) => SkipFirstUpdateTransition = checkbox.Checked;
                _skipFirstUpdateTransition.Parent = this;
            }

            /// <summary>
            /// Opens the state machine editing UI.
            /// </summary>
            public void Edit()
            {
                Surface.OpenContext(this);
            }

            /// <summary>
            /// Starts the state machine renaming by showing a rename popup to the user.
            /// </summary>
            public void StartRenaming()
            {
                Surface.Select(this);
                var dialog = RenamePopup.Show(this, _headerRect, Title, false);
                dialog.Renamed += OnRenamed;
            }

            private void OnRenamed(RenamePopup renamePopup)
            {
                StateMachineTitle = renamePopup.Text;
            }

            /// <summary>
            /// Updates the editor UI.
            /// </summary>
            protected void UpdateUI()
            {
                if (_isUpdatingUI)
                    return;
                _isUpdatingUI = true;

                _maxTransitionsPerUpdate.Value = MaxTransitionsPerUpdate;
                _reinitializeOnBecomingRelevant.Checked = ReinitializeOnBecomingRelevant;
                _skipFirstUpdateTransition.Checked = SkipFirstUpdateTransition;
                Title = StateMachineTitle;

                _isUpdatingUI = false;
            }

            /// <inheritdoc />
            public override void OnSurfaceLoaded()
            {
                base.OnSurfaceLoaded();

                UpdateUI();
            }

            /// <inheritdoc />
            public override void SetValue(int index, object value)
            {
                base.SetValue(index, value);

                UpdateUI();
            }

            /// <inheritdoc />
            public override void Dispose()
            {
                if (IsDisposing)
                    return;

                // Remove from cache
                Surface.RemoveContext(this);

                base.Dispose();
            }

            /// <inheritdoc />
            public string SurfaceName => StateMachineTitle;

            /// <inheritdoc />
            public byte[] SurfaceData
            {
                get => (byte[])Values[1];
                set => SetValue(1, value);
            }

            /// <inheritdoc />
            public void OnContextCreated(VisjectSurfaceContext context)
            {
                context.Loaded += OnSurfaceLoaded;
            }

            private void OnSurfaceLoaded(VisjectSurfaceContext context)
            {
                // Ensure that loaded surface has entry node for state machine
                var entryNode = context.FindNode(9, 19);
                if (entryNode == null)
                {
                    entryNode = context.SpawnNode(9, 19, new Vector2(100.0f));
                }
            }
        }

        /// <summary>
        /// Customized <see cref="SurfaceNode" /> for the state machine entry node.
        /// </summary>
        /// <seealso cref="FlaxEditor.Surface.SurfaceNode" />
        public class StateMachineEntry : SurfaceNode
        {
            /// <inheritdoc />
            public StateMachineEntry(uint id, VisjectSurface surface, NodeArchetype nodeArch, GroupArchetype groupArch)
            : base(id, surface, nodeArch, groupArch)
            {
            }
        }

        /// <summary>
        /// Customized <see cref="SurfaceNode" /> for the state machine state node.
        /// </summary>
        /// <seealso cref="FlaxEditor.Surface.SurfaceNode" />
        public class StateMachineState : SurfaceNode
        {
            private bool _isSavingData;

            /// <summary>
            /// The transitions list from this state to the others.
            /// </summary>
            public readonly List<StateMachineTransition> Transitions = new List<StateMachineTransition>();

            /// <summary>
            /// Gets or sets the node title text.
            /// </summary>
            public string StateTitle
            {
                get => (string)Values[0];
                set
                {
                    if (!string.Equals(value, (string)Values[0], StringComparison.Ordinal))
                    {
                        SetValue(0, value);
                    }
                }
            }

            /// <inheritdoc />
            public StateMachineState(uint id, VisjectSurface surface, NodeArchetype nodeArch, GroupArchetype groupArch)
            : base(id, surface, nodeArch, groupArch)
            {
            }

            /// <inheritdoc />
            public override void SetValue(int index, object value)
            {
                base.SetValue(index, value);

                // Check for external state data changes (eg. via undo)
                if (!_isSavingData && index == 1)
                {
                    // Synchronize data
                    LoadData();
                }
                if (index == 0)
                {
                    // Update node title UI on change
                    Title = StateTitle;
                }
            }

            /// <inheritdoc />
            public override void OnSurfaceLoaded()
            {
                base.OnSurfaceLoaded();

                Title = StateTitle;
                LoadData();
            }

            /// <summary>
            /// Loads the state data from the node value (reads transitions and related information).
            /// </summary>
            public void LoadData()
            {
                ClearData();

                var data = (byte[])Values[1];
                if (data == null || data.Length == 0)
                {
                    // Empty state
                    return;
                }

                // TODO: load data from bytes and update UI
            }

            /// <summary>
            /// Saves the state data to the node value (writes transitions and related information).
            /// </summary>
            public void SaveData()
            {
                try
                {
                    _isSavingData = true;

                    // TODO: save data to bytes and set node value
                }
                finally
                {
                    _isSavingData = false;
                }
            }

            /// <summary>
            /// Clears the state data (removes transitions and related information).
            /// </summary>
            public void ClearData()
            {
                Transitions.Clear();
            }

            /// <inheritdoc />
            public override void Dispose()
            {
                if (IsDisposing)
                    return;

                ClearData();

                base.Dispose();
            }
        }

        /// <summary>
        /// State machine transition data container object.
        /// </summary>
        /// <seealso cref="StateMachineState"/>
        /// <seealso cref="ISurfaceContext"/>
        public class StateMachineTransition : ISurfaceContext
        {
            /// <summary>
            /// The transition start state.
            /// </summary>
            public StateMachineState SourceState;

            /// <summary>
            /// The transition end state.
            /// </summary>
            public StateMachineState DestinationState;

            /// <summary>
            /// If checked, the transition can be triggered, otherwise it will be ignored.
            /// </summary>
            public bool Enabled;

            /// <summary>
            /// If checked, animation graph will ignore other transitions from the source state and use only this transition.
            /// </summary>
            public bool Solo;

            /// <summary>
            /// If checked, animation graph will perform automatic transition based on the state animation pose (single shot animation play).
            /// </summary>
            public bool UseDefaultRule;

            /// <summary>
            /// The transition order (higher first).
            /// </summary>
            public int Order;

            /// <summary>
            /// The blend duration (in seconds).
            /// </summary>
            public float BlendDuration;

            /// <summary>
            /// The blend mode.
            /// </summary>
            public AlphaBlendMode BlendMode;

            /// <summary>
            /// The rule graph data.
            /// </summary>
            public byte[] RuleGraph;

            /// <inheritdoc />
            public string SurfaceName => string.Format("{0} to {1}", SourceState.StateTitle, DestinationState.StateTitle);

            /// <inheritdoc />
            public byte[] SurfaceData
            {
                get => RuleGraph;
                set
                {
                    RuleGraph = value;
                    SourceState.SaveData();
                }
            }

            /// <inheritdoc />
            public void OnContextCreated(VisjectSurfaceContext context)
            {
                context.Loaded += OnSurfaceLoaded;
            }

            private void OnSurfaceLoaded(VisjectSurfaceContext context)
            {
                // Ensure that loaded surface has rule output node
                var ruleOutputNode = context.FindNode(9, 22);
                if (ruleOutputNode == null)
                {
                    ruleOutputNode = context.SpawnNode(9, 22, new Vector2(100.0f));
                }
            }
        }
    }
}