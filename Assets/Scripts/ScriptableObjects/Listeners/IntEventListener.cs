using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntEventListener : MonoBehaviour {
	[SerializeField] private IntEvent _event = default;

	public UnityEvent<int> listener;

	private void OnEnable() {
		_event?.subscribe(Respond);
	}

	private void OnDisable() {
		_event?.unsubscribe(Respond);
	}

	private void Respond(int value) {
		listener?.Invoke(value);
	}
}