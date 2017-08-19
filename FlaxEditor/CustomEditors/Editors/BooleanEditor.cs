////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

using FlaxEditor.CustomEditors.Elements;
using FlaxEngine;

namespace FlaxEditor.CustomEditors.Editors
{
    /// <summary>
    /// Default implementation of the inspector used to edit bool value type properties.
    /// </summary>
    [CustomEditor(typeof(bool)), DefaultEditor]
    public sealed class BooleanEditor : CustomEditor
    {
        private CheckBoxElement checkBox;

        /// <inheritdoc />
        public override bool IsInline => true;

        /// <inheritdoc />
        public override void Initialize(LayoutElementsContainer layout)
        {
            if (Values == null)
                return;

            checkBox = layout.Checkbox();
        }

        /// <inheritdoc />
        public override void Refresh()
        {
            if (HasDiffrentValues)
            {
                checkBox.CheckBox.Intermediate = true;
            }
            else
            {
                checkBox.CheckBox.Checked = (bool)Values[0];
            }
        }
    }
}