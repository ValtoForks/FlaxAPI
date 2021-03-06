// Copyright (c) 2012-2018 Wojciech Figat. All rights reserved.
// This code was generated by a tool. Changes to this file may cause
// incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace FlaxEngine
{
    /// <summary>
    /// Base class for all actor types on the scene
    /// </summary>
    [Serializable]
    public abstract partial class Actor : Object
    {
        /// <summary>
        /// Creates new <see cref="Actor"/> object.
        /// </summary>
        protected Actor() : base()
        {
        }

        /// <summary>
        /// Gets the scene object which contains this actor.
        /// </summary>
        [UnmanagedCall]
        [HideInEditor, NoSerialize]
        public Scene Scene
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetScene(unmanagedPtr); }
#endif
        }

        /// <summary>
        /// Gets or sets parent actor (or null if actor has no parent)
        /// </summary>
        [UnmanagedCall]
        [HideInEditor]
        public Actor Parent
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetParent(unmanagedPtr); }
            set { Internal_SetParent(unmanagedPtr, Object.GetUnmanagedPtr(value), false); }
#endif
        }

        /// <summary>
        /// Sets parent actor with parameters
        /// </summary>
        /// <param name="newParent">New parent to assign</param>
        /// <param name="worldPositionLock">Should actor world positions remain the same after parent change</param>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public void SetParent(Actor newParent, bool worldPositionLock = true)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            Internal_SetParent(unmanagedPtr, Object.GetUnmanagedPtr(newParent), worldPositionLock);
#endif
        }

        /// <summary>
        /// Gets or sets zero-based index in parent actor children list.
        /// </summary>
        [UnmanagedCall]
        [HideInEditor]
        public int OrderInParent
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetOrderInParent(unmanagedPtr); }
            set { Internal_SetOrderInParent(unmanagedPtr, value); }
#endif
        }

        /// <summary>
        /// Gets or sets object hide flags.
        /// </summary>
        [UnmanagedCall]
        [HideInEditor]
        public HideFlags HideFlags
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetHideFlags(unmanagedPtr); }
            set { Internal_SetHideFlags(unmanagedPtr, value); }
#endif
        }

        /// <summary>
        /// Gets or sets the actor name.
        /// </summary>
        [UnmanagedCall]
        [EditorDisplay("General"), EditorOrder(-100), Tooltip("Custom name of the actor")]
        public string Name
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetName(unmanagedPtr); }
            set { Internal_SetName(unmanagedPtr, value); }
#endif
        }

        /// <summary>
        /// Gets or sets actor static fags
        /// </summary>
        [UnmanagedCall]
        [EditorDisplay("General"), EditorOrder(-80), Tooltip("Static flags describe type of the object")]
        public StaticFlags StaticFlags
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetStaticFlags(unmanagedPtr); }
            set { Internal_SetStaticFlags(unmanagedPtr, value); }
#endif
        }

        /// <summary>
        /// Gets or sets the layer actor is in. Can be used for selective rendering or ignoring raycasts.
        /// </summary>
        [UnmanagedCall]
        [EditorDisplay("General"), EditorOrder(-69), Tooltip("The layer object is in")]
        public int Layer
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetLayer(unmanagedPtr); }
            set { Internal_SetLayer(unmanagedPtr, value); }
#endif
        }

        /// <summary>
        /// Gets or sets the object tag. Can be used to identify the objects.
        /// </summary>
        [UnmanagedCall]
        [EditorDisplay("General"), EditorOrder(-68), Tooltip("The object tag. Can be used to identify it.")]
        public string Tag
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetTag(unmanagedPtr); }
            set { Internal_SetTag(unmanagedPtr, value); }
#endif
        }

        /// <summary>
        /// Gets or sets active state of actor
        /// </summary>
        [UnmanagedCall]
        [EditorDisplay("General"), DefaultValue(true), EditorOrder(-70), Tooltip("Enable/disable object")]
        public bool IsActive
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetIsActive(unmanagedPtr); }
            set { Internal_SetIsActive(unmanagedPtr, value); }
