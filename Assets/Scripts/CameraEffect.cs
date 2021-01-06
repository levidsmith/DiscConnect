//2020 Levi D. Smith
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffect : MonoBehaviour {

    public Camera theCamera;
    float fRotVelocity;
    float fRotCountdown;

    void Start() {
        fRotVelocity = 10f;
        fRotCountdown = 5f;
        
    }

    void Update() {
//        theCamera.gameObject.transform.Rotate(Vector3.up, fRotVelocity * Time.deltaTime);

        
    }
}