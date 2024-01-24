using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
    [SerializeField] float damage = 1;
    [SerializeField] bool oneTime = true;

    private void OnTriggerEnter(Collider other) {
        if (oneTime && other.gameObject.TryGetComponent<IDamagable>(out IDamagable damagable)) {
            damagable.takeDamage(damage);
        }
    }

    private void OnTriggerStay(Collider other) {
        if (!oneTime && other.gameObject.TryGetComponent<IDamagable>(out IDamagable damagable)) {
            damagable.takeDamage(damage * Time.deltaTime);
        }
    }
}

    public interface IDamagable {
        void takeDamage(float damage);
    }
