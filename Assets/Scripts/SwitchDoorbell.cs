//2020 Levi D. Smith
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDoorbell : MonoBehaviour {
    public List<AudioSource> listDoorbells;
    void Start() {
        
    }

    void Update() {
        
    }

    public void playDoorbell() {
        Debug.Log("Play doorbell");
        int iRand = Random.Range(0, listDoorbells.Count);
        listDoorbells[iRand].Play();

    }
}