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
	/// Application management utilities.
	/// </summary>
	public static partial class Application
	{
		/// <summary>
		/// Gets the name of the computer machine.
		/// </summary>
		[UnmanagedCall]
		public static string ComputerName
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { return Internal_GetComputerName(); }
#endif
		}

		/// <summary>
		/// Gets the name of the current user.
		/// </summary>
		[UnmanagedCall]
		public static string UserName
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { return Internal_GetUserName(); }
#endif
		}

		/// <summary>
		/// Gets the current user locale culture name eg. "pl-PL" or "en-US".
		/// </summary>
		[UnmanagedCall]
		public static string UserLocaleName
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { return Internal_GetUserLocaleName(); }
#endif
		}

		/// <summary>
		/// Gets size of the primary desktop.
		/// </summary>
		[UnmanagedCall]
		public static Vector2 DesktopSize
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { Vector2 resultAsRef; Internal_GetDesktopSize(out resultAsRef); return resultAsRef; }
#endif
		}

		/// <summary>
		/// Gets the origin position and size of the monitor at the given screen-space location.
		/// </summary>
		/// <param name="screenPos">The screen position (in pixels).</param>
		/// <returns>The monitor bounds.</returns>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public static Rectangle GetMonitorBounds(Vector2 screenPos) 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			Rectangle resultAsRef;
			Internal_GetMonitorBounds(ref screenPos, out resultAsRef);
			return resultAsRef;
#endif
		}

		/// <summary>
		/// Gets size of the virtual desktop made of all the monitors attached.
		/// </summary>
		[UnmanagedCall]
		public static Vector2 VirtualDesktopSize
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { Vector2 resultAsRef; Internal_GetVirtualDesktopSize(out resultAsRef); return resultAsRef; }
#endif
		}

		/// <summary>
		/// Gets or sets the current mouse position in the screen coordinates.
		/// </summary>
		[UnmanagedCall]
		public static Vector2 MousePosition
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { Vector2 resultAsRef; Internal_GetMousePosition(out resultAsRef); return resultAsRef; }
			set { Internal_SetMousePosition(ref value); }
#endif
		}

		/// <summary>
		/// True if app has focus.
		/// </summary>
		[UnmanagedCall]
		public static bool HasFocus
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { return Internal_GetHasFocus(); }
#endif
		}

		/// <summary>
		/// Requests normal engine exit.
		/// </summary>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public static void Exit() 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			Internal_Exit();
#endif
		}

		/// <summary>
		/// Immediately released all the engine resources and closes the application. Used when fatal error occurred.
		/// </summary>
		/// <param name="msg">Fatal error message. Will be saved to the log. Should contain basic information about the error.</param>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public static void Fatal(string msg) 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			Internal_Fatal(msg);
#endif
		}

		/// <summary>
		/// Gets or sets the system clipboard text.
		/// </summary>
		[UnmanagedCall]
		public static string ClipboardText
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { return Internal_GetClipboardText(); }
			set { Internal_SetClipboardText(value); }
#endif
		}

		/// <summary>
		/// Gets or sets the system clipboard raw data bytes.
		/// </summary>
		[UnmanagedCall]
		public static byte[] ClipboardRawData
		{
#if UNIT_TEST_COMPILANT
			get; set;
#else
			get { return Internal_GetClipboardDataRaw(); }
			set { Internal_SetClipboardDataRaw(value); }
#endif
		}

		/// <summary>
		/// Starts a new native process.
		/// </summary>
		/// <param name="path">Target file path.</param>
		/// <param name="args">Custom command line arguments to pass to the new application.</param>
		/// <param name="hiddenWindow">True if hide processs window, otherwise false (it's not always possible).</param>
		/// <param name="waitForEnd">True if wait for the process end, otherwise false.</param>
		/// <returns>Retrieves the termination status of the specified process. Invalid if process is still running.</returns>
#if UNIT_TEST_COMPILANT
		[Obsolete("Unit tests, don't support methods calls.")]
#endif
		[UnmanagedCall]
		public static int StartProcess(string path, string args = null, bool hiddenWindow = false, bool waitForEnd = false) 
		{
#if UNIT_TEST_COMPILANT
			throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
			return Internal_StartProcess(path, args, hiddenWindow, waitForEnd);
#endif
		}

#region Internal Calls
#if !UNIT_TEST_COMPILANT
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern string Internal_GetComputerName();
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern string Internal_GetUserName();
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern string Internal_GetUserLocaleName();
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_GetDesktopSize(out Vector2 resultAsRef);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_GetMonitorBounds(ref Vector2 screenPos, out Rectangle resultAsRef);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_GetVirtualDesktopSize(out Vector2 resultAsRef);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_GetMousePosition(out Vector2 resultAsRef);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_SetMousePosition(ref Vector2 val);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern bool Internal_GetHasFocus();
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_Exit();
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_Fatal(string msg);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern string Internal_GetClipboardText();
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_SetClipboardText(string val);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern byte[] Internal_GetClipboardDataRaw();
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void Internal_SetClipboardDataRaw(byte[] val);
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern int Internal_StartProcess(string path, string args, bool hiddenWindow, bool waitForEnd);
#endif
#endregion
	}
}

