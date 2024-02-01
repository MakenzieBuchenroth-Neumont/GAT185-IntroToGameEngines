using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private float moveSpeed = 5f;
    private int _currentWaypoint;

    private void Start() {
        if (waypoints.Count <= 0) {
            _currentWaypoint = 0;
        }
    }

    private void FixedUpdate() {
        handleMovement();
    }

    private void handleMovement() {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[_currentWaypoint].transform.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(waypoints[_currentWaypoint].transform.position, transform.position) <= 0.05) {
            _currentWaypoint++;
        }

        if (_currentWaypoint != waypoints.Count) { return; }
        waypoints.Reverse();
        _currentWaypoint = 0;
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Player")) return;
        other.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other) {
        if (!other.CompareTag("Player")) return;
        other.transform.parent = null;
    }
}
