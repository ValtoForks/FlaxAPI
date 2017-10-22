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
	/// Physics simulation service.
	/// </summary>
	public static partial class Physics
	{
		/// <summary>
		/// Gets or sets the current gravity force.
		/// </summary>
		[UnmanagedCall]
		public static Vector3 Gravity
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { Vector3 resultAsRef; Internal_GetGravity(out resultAsRef); return resultAsRef; }
			set { Internal_SetGravity(ref value); }
#endif
		}

		/// <summary>
		/// Gets or sets the CCD feature enable flag.
		/// </summary>
		[UnmanagedCall]
		public static bool EnableCCD
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { return Internal_GetEnableCCD(); }
			set { Internal_SetEnableCCD(value); }
#endif
		}

		/// <summary>
		/// Gets or sets the minimum relative velocity required for an object to bounce.
		/// </summary>
		[UnmanagedCall]
		public static float BounceThresholdVelocity
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { return Internal_GetBounceThresholdVelocity(); }
			set { Internal_SetBounceThresholdVelocity(value); }
#endif
		}

		/// <summary>
		/// Gets or sets the automatic simulation feature. True if perform physics simulation after on fixed update by auto, otherwise user should do it.
		/// </summary>
		[UnmanagedCall]
		public static bool AutoSimulation
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { return Internal_GetAutoSimulation(); }
			set { Internal_SetAutoSimulation(value); }
#endif
		}

		/// <summary>
		/// Performs physics simulation. Usefull to execute physics simulation manually when AutoSimulation is disabled. If delta time is too small simulation may not be performed but time accumulated.
		/// </summary>
		/// <param name="dt">The delta time (in seconds).</param>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public static float Simulate(float dt) 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			return Internal_Simulate(dt);
#endif
		}

#region Internal Calls
#if !UNIT_TEST_COMPILANT
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_GetGravity(out Vector3 resultAsRef);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_SetGravity(ref Vector3 val);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool Internal_GetEnableCCD();
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_SetEnableCCD(bool val);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern float Internal_GetBounceThresholdVelocity();
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_SetBounceThresholdVelocity(float val);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool Internal_GetAutoSimulation();
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_SetAutoSimulation(bool val);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern float Internal_Simulate(float dt);
#endif
#endregion
	}
}