#endif
        }

        /// <summary>
        /// Gets actor activation state in hierarchy
        /// </summary>
        [UnmanagedCall]
        [HideInEditor, NoSerialize]
        public bool IsActiveInHierarchy
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetIsActiveInHierarchy(unmanagedPtr); }
#endif
        }

        /// <summary>
        /// Gets or sets actor's world transform position
        /// </summary>
        [UnmanagedCall]
        [HideInEditor, NoSerialize]
        public Vector3 Position
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { Vector3 resultAsRef; Internal_GetPosition(unmanagedPtr, out resultAsRef); return resultAsRef; }
            set { Internal_SetPosition(unmanagedPtr, ref value); }
#endif
        }

        /// <summary>
        /// Gets or sets actor's world transform orientation
        /// </summary>
        [UnmanagedCall]
        [HideInEditor, NoSerialize]
        public Quaternion Orientation
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { Quaternion resultAsRef; Internal_GetOrientation(unmanagedPtr, out resultAsRef); return resultAsRef; }
            set { Internal_SetOrientation(unmanagedPtr, ref value); }
#endif
        }

        /// <summary>
        /// Gets or sets actor's world transform scale
        /// </summary>
        [UnmanagedCall]
        [HideInEditor, NoSerialize]
        public Vector3 Scale
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { Vector3 resultAsRef; Internal_GetScale(unmanagedPtr, out resultAsRef); return resultAsRef; }
            set { Internal_SetScale(unmanagedPtr, ref value); }
#endif
        }

        /// <summary>
        /// Gets or sets actor's world a three dimensional mathematical transformation
        /// </summary>
        [UnmanagedCall]
        [HideInEditor, NoSerialize]
        public Transform Transform
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { Transform resultAsRef; Internal_GetTransform(unmanagedPtr, out resultAsRef); return resultAsRef; }
            set { Internal_SetTransform(unmanagedPtr, ref value); }
#endif
        }

        /// <summary>
        /// Gets or sets actor's local transform position
        /// </summary>
        [UnmanagedCall]
        [EditorDisplay("Transform", "Position"), DefaultValue(typeof(Vector3), "0,0,0"), EditorOrder(-30), NoSerialize, Tooltip("Local position of the object (in the parent object space)")]
        public Vector3 LocalPosition
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { Vector3 resultAsRef; Internal_GetLocalPosition(unmanagedPtr, out resultAsRef); return resultAsRef; }
            set { Internal_SetLocalPosition(unmanagedPtr, ref value); }
#endif
        }

        /// <summary>
        /// Gets or sets actor's local transform orientation
        /// </summary>
        [UnmanagedCall]
        [EditorDisplay("Transform", "Rotation"), DefaultValue(typeof(Quaternion), "0,0,0,1"), EditorOrder(-20), NoSerialize, Tooltip("Local orientation of the object (in the parent object space)")]
        public Quaternion LocalOrientation
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { Quaternion resultAsRef; Internal_GetLocalOrientation(unmanagedPtr, out resultAsRef); return resultAsRef; }
            set { Internal_SetLocalOrientation(unmanagedPtr, ref value); }
#endif
        }

        /// <summary>
        /// Gets or sets actor's local transform scale
        /// </summary>
        [UnmanagedCall]
        [EditorDisplay("Transform", "Scale"), DefaultValue(typeof(Vector3), "1,1,1"), Limit(float.MinValue, float.MaxValue, 0.01f), EditorOrder(-10), NoSerialize, Tooltip("Local scale of the object (in the parent object space)")]
        public Vector3 LocalScale
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { Vector3 resultAsRef; Internal_GetLocalScale(unmanagedPtr, out resultAsRef); return resultAsRef; }
            set { Internal_SetLocalScale(unmanagedPtr, ref value); }
#endif
        }

        /// <summary>
        /// Gets or sets actor's world a three dimensional mathematical transformation
        /// </summary>
        [UnmanagedCall]
        [HideInEditor]
        public Transform LocalTransform
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { Transform resultAsRef; Internal_GetLocalTransform(unmanagedPtr, out resultAsRef); return resultAsRef; }
            set { Internal_SetLocalTransform(unmanagedPtr, ref value); }
#endif
        }

        /// <summary>
        /// Gets amount of children
        /// </summary>
        [UnmanagedCall]
        [HideInEditor, NoSerialize]
        public int ChildrenCount
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetChildCount(unmanagedPtr); }
#endif
        }

        /// <summary>
        /// Gets child actor at given index
        /// </summary>
        /// <param name="index">Child's actor index</param>
        /// <returns>Child actor</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public Actor GetChild(int index)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_GetChildAtIndex(unmanagedPtr, index);
