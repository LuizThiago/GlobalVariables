using System;
using UnityEngine;
using UnityEngine.Events;

//-----------------------------------------------------------------------------------------
// Inherit from this class to create variables with global access from a Scriptable Object
//-----------------------------------------------------------------------------------------
public class GlobalVariable<T> : ScriptableObject
{
	[NonSerialized] private T _value;
	[NonSerialized] private UnityEvent<T> _onChange = new();

	#region Properties

	public T Value
	{
		get => _value;
		set
		{
			_value = value;
			_onChange.Invoke(_value);
		}
	}

	#endregion

	#region Public

	public UnityEvent<T> OnChange => _onChange;

	#endregion
}