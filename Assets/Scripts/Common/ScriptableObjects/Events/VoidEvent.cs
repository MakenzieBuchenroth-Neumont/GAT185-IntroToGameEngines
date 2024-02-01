using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Event")]
public class VoidEvent : ScriptableObjectBase {
	public UnityAction onEventRaised;

	public void raiseEvent() {
		onEventRaised?.Invoke();
	}

	public void subscribe(UnityAction function) {
		onEventRaised += function;
	}

	public void unsubscribe(UnityAction function) {
		onEventRaised -= function;
	}
}
