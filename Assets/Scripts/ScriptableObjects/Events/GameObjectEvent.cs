using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Game Object Event")]
public class GameObjectEvent : ScriptableObjectBase {
	public UnityAction<GameObject> onEventRaised;

	public void raiseEvent(GameObject value) {
		onEventRaised?.Invoke(value);
	}

	public void subscribe(UnityAction<GameObject> function) {
		onEventRaised += function;
	}

	public void unsubscribe(UnityAction<GameObject> function) {
		onEventRaised -= function;
	}
}
