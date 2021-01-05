//2020 Levi D. Smith
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {
    public Disc disc;
    public int iRow;
    public int iCol;
    void Start() {
        disc = null;
        
    }

    void Update() {
        
    }

    public void updatePosition() {
        transform.position = new Vector3(iCol, iRow, 0f);
    }
}