#endif
        }

        /// <summary>
        /// Gets child actor with given name
        /// </summary>
        /// <param name="name">Child's actor name</param>
        /// <returns>Child actor</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public Actor GetChild(string name)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_GetChildWithName(unmanagedPtr, name);
#endif
        }

        /// <summary>
        /// Tries to find actor with given name in this actor tree
        /// </summary>
        /// <param name="name">Actor's name to find</param>
        /// <returns>Actor instance if found, null otherwise</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public Actor FindActor(string name)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_FindActorWithName(unmanagedPtr, name);
#endif
        }

        /// <summary>
        /// Tries to find actor with given name on the scene
        /// </summary>
        /// <param name="name">Actor's name to find</param>
        /// <returns>Actor instance if found, null otherwise</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public static Actor Find(string name)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_FindActor(name);
#endif
        }

        /// <summary>
        /// Searches for a child actor of a specific type. If there are multiple actors matching the type, only the first one found is returned.
        /// </summary>
        /// <param name="actorType">Type of the actor to search for. Includes any actors derived from the type.</param>
        /// <returns>Actor instance if found, null otherwise</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public Actor GetChild(Type actorType)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_GetChild(unmanagedPtr, actorType);
#endif
        }

        /// <summary>
        /// Searches for all actors of a specific type.
        /// </summary>
        /// <param name="actorType">Type of the actor to search for. Includes any actors derived from the type.</param>
        /// <returns>All actors matching the specified type</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public Actor[] GetChildren(Type actorType)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_GetChildrenPerType(unmanagedPtr, actorType);
#endif
        }

        /// <summary>
        /// Returns a list of all actors attached to this object. It's read-only array.
        /// </summary>
        /// <returns>All actors attached to this object.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public Actor[] GetChildren()
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_GetChildren(unmanagedPtr);
#endif
        }

        /// <summary>
        /// Gets amount of scripts added to this actor.
        /// </summary>
        [UnmanagedCall]
        [HideInEditor, NoSerialize]
        public int ScriptsCount
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_GetScriptsCount(unmanagedPtr); }
#endif
        }

        /// <summary>
        /// Gets the child script at given index.
        /// </summary>
        /// <param name="index">The zero-based index of the script in the actor scripts array.</param>
        /// <returns>The script instance.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public Script GetScript(int index)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_GetScriptAtIndex(unmanagedPtr, index);
#endif
        }

        /// <summary>
        /// Searches for a child script of a specific type. If there are multiple scripts matching the type, only the first one found is returned.
        /// </summary>
        /// <param name="scriptType">Type of the script to search for. Includes any scripts derived from the type.</param>
        /// <returns>Script instance if found, null otherwise.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public Script GetScript(Type scriptType)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_GetScript(unmanagedPtr, scriptType);
#endif
        }

        /// <summary>
        /// Searches for all scripts of a specific type.
        /// </summary>
        /// <param name="scriptType">Type of the script to search for. Includes any scripts derived from the type.</param>
        /// <returns>All scripts matching the specified type.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public Script[] GetScripts(Type scriptType)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_GetScriptsPerType(unmanagedPtr, scriptType);
#endif
        }

        /// <summary>
        /// Searches for a child script of a specific type in this actor or any of its children. If there are multiple scripts matching the type, only the first one found is returned.
        /// </summary>
        /// <param name="scriptType">Type of the script to search for. Includes any scripts derived from the type.</param>
        /// <param name="includeDisabled">Determines whether include disabled scripts into results (disabled scripts and/or inactive actors).</param>
        /// <returns>Script instance if found, null otherwise.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public Script GetScriptInChildren(Type scriptType, bool includeDisabled = false)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_GetScriptInChildren(unmanagedPtr, scriptType, includeDisabled);
#endif
        }

        /// <summary>
        /// Searches for all scripts of a specific type in this actor and any of its children.
        /// </summary>
        /// <param name="scriptType">Type of the script to search for. Includes any scripts derived from the type.</param>
        /// <param name="includeDisabled">Determines whether include inactive scripts into results (disabled scripts and/or inactive actors).</param>
        /// <returns>All scripts matching the specified type and query options.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public Script[] GetScriptsInChildren(Type scriptType, bool includeDisabled = false)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_GetScriptsInChildrenPerType(unmanagedPtr, scriptType, includeDisabled);
