// Copyright (c) 2012-2018 Wojciech Figat. All rights reserved.

using System.Collections.Generic;
using System.IO;
using FlaxEditor.Content;
using FlaxEditor.GUI.Drag;
using FlaxEngine;
using FlaxEngine.GUI;

namespace FlaxEditor.Surface
{
    public partial class VisjectSurface
    {
        private readonly DragAssets<DragDropEventArgs> _dragAssets;
        private readonly DragSurfaceParameters<DragDropEventArgs> _dragParameters;

        /// <summary>
        /// The custom drag drop event arguments.
        /// </summary>
        /// <seealso cref="FlaxEditor.GUI.Drag.DragEventArgs" />
        public class DragDropEventArgs : DragEventArgs
        {
            /// <summary>
            /// The surface location.
            /// </summary>
            public Vector2 SurfaceLocation;
        }

        /// <summary>
        /// Drag and drop handlers.
        /// </summary>
        public readonly DragHandlers DragHandlers = new DragHandlers();

        /// <inheritdoc />
        public override DragDropEffect OnDragEnter(ref Vector2 location, DragData data)
        {
            var result = base.OnDragEnter(ref location, data);
            if (result != DragDropEffect.None)
                return result;

            var dragEffect = DragHandlers.OnDragEnter(data);
            if (dragEffect.HasValue)
                result = dragEffect.Value;

            return result;
        }

        /// <inheritdoc />
        public override DragDropEffect OnDragMove(ref Vector2 location, DragData data)
        {
            var result = base.OnDragMove(ref location, data);
            if (result != DragDropEffect.None)
                return result;

            var dragEffect = DragHandlers.Effect();
            if (dragEffect.HasValue)
                return dragEffect.Value;

            return DragDropEffect.None;
        }

        /// <inheritdoc />
        public override void OnDragLeave()
        {
            DragHandlers.OnDragLeave();

            base.OnDragLeave();
        }

        /// <inheritdoc />
        public override DragDropEffect OnDragDrop(ref Vector2 location, DragData data)
        {
            var result = base.OnDragDrop(ref location, data);
            if (result != DragDropEffect.None)
                return result;

            var args = new DragDropEventArgs
            {
                SurfaceLocation = _rootControl.PointFromParent(ref location)
            };

            // Drag assets
            if (_dragAssets.HasValidDrag)
            {
                result = _dragAssets.Effect;

                // Process items
                HandleDragDropAssets(_dragAssets.Objects, args);
            }
            // Drag parameters
            else if (_dragParameters.HasValidDrag)
            {
                result = _dragParameters.Effect;

                // Process items
                HandleDragDropParameters(_dragParameters.Objects, args);
            }

            DragHandlers.OnDragDrop(args);

            return result;
        }

        /// <summary>
        /// Validates the asset items drag operation.
        /// </summary>
        /// <param name="assetItem">The asset item.</param>
        /// <returns>True if can drag that item, otherwise false.</returns>
        protected virtual bool ValidateDragItem(AssetItem assetItem)
        {
            return false;
        }

        /// <summary>
        /// Validates the parameter drag operation.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <returns>Tre if can drag that parameter, otherwise false.</returns>
        protected virtual bool ValidateDragParameter(string parameterName)
        {
            return GetParameter(parameterName) != null;
        }

        /// <summary>
        /// Handles the drag drop assets action.
        /// </summary>
        /// <param name="objects">The objects.</param>
        /// <param name="args">The drag drop arguments data.</param>
        protected virtual void HandleDragDropAssets(List<AssetItem> objects, DragDropEventArgs args)
        {
        }

        /// <summary>
        /// Handles the drag drop surface parameters action.
        /// </summary>
        /// <param name="objects">The objects.</param>
        /// <param name="args">The drag drop arguments data.</param>
        protected virtual void HandleDragDropParameters(List<string> objects, DragDropEventArgs args)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                var parameter = GetParameter(objects[i]);
                if (parameter == null)
                    throw new InvalidDataException();

                var node = Context.SpawnNode(6, 1, args.SurfaceLocation, new object[]
                {
                    parameter.ID
                });

                args.SurfaceLocation.X += node.Width + 10;
            }
        }
    }
}
