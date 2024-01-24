using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Int Event")]
public class IntEvent : ScriptableObjectBase {
	public UnityAction<int> onEventRaised;

	public void raiseEvent(int value) {
		onEventRaised?.Invoke(value);
	}

	public void subscribe(UnityAction<int> function) {
		onEventRaised += function;
	}

	public void unsubscribe(UnityAction<int> function) {
		onEventRaised -= function;
	}
}
