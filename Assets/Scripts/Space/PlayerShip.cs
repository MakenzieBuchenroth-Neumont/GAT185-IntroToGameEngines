using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Interactable {
	[SerializeField] Action action;
	[SerializeField] private Inventory inventory;

	public float health = 100;

	private void Start() {
		if (action != null) {
			action.onEnter += OnInteractStart;
			action.onStay += OnInteractActive;
		}
	}

	private void Update() {
		if (Input.GetButtonDown("Fire1")) {
			inventory.use();
		}
		if (Input.GetButtonUp("Fire1")) {
			inventory.stopUse();
		}
	}

	public override void OnInteractActive(GameObject gameObject) {
		//
	}

	public override void OnInteractEnd(GameObject gameObject) {
		//
	}

	public override void OnInteractStart(GameObject gameObject) {
		//
	}
}
