// Copyright (c) 2012-2018 Wojciech Figat. All rights reserved.
// This code was generated by a tool. Changes to this file may cause
// incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Runtime.CompilerServices;

namespace FlaxEngine
{
    /// <summary>
    /// Performs an animation and renders a skinned model.
    /// </summary>
    [Serializable]
    public sealed partial class AnimatedModel : Actor
    {
        /// <summary>
        /// Creates new <see cref="AnimatedModel"/> object.
        /// </summary>
        private AnimatedModel() : base()
        {
        }

        /// <summary>
        /// Creates new instance of <see cref="AnimatedModel"/> object.
        /// </summary>
        /// <returns>Created object.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public static AnimatedModel New()
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_Create(typeof(AnimatedModel)) as AnimatedModel;
#endif
        }

        /// <summary>
        /// Gets or sets a skinned model asset used for rendering.
        /// </summary>
        [UnmanagedCall]
        [EditorOrder(10), EditorDisplay("Skinned Model"), Tooltip("Skinned model asset to draw")]
        public SkinnedModel SkinnedModel
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetSkinnedModel(unmanagedPtr); }
            set { Internal_SetSkinnedModel(unmanagedPtr, Object.GetUnmanagedPtr(value)); }
#endif
        }

        /// <summary>
        /// Gets or sets the animation graph used for the skinned mesh skeleton bones evaluation.
        /// </summary>
        [UnmanagedCall]
        [EditorOrder(15), EditorDisplay("Skinned Model"), Tooltip("Animation graph used for the skinned mesh skeleton bones evaluation")]
        public AnimationGraph AnimationGraph
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetAnimationGraph(unmanagedPtr); }
            set { Internal_SetAnimationGraph(unmanagedPtr, Object.GetUnmanagedPtr(value)); }
#endif
        }

        /// <summary>
        /// If true, use per-bone motion blur on this skeletal model. It requires additional rendering, can be disabled to save performance.
        /// </summary>
        [UnmanagedCall]
        [EditorOrder(20), EditorDisplay("Skinned Model"), Tooltip("If true, use per-bone motion blur on this skeletal model. It requires additional rendering, can be disabled to save performance.")]
        public bool PerBoneMotionBlur
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetPerBoneMotionBlur(unmanagedPtr); }
            set { Internal_SetPerBoneMotionBlur(unmanagedPtr, value); }
#endif
        }

        /// <summary>
        /// If true, animation speed will be affected by the global time scale parameter.
        /// </summary>
        [UnmanagedCall]
        [EditorOrder(30), EditorDisplay("Skinned Model"), Tooltip("If true, animation speed will be affected by the global time scale parameter.")]
        public bool UseTimeScale
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetUseTimeScale(unmanagedPtr); }
            set { Internal_SetUseTimeScale(unmanagedPtr, value); }
#endif
        }

        /// <summary>
        /// If true, the animation will be updated even when an actor cannot be seen by any camera. Otherwise, the animations themselves will also stop running when the actor is off - screen.
        /// </summary>
        [UnmanagedCall]
        [EditorOrder(40), EditorDisplay("Skinned Model"), Tooltip(" If true, the animation will be updated even when an actor cannot be seen by any camera. Otherwise, the animations themselves will also stop running when the actor is off-screen.")]
        public bool UpdateWhenOffscreen
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetUpdateWhenOffscreen(unmanagedPtr); }
            set { Internal_SetUpdateWhenOffscreen(unmanagedPtr, value); }
#endif
        }

        /// <summary>
        /// Gets or sets the animation update mode. Can be used to optimize the performance.
        /// </summary>
        [UnmanagedCall]
        [EditorOrder(50), EditorDisplay("Skinned Model"), Tooltip("The animation update mode. Can be used to optimize the performance.")]
        public AnimationUpdateMode UpdateMode
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetUpdateMode(unmanagedPtr); }
            set { Internal_SetUpdateMode(unmanagedPtr, value); }
