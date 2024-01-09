using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class Walk : MonoBehaviour {
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float turnSpeed = 90f;
    [SerializeField] float pauseTime = 1f;
    [SerializeField] float timer;
    private bool move = true;
    private bool turn = true;

    private void Start() {
        timer = 2;
    }

    private void Update()
    {
        if (move)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                move = false;
                turn = true;
                timer = 4;
            }
        } else if(turn)
        {
            transform.rotation *= Quaternion.AngleAxis(45f * Time.deltaTime, Vector3.up);
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                turn = false;
                timer = 1;

            }
        } else
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                move = true;
                timer = 2;
            }
        }
    }
}