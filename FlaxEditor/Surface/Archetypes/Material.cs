////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

using FlaxEditor.Surface.Elements;
using FlaxEditor.Windows.Assets;
using FlaxEngine;
using FlaxEngine.Rendering;

namespace FlaxEditor.Surface.Archetypes
{
    /// <summary>
    /// Contains archetypes for nodes from the Material group.
    /// </summary>
    public static class Material
    {
        /// <summary>
        /// Customized <see cref="SurfaceNode"/> for main material node.
        /// </summary>
        /// <seealso cref="FlaxEditor.Surface.SurfaceNode" />
        public class SurfaceNodeMaterial : SurfaceNode
        {
            /// <inheritdoc />
            public SurfaceNodeMaterial(uint id, VisjectSurface surface, NodeArchetype nodeArch, GroupArchetype groupArch)
                : base(id, surface, nodeArch, groupArch)
            {
            }

            /// <summary>
            /// Update material node boxes
            /// </summary>
            public void UpdateBoxes()
            {
                // Try get parent material window
                // Maybe too hacky :D
                var materialWindow = Surface.Owner as MaterialWindow;
                if (materialWindow == null || materialWindow.Item == null)
                    return;
                
                // Get material info
                MaterialInfo info;
                materialWindow.FillMaterialInfo(out info);
                bool isntLayered = !GetBox(0).HasAnyConnection;
                bool isSurface = info.Domain == MaterialDomain.Surface && isntLayered;
                bool isLitSurface = isSurface && info.BlendMode != MaterialBlendMode.Unlit;
                bool isTransparent = isSurface && info.BlendMode == MaterialBlendMode.Transparent;

                // Update boxes
                GetBox(1).Enabled = isLitSurface;// Color
                GetBox(2).Enabled = isntLayered;// Mask
                GetBox(3).Enabled = isSurface;// Emissive
                GetBox(4).Enabled = isLitSurface;// Metalness
                GetBox(5).Enabled = isLitSurface;// Specular
                GetBox(6).Enabled = isLitSurface;// Roughness
                GetBox(7).Enabled = isLitSurface;// Ambient Occlusion
                GetBox(8).Enabled = isLitSurface;// Normal
                GetBox(9).Enabled = isTransparent;// Opacity
                GetBox(10).Enabled = isTransparent;// Refraction
                GetBox(11).Enabled = false;// Position Offset
                // TODO: support world position offset
            }

            /// <inheritdoc />
            public override void OnLoaded()
            {
                base.OnLoaded();

                UpdateBoxes();
            }

            /// <inheritdoc />
            public override void OnSurfaceLoaded()
            {
                base.OnSurfaceLoaded();

                // Fix emissive box (it's a strange error)
                GetBox(3).CurrentType = ConnectionType.Vector3;
            }

            /// <inheritdoc />
            public override void ConnectionTick(Box box)
            {
                base.ConnectionTick(box);

                UpdateBoxes();
            }
        }

        /// <summary>
        /// The nodes for that group.
        /// </summary>
        public static NodeArchetype[] Nodes =
        {
            new NodeArchetype
            {
                TypeID = 1,
                Create = (id, surface, arch, groupArch) => new SurfaceNodeMaterial(id, surface, arch, groupArch),
                Title = "Material",
                Description = "Main material node",
                Flags = NodeFlags.MaterialOnly,
                Size = new Vector2(150, 240),
                Elements = new[]
                {
                    NodeElementArchetype.Factory.Input(0, "", true, ConnectionType.Impulse, 0),
                    NodeElementArchetype.Factory.Input(1, "Color", true, ConnectionType.Vector3, 1),
                    NodeElementArchetype.Factory.Input(2, "Mask", true, ConnectionType.Float, 2),
                    NodeElementArchetype.Factory.Input(3, "Emissive", true, ConnectionType.Vector3, 3),
                    NodeElementArchetype.Factory.Input(4, "Metalness", true, ConnectionType.Float, 4),
                    NodeElementArchetype.Factory.Input(5, "Specular", true, ConnectionType.Float, 5),
                    NodeElementArchetype.Factory.Input(6, "Roughness", true, ConnectionType.Float, 6),
                    NodeElementArchetype.Factory.Input(7, "Ambient Occlusion", true, ConnectionType.Float, 7),
                    NodeElementArchetype.Factory.Input(8, "Normal", true, ConnectionType.Vector3, 8),
                    NodeElementArchetype.Factory.Input(9, "Opacity", true, ConnectionType.Float, 9),
                    NodeElementArchetype.Factory.Input(10, "Refraction", true, ConnectionType.Float, 10),
                    NodeElementArchetype.Factory.Input(11, "Position Offset", true, ConnectionType.Vector3, 11),
                }
            },
            new NodeArchetype
            {
                TypeID = 2,
                Title = "World Position",
                Description = "Absolute world space position",
                Flags = NodeFlags.MaterialOnly,
                Size = new Vector2(150, 30),
                Elements = new[]
                {
                    NodeElementArchetype.Factory.Output(0, "XYZ", ConnectionType.Vector3, 0),
                }
            },
            new NodeArchetype
            {
                TypeID = 3,
                Title = "View",
                Description = "View properties",
                Flags = NodeFlags.MaterialOnly,
                Size = new Vector2(150, 40),
                Elements = new[]
                {
                    NodeElementArchetype.Factory.Output(0, "Position", ConnectionType.Vector3, 0),
                    NodeElementArchetype.Factory.Output(1, "Direction", ConnectionType.Vector3, 1),
                }
            },
            new NodeArchetype
            {
                TypeID = 4,
                Title = "Normal Vector",
                Description = "World space normal vector",
                Flags = NodeFlags.MaterialOnly,
                Size = new Vector2(150, 40),
                Elements = new[]
                {
                    NodeElementArchetype.Factory.Output(0, "Normal", ConnectionType.Vector3, 0),
                }
            },
            new NodeArchetype
            {
                TypeID = 5,
                Title = "Camera Vector",
                Description = "Calculates camera vector",
                Flags = NodeFlags.MaterialOnly,
                Size = new Vector2(150, 30),
                Elements = new[]
                {
                    NodeElementArchetype.Factory.Output(0, "Vector", ConnectionType.Vector3, 0),
                }
            },
        };
    }
}
