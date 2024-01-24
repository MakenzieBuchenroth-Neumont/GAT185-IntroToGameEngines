using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SimpleCollectibleScript : MonoBehaviour {
    [SerializeField] FloatVariable time;
    [SerializeField] IntVariable score;
    [SerializeField] GameObject pickupPrefab = null;

    public enum CollectibleTypes {NoType, TimeIncrease, Points, Coin, Type4, Type5}; // you can replace this with your own labels for the types of collectibles in your game!

	public CollectibleTypes CollectibleType; // this gameObject's type

	public bool rotate; // do you want it to rotate?

	public float rotationSpeed;

	public AudioClip collectSound;

	public GameObject collectEffect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (rotate)
			transform.Rotate (Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			Collect ();
		}
	}

	public void Collect()
	{
		if(collectSound)
			AudioSource.PlayClipAtPoint(collectSound, transform.position);
		if(collectEffect)
			Instantiate(collectEffect, transform.position, Quaternion.identity);

		//Below is space to add in your code for what happens based on the collectible type

		if (CollectibleType == CollectibleTypes.NoType) {

			//Add in code here;

			Debug.Log ("Do NoType Command");
		}
		if (CollectibleType == CollectibleTypes.TimeIncrease) {

            //Add in code here;
            Destroy(gameObject);
            time.value = time.value + 60;

			Debug.Log ("Added 60 seconds to timer");
		}
		if (CollectibleType == CollectibleTypes.Points) {

            //Add in code here;
            Destroy(gameObject);
            score.value = score.value + 100;

			Debug.Log ("Added 100 points to score");
		}
		if (CollectibleType == CollectibleTypes.Coin) {

            //Add in code here;
            Destroy(gameObject);
            score.value = score.value + 10;

            Debug.Log ("Added 10 points");
		}
		if (CollectibleType == CollectibleTypes.Type4) {

			//Add in code here;

			Debug.Log ("Do NoType Command");
		}
		if (CollectibleType == CollectibleTypes.Type5) {

			//Add in code here;

			Debug.Log ("Do NoType Command");
		}

		Destroy (gameObject);
	}
}
