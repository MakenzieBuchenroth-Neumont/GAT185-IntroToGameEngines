using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit_Camera : MonoBehaviour {
    [SerializeField] Transform target = null;
    [SerializeField][Range(20, 90)] float pitch = 40;
    [SerializeField][Range(3, 5)] float distance = 3;
    [SerializeField][Range(1, 5)] float sensitivity = 1;

    float yaw = 0;

    void Update() {
        yaw += Input.GetAxis("Mouse X") * sensitivity;

        Quaternion qyaw = Quaternion.AngleAxis(yaw, Vector3.up);
        Quaternion qpitch = Quaternion.AngleAxis(pitch, Vector3.right);
        Quaternion rotation = qyaw * qpitch;

        transform.position = target.position + (rotation * Vector3.back * distance);
        transform.rotation = rotation;
    }
}
