//2020 Levi D. Smith
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public GameObject DiscPrefab;
    public List<Disc> discs;
    public string strName;
    public bool isHumanControlled;
    public int iPlayerIndex;

    public GameManager gamemanager;

    void Start() {
        //setupPlayer();
        
    }

    void Update() {
        if (!gamemanager.isGameOver && gamemanager.currentPlayer == this && !gamemanager.board.isDiscMoving()) {
            if (isHumanControlled) {
                handleInput();
            } else {
                handleInputAI();
            }
        }
        
    }

    private void handleInput() {
        //handle input through the OnMouseDown of ColumnSelect
        //        if (Input.GetMouseButtonDown(0)) {
        gamemanager.board.unhoverAll();


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycasthit;

        Physics.Raycast(ray, out raycasthit);
        if (raycasthit.collider != null) {
            ColumnSelect columnselect = raycasthit.collider.GetComponent<ColumnSelect>();
            if (columnselect != null) {
                if (Input.GetMouseButtonDown(0)) {
                    gamemanager.playColumn(columnselect.iCol);
                } else {
                    columnselect.setHovered(true, gamemanager.matDiscs[iPlayerIndex]);
                }


            }

            LightSwitch lightswitch = raycasthit.collider.GetComponent<LightSwitch>();
            if (lightswitch != null && Input.GetMouseButtonDown(0)) {
                Debug.Log("lightswitch clicked");
                lightswitch.toggleLights();

            }

            SwitchDoorbell switchdoorbell = raycasthit.collider.GetComponent<SwitchDoorbell>();
            if (switchdoorbell != null && Input.GetMouseButtonDown(0)) {
                Debug.Log("doorbell pressed");
                switchdoorbell.playDoorbell();

            }

            Painting painting = raycasthit.collider.GetComponent<Painting>();
            if (painting != null && Input.GetMouseButtonDown(0)) {
                painting.doChangePainting();
            }


        }

    }

    private void handleInputAI() {
        //int iRandCol = Random.Range(0, gamemanager.board.getCols() + 1);
        //gamemanager.playColumn(iRandCol);
        int i;
        string strWeights = "";
        List<int> listWeights = gamemanager.board.getColumnOutcomeWeights(this);
        int iBestValue = -1;
        i = 0;
        foreach (int iValue in listWeights) {
            //            strWeights += i + ": " + iValue + ", ";
            strWeights += iValue + ", ";
            if (iValue > iBestValue) {
                iBestValue = iValue;
            }
            i++;
        }
        //Debug.Log("Weights: " + strWeights);

        List<int> listBestColumns = new List<int>();

        for (i = 0; i < listWeights.Count; i++) {
            if (listWeights[i] == iBestValue) {
                listBestColumns.Add(i);
            }

        }

        string strColumns = "Columns: ";
        foreach (int iValue in listBestColumns) {
            strColumns += iValue + ", ";
        }
        //Debug.Log("Best Columns: " + strColumns);

        int iPlayColumn = listBestColumns[Random.Range(0, listBestColumns.Count)];
        gamemanager.playColumn(iPlayColumn);

    }

    public void setupPlayer() {
        //int iDiscCount = 21;
        int iDiscCount = (Options.ROWS * Options.COLS) / 2;
        int i;


        for (i = 0; i < iDiscCount; i++) {
            //            Disc disc = Instantiate(DiscPrefab, transform.position + new Vector3(0f, i * 0.2f, 0f), Quaternion.identity).GetComponent<Disc>();
            Disc disc = Instantiate(DiscPrefab, transform.position + new Vector3(0f, i * 0.2f, 0f), Quaternion.Euler(90f, 0f, 0f)).GetComponent<Disc>();
            disc.player = this;
            disc.gamemanager = gamemanager;
            disc.targetPosition = disc.transform.position;
            disc.setMaterial(gamemanager.matDiscs[iPlayerIndex]);
            disc.transform.SetParent(transform);
            discs.Add(disc);
        }

    }
}