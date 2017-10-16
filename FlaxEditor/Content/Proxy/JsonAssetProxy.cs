////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////

using System;
using FlaxEditor.Windows;
using FlaxEngine;

namespace FlaxEditor.Content
{
    /// <summary>
    /// Base class for all Json asset proxy objects used to manage <see cref="JsonAssetItem"/>.
    /// </summary>
    /// <seealso cref="FlaxEditor.Content.AssetProxy" />
    public abstract class JsonAssetBaseProxy : AssetProxy
    {
    }

    /// <summary>
    /// Json assets proxy.
    /// </summary>
    /// <seealso cref="FlaxEditor.Content.JsonAssetBaseProxy" />
    public abstract class JsonAssetProxy : JsonAssetBaseProxy
    {
        /// <summary>
        /// The json files extension.
        /// </summary>
        public static readonly string Extension = "json";

        /// <summary>
        /// Gets the name of the data type (full name with namespace and the class name).
        /// </summary>
        public abstract string DataTypeName { get; }

        /// <inheritdoc />
        public override string Name => "Json";

        /// <inheritdoc />
        public override ContentDomain Domain => ContentDomain.Document;

        /// <inheritdoc />
        public override string FileExtension => Extension;

        /// <inheritdoc />
        public override EditorWindow Open(Editor editor, ContentItem item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override bool IsProxyFor(ContentItem item)
        {
            return item is JsonAssetItem;
        }

        /// <inheritdoc />
        public override Color AccentColor => Color.FromRGB(0xd14f67);

        /// <inheritdoc />
        public override bool AcceptsAsset(string typeName, string path)
        {
            return typeName == DataTypeName && base.AcceptsAsset(typeName, path);
        }

        /// <inheritdoc />
        public override AssetItem ConstructItem(string path, string typeName, ref Guid id)
        {
            return new JsonAssetItem(path, id, DataTypeName);
        }
    }
}