#endif
        }

        /// <summary>
        /// Adds a script to the actor.
        /// </summary>
        /// <param name="script">The script to add</param>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public void AddScript(Script script)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            Internal_AddScript(unmanagedPtr, Object.GetUnmanagedPtr(script));
#endif
        }

        /// <summary>
        /// Removes a script from the actor. Use Object.Destroy to delete unlinked script and prevent from leaks.
        /// </summary>
        /// <param name="script">The script to remove</param>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public void RemoveScript(Script script)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            Internal_RemoveScript(unmanagedPtr, Object.GetUnmanagedPtr(script));
#endif
        }

        /// <summary>
        /// Detaches script from the actor and deletes the object.
        /// </summary>
        /// <param name="index">The index of the script to remove.</param>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public void DeleteScript(int index)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            Internal_DeleteScript(unmanagedPtr, index);
#endif
        }

        /// <summary>
        /// Gets bounding box that contains actor object (single actor, no children included)
        /// </summary>
        [UnmanagedCall]
        [HideInEditor, NoSerialize]
        public BoundingBox Box
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { BoundingBox resultAsRef; Internal_GetBox(unmanagedPtr, out resultAsRef); return resultAsRef; }
#endif
        }

        /// <summary>
        /// Gets bounding box that contains actor object and all it's children (children included in recursive way)
        /// </summary>
        [UnmanagedCall]
        [HideInEditor, NoSerialize]
        public BoundingBox BoxWithChildren
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { BoundingBox resultAsRef; Internal_GetBoxWithChildren(unmanagedPtr, out resultAsRef); return resultAsRef; }
#endif
        }

        /// <summary>
        /// Returns true if actor has loaded content
        /// </summary>
        [UnmanagedCall]
        public bool HasContentLoaded
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_HasContentLoaded(unmanagedPtr); }
#endif
        }

        /// <summary>
        /// Gets a value indicating whether this actor has a valid linkage to the prefab asset.
        /// </summary>
        [UnmanagedCall]
        public bool HasPrefabLink
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_HasPrefabLink(unmanagedPtr); }
#endif
        }

        /// <summary>
        /// Gets a value indicating whether this actor is a prefab instance root object.
        /// </summary>
        [UnmanagedCall]
        public bool IsPrefabRoot
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { return Internal_IsPrefabRoot(unmanagedPtr); }
#endif
        }

        /// <summary>
        /// Gets the prefab asset ID. Empty if no prefab link exists.
        /// </summary>
        [UnmanagedCall]
        public Guid PrefabID
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { Guid resultAsRef; Internal_GetPrefabID(unmanagedPtr, out resultAsRef); return resultAsRef; }
#endif
        }

        /// <summary>
        /// Gets the ID of the object within a prefab that is used for synchronization with this actor. Empty if no prefab link exists.
        /// </summary>
        [UnmanagedCall]
        public Guid PrefabObjectID
        {
#if UNIT_TEST_COMPILANT
            get; set;
#else
            get { Guid resultAsRef; Internal_GetPrefabObjectID(unmanagedPtr, out resultAsRef); return resultAsRef; }
#endif
        }

        /// <summary>
        /// Breaks the prefab linkage for this actor, all its scripts, and all child actors.
        /// </summary>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public void BreakPrefabLink()
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            Internal_BreakPrefabLink(unmanagedPtr);
#endif
        }

        /// <summary>
        /// Determines whether the specified object is in a hierarchy (one of the children or lower).
        /// </summary>
        /// <param name="actor">The actor to check,</param>
        /// <returns>True if given actor is part of the hierarchy, otherwise false.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public bool ContainsInHierarchy(Actor actor)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_ContainsInHierarchy(unmanagedPtr, actor);
#endif
        }

        /// <summary>
        /// Determines whether the specified object is one of the children.
        /// </summary>
        /// <param name="actor">The actor to check,</param>
        /// <returns>True if given actor is a child, otherwise false.</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public bool ContainsChild(Actor actor)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_ContainsChild(unmanagedPtr, actor);
#endif
        }

        /// <summary>
        /// Tries the get serialized objects ids from the raw bytes.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>Collection of serialized objects ids or null if cannot gather information from the bytes (invalid format).</returns>
#if UNIT_TEST_COMPILANT
        [Obsolete("Unit tests, don't support methods calls.")]
