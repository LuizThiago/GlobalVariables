using System;
using System.Collections;
using UnityEngine;

public class TestGlobalFloatVariable : MonoBehaviour
{
	[SerializeField] private GlobalFloatVariable _playerHealth;

	private IEnumerator Start()
	{
		//Subscribe to the player health's OnChange event to be notified when the value changes.
		_playerHealth.OnChange.AddListener(OnPlayerHealthChange);
		Debug.Log($"[TestGlobalFloatVariable] Player health value: {_playerHealth.Value}");

		//Wait and set the player health to 100.
		string timestamp = System.DateTime.Now.ToString("HH:mm:ss.fff");
		Debug.Log($"[TestGlobalFloatVariable][{timestamp}] Change player health to 100 in 5 second.");
		yield return new WaitForSeconds(5);
		_playerHealth.Value = 100;
	}

	private void OnPlayerHealthChange(float value)
	{
		string timestamp = System.DateTime.Now.ToString("HH:mm:ss.fff");
		Debug.Log($"[TestGlobalFloatVariable][{timestamp}] Player health changed to {value}");
	}
}
