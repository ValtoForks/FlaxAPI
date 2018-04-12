////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2018 Flax Engine. All rights reserved.
////////////////////////////////////////////////////////////////////////////////////
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Runtime.CompilerServices;

namespace FlaxEngine
{
	/// <summary>
	/// Renders model on the screen.
	/// </summary>
	[Serializable]
	public sealed partial class ModelActor : Actor
	{
		/// <summary>
		/// Creates new <see cref="ModelActor"/> object.
		/// </summary>
		private ModelActor() : base()
		{
		}

		/// <summary>
		/// Creates new instance of <see cref="ModelActor"/> object.
		/// </summary>
		/// <returns>Created object.</returns>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public static ModelActor New() 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			return Internal_Create(typeof(ModelActor)) as ModelActor;
#endif
		}

		/// <summary>
		/// Gets or sets model scale in lightmap parameter
		/// </summary>
		[UnmanagedCall]
		[EditorOrder(10), EditorDisplay("Model", "Scale In Lightmap"), Tooltip("Model meshes master scale in lightmap"), Limit(0, 1000.0f, 0.1f)]
		public float ScaleInLightmap
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { return Internal_GetScaleInLightmap(unmanagedPtr); }
			set { Internal_SetScaleInLightmap(unmanagedPtr, value); }
#endif
		}

		/// <summary>
		/// Gets or sets model asset
		/// </summary>
		[UnmanagedCall]
		[EditorOrder(20), EditorDisplay("Model"), Tooltip("Model asset to draw")]
		public Model Model
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { return Internal_GetModel(unmanagedPtr); }
			set { Internal_SetModel(unmanagedPtr, Object.GetUnmanagedPtr(value)); }
#endif
		}

		/// <summary>
		/// Gets material used to render mesh at given index (overriden by model instance buffer or model default).
		/// </summary>
		/// <param name="meshIndex">Mesh index</param>
		/// <param name="lodIndex">Level of Detail index</param>
		/// <returns>Material or null if not assigned.</returns>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public MaterialBase GetMaterial(int meshIndex, int lodIndex = 0) 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			return Internal_GetMaterial(unmanagedPtr, meshIndex, lodIndex);
#endif
		}

		/// <summary>
		/// Resets all meshes lcoal transformations.
		/// </summary>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public void ResetMeshTransformations() 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			Internal_ResetMeshTransformations(unmanagedPtr);
#endif
		}

#region Internal Calls
#if !UNIT_TEST_COMPILANT
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern float Internal_GetScaleInLightmap(IntPtr obj);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_SetScaleInLightmap(IntPtr obj, float val);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern Model Internal_GetModel(IntPtr obj);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_SetModel(IntPtr obj, IntPtr val);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern MaterialBase Internal_GetMaterial(IntPtr obj, int meshIndex, int lodIndex);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_ResetMeshTransformations(IntPtr obj);
#endif
#endregion
	}
}

