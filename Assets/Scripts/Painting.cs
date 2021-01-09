//2020 Levi D. Smith
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour {
    int iCurrent = 0;
    public List<Material> listMaterials;
    public GameObject model;
    public AudioSource SoundPainting;

    void Start() {
        
    }

    void Update() {
        
    }

    public void doChangePainting() {
        iCurrent++;
        if (iCurrent >= listMaterials.Count) {
            iCurrent = 0;
        }

        model.GetComponent<Renderer>().material = listMaterials[iCurrent];
        SoundPainting.Play();
    }
}