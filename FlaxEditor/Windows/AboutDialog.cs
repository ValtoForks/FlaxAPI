//#define USE_AUTODESK_FBX_SDK
// Copyright (c) 2012-2018 Wojciech Figat. All rights reserved.

using System.Collections.Generic;
using FlaxEditor.GUI.Dialogs;
using FlaxEngine;
using FlaxEngine.GUI;

namespace FlaxEditor.Windows
{
    /// <summary>
    ///     About this product dialog window.
    /// </summary>
    /// <seealso cref="FlaxEditor.GUI.Dialogs.Dialog" />
    internal sealed class AboutDialog : Dialog
    {
        /// <inheritdoc />
        public AboutDialog()
        : base("About Flax")
        {
            Size = new Vector2(400, 260);

            Control header = CreateHeader();
            Control authorsLabel = CreateAuthorsLabels(header);
            CreateFooter(authorsLabel);
        }

        /// <summary>
        ///     Create header with Flax engine icon and version number
        /// </summary>
        /// <returns>Returns icon controller (most top left)</returns>
        private Control CreateHeader()
        {
            Image icon = new Image(4, 4, 80, 80)
            {
                Brush = new SpriteBrush(Editor.Instance.Icons.Logo128),
                Parent = this
            };
            var nameLabel = new Label(icon.Right + 10, icon.Top, 200, 34)
            {
                Text = "Flax Engine",
                Font = new FontReference(Style.Current.FontTitle),
                HorizontalAlignment = TextAlignment.Near,
                VerticalAlignment = TextAlignment.Center,
                Parent = this
            };
            new Label(nameLabel.Left, nameLabel.Bottom + 4, nameLabel.Width, 50)
            {
                Text = string.Format("Version: {0}\nCopyright (c) 2012-2018 Wojciech Figat.\nAll rights reserved.", Globals.Version),
                HorizontalAlignment = TextAlignment.Near,
                VerticalAlignment = TextAlignment.Near,
                Parent = this
            };
            return icon;
        }

        /// <summary>
        ///     Create footer label
        /// </summary>
        /// <param name="topParentControl">Top element that this footer should be put under</param>
        private void CreateFooter(Control topParentControl)
        {
            Panel thirdPartyPanel = GenerateThirdPartyLabels(topParentControl);
            new Label(4, thirdPartyPanel.Bottom, Width - 8, Height - thirdPartyPanel.Bottom)
            {
                HorizontalAlignment = TextAlignment.Far,
                Text = "Made with <3 in Poland",
                Parent = this
            };
        }

        /// <summary>
        ///     Authors labels generation and show
        /// </summary>
        /// <param name="topParentControl">Top element that this labels should be put under</param>
        /// <returns>Authors control</returns>
        private Control CreateAuthorsLabels(Control topParentControl)
        {
            var authors = new List<string>(new[]
            {
                "Wojciech Figat",
                "Tomasz Juszczak",
                "Damian Korczowski",
            });
            authors.Sort();
            var authorsLabel = new Label(4, topParentControl.Bottom + 20, Width - 8, 50)
            {
                Text = "People who made it:\n" + string.Join(", ", authors),
                HorizontalAlignment = TextAlignment.Near,
                VerticalAlignment = TextAlignment.Near,
                Parent = this
            };
            return authorsLabel;
        }

        /// <summary>
        ///     3rdParty software and other licenses labels
        /// </summary>
        /// <param name="authorsLabel"></param>
        /// <returns></returns>
        private Panel GenerateThirdPartyLabels(Control authorsLabel)
        {
            var thirdPartyPanel = new Panel(ScrollBars.Vertical)
            {
                Bounds = new Rectangle(0, authorsLabel.Bottom + 4, Width, Height - authorsLabel.Bottom - 24),
                Parent = this
            };
            var thirdPartyEntries = new[]
            {
                "Used third party software:",
                "",
                "Mono Project - www.mono-project.com",
                "FreeType Project - www.freetype.org",
                "Assimp - www.assimp.sourceforge.net",
                "DirectXMesh - Copyright (c) Microsoft Corporation. All rights reserved.",
                "DirectXTex - Copyright (c) Microsoft Corporation. All rights reserved.",
                "UVAtlas - Copyright (c) Microsoft Corporation. All rights reserved.",
                "LZ4 Library - Copyright (c) Yann Collet. All rights reserved.",
                "fmt - www.fmtlib.net",
                "minimp3 - www.github.com/lieff/minimp3",
                "Ogg and Vorbis - Xiph.org Foundation",
                "OpenAL Soft - www.github.com/kcat/openal-soft",
                "OpenFBX - www.github.com/nem0/OpenFBX",
                "pugixml - www.pugixml.org",
                "rapidjson - www.rapidjson.org",
#if USE_AUTODESK_FBX_SDK
				"Autodesk FBX - Copyright (c) Autodesk",
#endif
                "Editor icons - www.icons8.com, www.iconfinder.com",
                "",
#if USE_AUTODESK_FBX_SDK
				"This software contains Autodesk® FBX® code developed by Autodesk, Inc.",
				"Copyright 2017 Autodesk, Inc. All rights, reserved.",
				"Such code is provided “as is” and Autodesk, Inc. disclaims any and all",
				"warranties, whether express or implied, including without limitation",
				"the implied warranties of merchantability, fitness for a particular",
				"purpose or non - infringement of third party rights.In no event shall",
				"Autodesk, Inc.be liable for any direct, indirect, incidental, special,",
				"exemplary, or consequential damages(including, but not limited to," ,
				"procurement of substitute goods or services; loss of use, data, or",
				"profits; or business interruption) however caused and on any theory" ,
				"of liability, whether in contract, strict liability, or tort" ,
				"(including negligence or otherwise)",
				"arising in any way out of such code.",
#endif
            };
            float y = 0;
            float width = Width;
            for (var i = 0; i < thirdPartyEntries.Length; i++)
            {
                var entry = thirdPartyEntries[i];
                var entryLabel = new Label(0, y, width, 14)
                {
                    Text = entry,
                    HorizontalAlignment = TextAlignment.Near,
                    VerticalAlignment = TextAlignment.Center,
                    Parent = thirdPartyPanel
                };
                y += entryLabel.Height + 2;
            }

            return thirdPartyPanel;
        }
    }
}