#endif
        [UnmanagedCall]
        public static Guid[] TryGetSerializedObjectsIds(byte[] data)
        {
#if UNIT_TEST_COMPILANT
            throw new NotImplementedException("Unit tests, don't support methods calls. Only properties can be get or set.");
#else
            return Internal_TryGetSerializedObjectsIds(data);
#endif
        }

        #region Internal Calls

#if !UNIT_TEST_COMPILANT
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern Scene Internal_GetScene(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern Actor Internal_GetParent(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetParent(IntPtr obj, IntPtr val, bool worldPositionLock);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int Internal_GetOrderInParent(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetOrderInParent(IntPtr obj, int val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern HideFlags Internal_GetHideFlags(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetHideFlags(IntPtr obj, HideFlags val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern string Internal_GetName(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetName(IntPtr obj, string val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern StaticFlags Internal_GetStaticFlags(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetStaticFlags(IntPtr obj, StaticFlags val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int Internal_GetLayer(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetLayer(IntPtr obj, int val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern string Internal_GetTag(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetTag(IntPtr obj, string val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool Internal_GetIsActive(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetIsActive(IntPtr obj, bool val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool Internal_GetIsActiveInHierarchy(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_GetPosition(IntPtr obj, out Vector3 resultAsRef);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetPosition(IntPtr obj, ref Vector3 val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_GetOrientation(IntPtr obj, out Quaternion resultAsRef);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetOrientation(IntPtr obj, ref Quaternion val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_GetScale(IntPtr obj, out Vector3 resultAsRef);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetScale(IntPtr obj, ref Vector3 val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_GetTransform(IntPtr obj, out Transform resultAsRef);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetTransform(IntPtr obj, ref Transform val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_GetLocalPosition(IntPtr obj, out Vector3 resultAsRef);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetLocalPosition(IntPtr obj, ref Vector3 val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_GetLocalOrientation(IntPtr obj, out Quaternion resultAsRef);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetLocalOrientation(IntPtr obj, ref Quaternion val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_GetLocalScale(IntPtr obj, out Vector3 resultAsRef);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetLocalScale(IntPtr obj, ref Vector3 val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_GetLocalTransform(IntPtr obj, out Transform resultAsRef);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_SetLocalTransform(IntPtr obj, ref Transform val);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int Internal_GetChildCount(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern Actor Internal_GetChildAtIndex(IntPtr obj, int index);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern Actor Internal_GetChildWithName(IntPtr obj, string name);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern Actor Internal_FindActorWithName(IntPtr obj, string name);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern Actor Internal_FindActor(string name);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern Actor Internal_GetChild(IntPtr obj, Type actorType);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern Actor[] Internal_GetChildrenPerType(IntPtr obj, Type actorType);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern Actor[] Internal_GetChildren(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern int Internal_GetScriptsCount(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern Script Internal_GetScriptAtIndex(IntPtr obj, int index);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern Script Internal_GetScript(IntPtr obj, Type scriptType);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern Script[] Internal_GetScriptsPerType(IntPtr obj, Type scriptType);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern Script Internal_GetScriptInChildren(IntPtr obj, Type scriptType, bool includeDisabled);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern Script[] Internal_GetScriptsInChildrenPerType(IntPtr obj, Type scriptType, bool includeDisabled);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_AddScript(IntPtr obj, IntPtr script);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_RemoveScript(IntPtr obj, IntPtr script);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_DeleteScript(IntPtr obj, int index);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_GetBox(IntPtr obj, out BoundingBox resultAsRef);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_GetBoxWithChildren(IntPtr obj, out BoundingBox resultAsRef);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool Internal_HasContentLoaded(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool Internal_HasPrefabLink(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool Internal_IsPrefabRoot(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_GetPrefabID(IntPtr obj, out Guid resultAsRef);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_GetPrefabObjectID(IntPtr obj, out Guid resultAsRef);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern void Internal_BreakPrefabLink(IntPtr obj);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool Internal_ContainsInHierarchy(IntPtr obj, Actor actor);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern bool Internal_ContainsChild(IntPtr obj, Actor actor);

        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static extern Guid[] Internal_TryGetSerializedObjectsIds(byte[] data);
#endif

        #endregion
    }
}
