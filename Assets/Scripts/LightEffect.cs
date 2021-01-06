//2020 Levi D. Smith
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEffect : MonoBehaviour {
    public Light directionalLight;

    float fRotVelocity;
    float fRotCountdown;
    float fRotMaxCountdown;

    void Start() {
        fRotVelocity = 5f;
        fRotMaxCountdown = 10f;
        fRotCountdown = fRotMaxCountdown / 2f;
        
    }

    void Update() {
        directionalLight.gameObject.transform.Rotate(Vector3.up, fRotVelocity * Time.deltaTime);

        fRotCountdown -= Time.deltaTime;
        if (fRotCountdown <= 0f) {
            fRotCountdown += fRotMaxCountdown;
            fRotVelocity *= -1f;
        }
        
    }
}