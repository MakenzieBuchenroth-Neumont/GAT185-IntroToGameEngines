using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;
using Unity.Mathematics;

public class PathFollower : MonoBehaviour {
	[SerializeField] SplineContainer splineContainer;
	[Range(0,40)] public float speed = 1;

	[Range(0,1)] public float tdistance = 0; // distance along spline (0-1)

	//public float speed {  get; set; }

	public float length { get { return splineContainer.CalculateLength(); } }
	public float distance { 
		get { 
			return tdistance * length;
		}
		set { tdistance = value / length; 
		}
	}

	private void Start() {
		//speed = maxSpeed;
	}
	private void Update() {
		distance += speed * Time.deltaTime;
		updateTransform(math.frac(tdistance));
	}

	private void updateTransform(float t) {
		Vector3 position = splineContainer.EvaluatePosition(t);
		Vector3 upVector = splineContainer.EvaluateUpVector(t);
		Vector3 forward = Vector3.Normalize(splineContainer.EvaluateTangent(t));
		Vector3 right = Vector3.Cross(upVector, forward);

		transform.position = position;
		transform.rotation = Quaternion.LookRotation(forward, upVector);
	}
}
