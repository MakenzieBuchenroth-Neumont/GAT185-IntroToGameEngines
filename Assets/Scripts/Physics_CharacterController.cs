using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Physics_CharacterController : MonoBehaviour {
    [SerializeField][Range(1f, 10f)] float maxForce;
    [SerializeField][Range(1f, 10f)] float jumpForce;
    [SerializeField] Transform view;

    Rigidbody rb;
    Vector3 force = Vector3.zero;

    private void Start() {
       rb = GetComponent<Rigidbody>(); 
    }

    private void Update() {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        force = view.rotation * direction * maxForce;

        if (Input.GetButtonDown("Jump")) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate() {
        rb.AddForce(force, ForceMode.Force);
    }
}