#endif
        }

        /// <summary>
        /// Gets or sets the master scale parameter for the actor bounding box. Helps reducing mesh flickering effect on screen edges.
        /// </summary>
        [UnmanagedCall]
        [EditorOrder(60), Limit(0), EditorDisplay("Skinned Model"), Tooltip("The master scale parameter for the actor bounding box. Helps reducing mesh flickering effect on screen edges.")]
        public float BoundsScale
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetBoundsScale(unmanagedPtr); }
            set { Internal_SetBoundsScale(unmanagedPtr, value); }
#endif
        }

        /// <summary>
        /// Gets or sets the custom bounds (in actor local space). If set to empty bounds then source skinned model bind pose bounds will be used.
        /// </summary>
        [UnmanagedCall]
        [EditorOrder(70), EditorDisplay("Skinned Model"), Tooltip("The custom bounds (in actor local space).")]
        public BoundingBox CustomBounds
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { BoundingBox resultAsRef; Internal_GetCustomBounds(unmanagedPtr, out resultAsRef); return resultAsRef; }
            set { Internal_SetCustomBounds(unmanagedPtr, ref value); }
#endif
        }

        /// <summary>
        /// Gets or sets the shadows casting mode.
        /// </summary>
        [UnmanagedCall]
        [EditorOrder(80), EditorDisplay("Skinned Model"), Tooltip("The shadows casting mode.")]
        public ShadowsCastingMode ShadowsMode
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetShadowsMode(unmanagedPtr); }
            set { Internal_SetShadowsMode(unmanagedPtr, value); }
#endif
        }

        /// <summary>
        /// Gets or sets the animation root motion apply target. If not specified the animated model will apply it itself.
        /// </summary>
        [UnmanagedCall]
        [EditorOrder(100), EditorDisplay("Skinned Model"), Tooltip("The animation root motion apply target. If not specified the animated model will apply it itself.")]
        public Actor RootMotionTarget
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetRootMotionTarget(unmanagedPtr); }
            set { Internal_SetRootMotionTarget(unmanagedPtr, Object.GetUnmanagedPtr(value)); }
#endif
        }

        /// <summary>
        /// Performs the full animation update.
        /// </summary>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public void UpdateAnimation()
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            Internal_UpdateAnimation(unmanagedPtr);
#endif
        }

        /// <summary>
        /// Resets the animation state (clears the instance state data but preserves the instance parameters values).
        /// </summary>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public void ResetAnimation()
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            Internal_ResetAnimation(unmanagedPtr);
#endif
        }

        /// <summary>
        /// Gets material used to render mesh at given index (overriden by model instance buffer or model default).
        /// </summary>
        /// <param name="meshIndex">Mesh index</param>
        /// <returns>Material or null if not assigned.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public MaterialBase GetMaterial(int meshIndex)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_GetMaterial(unmanagedPtr, meshIndex);
#endif
        }

        #region Internal Calls

#if !UNIT_TEST_COMPILANT
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern SkinnedModel Internal_GetSkinnedModel(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetSkinnedModel(IntPtr obj, IntPtr val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern AnimationGraph Internal_GetAnimationGraph(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetAnimationGraph(IntPtr obj, IntPtr val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool Internal_GetPerBoneMotionBlur(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetPerBoneMotionBlur(IntPtr obj, bool val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool Internal_GetUseTimeScale(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetUseTimeScale(IntPtr obj, bool val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool Internal_GetUpdateWhenOffscreen(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetUpdateWhenOffscreen(IntPtr obj, bool val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern AnimationUpdateMode Internal_GetUpdateMode(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetUpdateMode(IntPtr obj, AnimationUpdateMode val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern float Internal_GetBoundsScale(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetBoundsScale(IntPtr obj, float val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_GetCustomBounds(IntPtr obj, out BoundingBox resultAsRef);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetCustomBounds(IntPtr obj, ref BoundingBox val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern ShadowsCastingMode Internal_GetShadowsMode(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetShadowsMode(IntPtr obj, ShadowsCastingMode val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern Actor Internal_GetRootMotionTarget(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetRootMotionTarget(IntPtr obj, IntPtr val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_UpdateAnimation(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_ResetAnimation(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern MaterialBase Internal_GetMaterial(IntPtr obj, int meshIndex);
#endif

        #endregion
    }
}
