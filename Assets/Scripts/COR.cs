using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class COR : MonoBehaviour {
    [SerializeField] float time = 3;
    [SerializeField] bool go = false;
    Coroutine timerCoroutine;

    private void Start() {
        timerCoroutine = StartCoroutine(timer(time));
        StartCoroutine("storytime");
        StartCoroutine("waitAction");
    }

    private void Update() {
        //time -= Time.deltaTime;
        //if (time <= 0) {
        //    time = 3;
        //    print("hello");
        //}
    }

    IEnumerator timer(float time) {
        while (true) {
            yield return new WaitForSeconds(time);
            print("tick");
        }
        //yield return null;
    }

    IEnumerator storytime() {
        print("hello there");
        yield return new WaitForSeconds(1);
        print("general kenobi");
        yield return new WaitForSeconds(1);
        print("*woosh*");
        yield return new WaitForSeconds(1);

        StopCoroutine(timerCoroutine);
        yield return null;
    }

    IEnumerator waitAction() {
        yield return new WaitUntil(() => go);
        print("go");
        yield return null;
    }
}
