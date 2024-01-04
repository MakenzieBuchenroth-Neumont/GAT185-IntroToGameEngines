using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    [Header("Movement")]
    [SerializeField][Range(1,20)][Tooltip("May the force be with you")] float force;

    public Rigidbody rb;

    private void Awake() {
    }
    void Start() {
        //rb = GetComponent<Rigidbody>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(transform.up * force, ForceMode.VelocityChange);
        }
    }
}
