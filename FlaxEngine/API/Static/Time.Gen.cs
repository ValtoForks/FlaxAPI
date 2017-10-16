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
	/// The interface to get time information from Flax.
	/// </summary>
	public static partial class Time
	{
		/// <summary>
		/// Gets or sets scale at which the time is passing. This can be used for slow motion effects.
		/// </summary>
		[UnmanagedCall]
		public static float TimeScale
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { return Internal_GetTimeScale(); }
			set { Internal_SetTimeScale(value); }
#endif
		}

		/// <summary>
		/// Gets the current Frames Per Second amount. User scripts updates or fixed updates for physics may run at a different frequency than scene rendering. Use this property to get an accurate amount of frames rendered during the last second.
		/// </summary>
		[UnmanagedCall]
		public static int FramesPerSecond
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { return Internal_GetFPS(); }
#endif
		}

#region Internal Calls
#if !UNIT_TEST_COMPILANT
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern float Internal_GetTimeScale();
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_SetTimeScale(float val);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern int Internal_GetFPS();
#endif
#endregion
	}
}

