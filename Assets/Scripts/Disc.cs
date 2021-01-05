//2020 Levi D. Smith
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disc : MonoBehaviour {

    public Vector3 targetPosition;
    public GameObject model;
    float fSpeed = 10f;
    public Player player;

    public bool isHighlighted;
    float fHighlightCountdown;
    float fMaxHighlightCountdown = 2f;
    public GameManager gamemanager;

    void Start() {
        
    }

    void Update() {
        if (transform.position != targetPosition) {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, fSpeed * Time.deltaTime);

        }

        if (isHighlighted) {
            fHighlightCountdown -= Time.deltaTime;
            if (fHighlightCountdown <= 0f) {
                fHighlightCountdown = fMaxHighlightCountdown;
            }

            if (Mathf.FloorToInt(fHighlightCountdown) % 2 == 0) {
                model.GetComponent<Renderer>().material = gamemanager.matDiscHighlight;
            } else {
                model.GetComponent<Renderer>().material = gamemanager.matDiscs[player.iPlayerIndex];

            }


        }

    }

    public void setTarget(Cell in_Cell) {

    }

    public void setMaterial(Material mat) {
        model.GetComponent<Renderer>().material = mat;

    }

    public bool isMoving() {
        bool b;
        if (transform.position != targetPosition) {
            b = true;
        } else {
            b = false;
        }

        return b;
    }

    public void setHighlighted() {
        isHighlighted = true;
        fHighlightCountdown = fMaxHighlightCountdown;
    }
}