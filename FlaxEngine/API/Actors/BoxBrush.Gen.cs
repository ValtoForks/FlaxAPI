////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2012-2017 Flax Engine. All rights reserved.
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
	/// Performs CSG box brush operation thats adds or removes geometry.
	/// </summary>
	[Serializable]
	public sealed partial class BoxBrush : Actor
	{
		/// <summary>
		/// Creates new <see cref="BoxBrush"/> object.
		/// </summary>
		private BoxBrush() : base()
		{
		}

		/// <summary>
		/// Creates new instance of <see cref="BoxBrush"/> object.
		/// </summary>
		/// <returns>Created object.</returns>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public static BoxBrush New() 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			return Internal_Create(typeof(BoxBrush)) as BoxBrush;
#endif
		}

		/// <summary>
		/// Gets or sets brush surfaces scale in lightmap parameter.
		/// </summary>
		[UnmanagedCall]
		[EditorOrder(30), EditorDisplay("CSG"), Tooltip("Brush surfaces master scale in lightmap"), Limit(0, 1000.0f, 0.1f)]
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
		/// Gets or sets brush size.
		/// </summary>
		[UnmanagedCall]
		[EditorOrder(20), EditorDisplay("CSG"), Tooltip("CSG brush size")]
		public Vector3 Size
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { Vector3 resultAsRef; Internal_GetSize(unmanagedPtr, out resultAsRef); return resultAsRef; }
			set { Internal_SetSize(unmanagedPtr, ref value); }
#endif
		}

		/// <summary>
		/// Gets or sets brush center location (in local space).
		/// </summary>
		[UnmanagedCall]
		[EditorOrder(21), EditorDisplay("CSG"), Tooltip("CSG brush center location (in local space)")]
		public Vector3 Center
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { Vector3 resultAsRef; Internal_GetCenter(unmanagedPtr, out resultAsRef); return resultAsRef; }
			set { Internal_SetCenter(unmanagedPtr, ref value); }
#endif
		}

		/// <summary>
		/// Gets or sets CSG brush mode.
		/// </summary>
		[UnmanagedCall]
		[EditorOrder(10), EditorDisplay("CSG"), Tooltip("CSG brush mode")]
		public BrushMode Mode
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { return Internal_GetMode(unmanagedPtr); }
			set { Internal_SetMode(unmanagedPtr, value); }
#endif
		}

		/// <summary>
		/// Gets the volume bounding box (oriented).
		/// </summary>
		[UnmanagedCall]
		public OrientedBoundingBox OrientedBox
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { OrientedBoundingBox resultAsRef; Internal_GetOrientedBox(unmanagedPtr, out resultAsRef); return resultAsRef; }
#endif
		}

#region Internal Calls
#if !UNIT_TEST_COMPILANT
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern float Internal_GetScaleInLightmap(IntPtr obj);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_SetScaleInLightmap(IntPtr obj, float val);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_GetSize(IntPtr obj, out Vector3 resultAsRef);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_SetSize(IntPtr obj, ref Vector3 val);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_GetCenter(IntPtr obj, out Vector3 resultAsRef);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_SetCenter(IntPtr obj, ref Vector3 val);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern BrushMode Internal_GetMode(IntPtr obj);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_SetMode(IntPtr obj, BrushMode val);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_GetOrientedBox(IntPtr obj, out OrientedBoundingBox resultAsRef);
#endif
#endregion
	}
}

