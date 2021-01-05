//2020 Levi D. Smith
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnSelect : MonoBehaviour {

//    public List<Material> materials;
    public int iCol;
    public Board board;
    public GameManager gamemanager;
    

    void Start() {
        
    }

    void Update() {
        
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
        transform.position = new Vector3(iCol, iMaxRows + 1f, 0f);

    }
}