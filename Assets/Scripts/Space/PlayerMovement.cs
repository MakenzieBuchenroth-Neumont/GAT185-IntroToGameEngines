using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	[SerializeField] float speed = 5;
	public Rigidbody rb;

	private void FixedUpdate() {
		Vector3 forwardMovement = transform.forward * speed * Time.fixedDeltaTime;
		rb.MovePosition(rb.position + forwardMovement);
	}
}
