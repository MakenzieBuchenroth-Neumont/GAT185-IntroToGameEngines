using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameObjectEventListener : MonoBehaviour {
	[SerializeField] private GameObjectEvent _event = default;

	public UnityEvent<GameObject> listener;

	private void OnEnable() {
		_event?.subscribe(Respond);
	}

	private void OnDisable() {
		_event?.unsubscribe(Respond);
	}

	private void Respond(GameObject value) {
		listener?.Invoke(value);
	}
}