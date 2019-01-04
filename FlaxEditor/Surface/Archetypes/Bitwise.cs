// Copyright (c) 2012-2018 Wojciech Figat. All rights reserved.

using FlaxEngine;

namespace FlaxEditor.Surface.Archetypes
{
    /// <summary>
    /// Contains archetypes for nodes from the Bitwise group.
    /// </summary>
    public static class Bitwise
    {
        private static NodeArchetype Op1(ushort id, string title, string desc, string[] altTitles = null)
        {
            return new NodeArchetype
            {
                TypeID = id,
                Title = title,
                Description = desc,
                AlternativeTitles = altTitles,
                Flags = NodeFlags.AnimGraphOnly,
                Size = new Vector2(140, 20),
                Elements = new[]
                {
                    NodeElementArchetype.Factory.Input(0, "A", true, ConnectionType.Integer, 0),
                    NodeElementArchetype.Factory.Output(0, "Result", ConnectionType.Integer, 1)
                }
            };
        }

        private static NodeArchetype Op2(ushort id, string title, string desc, string[] altTitles = null)
        {
            return new NodeArchetype
            {
                TypeID = id,
                Title = title,
                Description = desc,
                AlternativeTitles = altTitles,
                Flags = NodeFlags.AnimGraphOnly,
                Size = new Vector2(140, 40),
                DefaultValues = new object[]
                {
                    0,
                    0,
                },
                Elements = new[]
                {
                    NodeElementArchetype.Factory.Input(0, "A", true, ConnectionType.Integer, 0, 0),
                    NodeElementArchetype.Factory.Input(1, "B", true, ConnectionType.Integer, 1, 1),
                    NodeElementArchetype.Factory.Output(0, "Result", ConnectionType.Integer, 2)
                }
            };
        }

        /// <summary>
        /// The nodes for that group.
        /// </summary>
        public static NodeArchetype[] Nodes =
        {
            Op1(1, "Bitwise NOT", "Negates the value using bitwise operation", new[] { "!", "~" }),
            Op2(2, "Bitwise AND", "Performs a bitwise conjunction on two values", new[] { "&" }),
            Op2(3, "Bitwise OR", "", new[] { "|" }),
            Op2(4, "Bitwise XOR", ""),
        };
    }
}
