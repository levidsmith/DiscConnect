//2020 Levi D. Smith
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnSelect : MonoBehaviour {

//    public List<Material> materials;
    public int iCol;
    public Board board;
    public GameManager gamemanager;
    public GameObject model;
    bool isHovered;
    

    void Start() {
        isHovered = false;
        
    }

    void Update() {
        /*
        if (isHovered) {
            model.SetActive(true);
        } else {
            model.SetActive(false);
        }
        */
        
    }

    /*
    private void OnMouseDown() {
        Debug.Log("Column select: " + iCol);
        if (gamemanager.currentPlayer.isHumanControlled) {
            gamemanager.playColumn(iCol);
        }
    }
    */

    public void updatePosition() {
        int iMaxRows = board.getRows();
        //        transform.position = new Vector3(iCol, iMaxRows, 0f);
        transform.position = new Vector3(iCol + board.getXOffset(), iMaxRows + board.getYOffset(), 0f);

    }

    public void setHovered(bool b, Material mat) {
        if (b) {
            model.GetComponent<Renderer>().material = mat;
            model.SetActive(true);
            isHovered = b;
        } else {
            model.SetActive(false);
        }
    }
}