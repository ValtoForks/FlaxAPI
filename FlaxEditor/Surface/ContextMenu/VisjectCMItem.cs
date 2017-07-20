////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using FlaxEngine;
using FlaxEngine.GUI;

namespace FlaxEditor.Surface.ContextMenu
{
    /// <summary>
    /// Single item used for <see cref="VisjectCM"/>. Represents type of the <see cref="NodeArchetype"/> that can be spawned.
    /// </summary>
    /// <seealso cref="FlaxEngine.GUI.Control" />
    public sealed class VisjectCMItem : Control
    {
        private bool _isMouseDown;
        private List<Rectangle> _highlights;
        private VisjectCMGroup _group;
        private NodeArchetype _archetype;

        /// <summary>
        /// Gets the group archetype.
        /// </summary>
        /// <value>
        /// The group archetype.
        /// </value>
        public GroupArchetype GroupArchetype => _group.Archetype;

        /// <summary>
        /// Gets the node archetype.
        /// </summary>
        /// <value>
        /// The node archetype.
        /// </value>
        public NodeArchetype NodeArchetype => _archetype;

        /// <summary>
        /// Initializes a new instance of the <see cref="VisjectCMItem"/> class.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="archetype">The archetype.</param>
        public VisjectCMItem(VisjectCMGroup group, NodeArchetype archetype)
            : base(true, 0, 0, 120, 12)
        {
            _group = group;
            _archetype = archetype;
        }

        /// <summary>
        /// Updates the filter.
        /// </summary>
        /// <param name="filterText">The filter text.</param>
        public void UpdateFilter(string filterText)
        {
            if (string.IsNullOrWhiteSpace(filterText))
            {
                // Clear filter
                _highlights?.Clear();
                Visible = true;
            }
            else
            {
                // TODO: use regex or sth or sth or sth or sth else to apply on node text and check if it matches filter
                throw new NotImplementedException("visject nodes spawning sreaching");
            }
        }

        /// <inheritdoc />
        public override void Draw()
        {
            var style = Style.Current;
            var rect = new Rectangle(Vector2.Zero, Size);

            // Overlay
            if (IsMouseOver)
                Render2D.FillRectangle(rect, style.BackgroundHighlighted);

            // Draw all highlights
            if (_highlights != null)
            {
                var color = style.ProgressNormal.AlphaMultiplied(0.8f);
                for (int i = 0; i < _highlights.Count; i++)
                    Render2D.FillRectangle(_highlights[i], color, true);
            }

            // Draw name
            Render2D.DrawText(style.FontSmall, _archetype.Title, new Rectangle(2, 0, rect.Width - 4, rect.Height), Enabled ? style.Foreground : style.ForegroundDisabled, TextAlignment.Near, TextAlignment.Center);
        }

        /// <inheritdoc />
        public override bool OnMouseDown(Vector2 location, MouseButtons buttons)
        {
            if (buttons == MouseButtons.Left)
            {
                _isMouseDown = true;
            }

            return base.OnMouseDown(location, buttons);
        }

        /// <inheritdoc />
        public override bool OnMouseUp(Vector2 location, MouseButtons buttons)
        {
            if (buttons == MouseButtons.Left && _isMouseDown)
            {
                _isMouseDown = false;
                _group.ContextMenu.OnClickItem(this);
            }

            return base.OnMouseUp(location, buttons);
        }

        /// <inheritdoc />
        public override void OnMouseLeave()
        {
            _isMouseDown = false;

            base.OnMouseLeave();
        }
    }
}
