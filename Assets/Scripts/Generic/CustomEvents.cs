using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable] public class FloatEvent : UnityEvent<float> { }
[Serializable] public class BoolEvent : UnityEvent<bool> { }
[Serializable] public class Vector2Event : UnityEvent<Vector2> { }
[Serializable] public class Vector3Event : UnityEvent<Vector3> { }