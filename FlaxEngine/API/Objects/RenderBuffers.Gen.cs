// Copyright (c) 2012-2018 Wojciech Figat. All rights reserved.
// This code was generated by a tool. Changes to this file may cause
// incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Runtime.CompilerServices;

namespace FlaxEngine.Rendering
{
    /// <summary>
    /// Allows to perform custom rendering to texture.
    /// </summary>
    public sealed partial class RenderBuffers : Object
    {
        /// <summary>
        /// Creates new <see cref="RenderBuffers"/> object.
        /// </summary>
        private RenderBuffers() : base()
        {
        }

        /// <summary>
        /// Creates new instance of <see cref="RenderBuffers"/> object.
        /// </summary>
        /// <returns>Created object.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public static RenderBuffers New()
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_Create(typeof(RenderBuffers)) as RenderBuffers;
#endif
        }

        /// <summary>
        /// Gets buffer textures width (in pixels).
        /// </summary>
        [UnmanagedCall]
        public int Width
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetWidth(unmanagedPtr); }
#endif
        }

        /// <summary>
        /// Gets buffer textures height (in pixels).
        /// </summary>
        [UnmanagedCall]
        public int Height
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetHeight(unmanagedPtr); }
#endif
        }

        /// <summary>
        /// Gets buffer textures aspect ratio (width / height).
        /// </summary>
        [UnmanagedCall]
        public float AspectRatio
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetAspectRatio(unmanagedPtr); }
#endif
        }

        /// <summary>
        /// Gets or sets buffer textures size (in pixels).
        /// </summary>
        [UnmanagedCall]
        public Vector2 Size
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { Vector2 resultAsRef; Internal_GetSize(unmanagedPtr, out resultAsRef); return resultAsRef; }
            set { Internal_SetSize(unmanagedPtr, ref value); }
#endif
        }

        /// <summary>
        /// Gets the depth buffer render target allocated within this render buffers collection (read only).
        /// </summary>
        [UnmanagedCall]
        public RenderTarget DepthBuffer
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetDepthBuffer(unmanagedPtr); }
#endif
        }

        /// <summary>
        /// Gets the motion vectors render target allocated within this render buffers collection (read only).
        /// </summary>
        /// <remarks>
        /// Texture ca be null or not initialized if motion blur is disabled or not yet rendered.
        /// </remarks>
        [UnmanagedCall]
        public RenderTarget MotionVectors
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetMotionVectors(unmanagedPtr); }
#endif
        }

        /// <summary>
        /// Initializes render buffers.
        /// </summary>
        /// <param name="width">The surface width in pixels.</param>
        /// <param name="height">The surface height in pixels.</param>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public void Init(int width, int height)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            Internal_Init(unmanagedPtr, width, height);
#endif
        }

        /// <summary>
        /// Disposes render buffers data.
        /// </summary>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public void Dispose()
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            Internal_Dispose(unmanagedPtr);
#endif
        }

        #region Internal Calls

#if !UNIT_TEST_COMPILANT
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int Internal_GetWidth(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int Internal_GetHeight(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float Internal_GetAspectRatio(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_GetSize(IntPtr obj, out Vector2 resultAsRef);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetSize(IntPtr obj, ref Vector2 val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern RenderTarget Internal_GetDepthBuffer(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern RenderTarget Internal_GetMotionVectors(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_Init(IntPtr obj, int width, int height);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_Dispose(IntPtr obj);
#endif

        #endregion
    }
}
