// Copyright (c) 2012-2018 Wojciech Figat. All rights reserved.
// This code was generated by a tool. Changes to this file may cause
// incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Runtime.CompilerServices;

namespace FlaxEngine
{
    /// <summary>
    /// A capsule-shaped primitive collider.
    /// </summary>
    /// <remarks>
    /// Capsules are cylinders with a half-sphere at each end.
    /// </remarks>
    [Serializable]
    public sealed partial class CapsuleCollider : Collider
    {
        /// <summary>
        /// Creates new <see cref="CapsuleCollider"/> object.
        /// </summary>
        private CapsuleCollider() : base()
        {
        }

        /// <summary>
        /// Creates new instance of <see cref="CapsuleCollider"/> object.
        /// </summary>
        /// <returns>Created object.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public static CapsuleCollider New()
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_Create(typeof(CapsuleCollider)) as CapsuleCollider;
#endif
        }

        /// <summary>
        /// Gets or sets the radius of the sphere, measured in the object's local space.
        /// </summary>
        /// <remarks>
        /// The sphere radius will be scaled by the actor's world scale.
        /// </remarks>
        [UnmanagedCall]
        [EditorOrder(100), EditorDisplay("Collider"), Tooltip("Radius of the sphere, measured in the object's local space")]
        public float Radius
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetRadius(unmanagedPtr); }
            set { Internal_SetRadius(unmanagedPtr, value); }
#endif
        }

        /// <summary>
        /// Gets or sets the height of the capsule, measured in the object's local space.
        /// </summary>
        /// <remarks>
        /// The capsule height will be scaled by the actor's world scale.
        /// </remarks>
        [UnmanagedCall]
        [EditorOrder(110), EditorDisplay("Collider"), Tooltip("Height of the capsule, measured in the object's local space")]
        public float Height
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetHeight(unmanagedPtr); }
            set { Internal_SetHeight(unmanagedPtr, value); }
#endif
        }

        #region Internal Calls

#if !UNIT_TEST_COMPILANT
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float Internal_GetRadius(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetRadius(IntPtr obj, float val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float Internal_GetHeight(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetHeight(IntPtr obj, float val);
#endif

        #endregion
    }
}
