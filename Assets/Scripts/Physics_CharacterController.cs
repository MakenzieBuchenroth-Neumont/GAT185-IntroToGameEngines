using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Physics_CharacterController : MonoBehaviour {
    [Header("Movement")]
    [SerializeField][Range(1f, 10f)] float maxForce;
    [SerializeField][Range(1f, 10f)] float jumpForce;
    [SerializeField] Transform view;
    [Header("Collision")]
    [SerializeField][Range(0f, 5f)] float rayLength = 1;
    [SerializeField] LayerMask groundLayerMask;

    Rigidbody rb;
    Vector3 force = Vector3.zero;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
       rb = GetComponent<Rigidbody>(); 
    }

    private void Update() {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        Quaternion yrotation = Quaternion.AngleAxis(view.rotation.eulerAngles.y, Vector3.up);

        force = yrotation * direction * maxForce;
        
        Debug.DrawRay(transform.position, Vector3.down * rayLength, Color.red);
        if (Input.GetButtonDown("Jump") && onGround()) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate() {
        rb.AddForce(force, ForceMode.Force);
    }

    private bool onGround() {
        return Physics.Raycast(transform.position, Vector3.down, rayLength, groundLayerMask);
    }
}
