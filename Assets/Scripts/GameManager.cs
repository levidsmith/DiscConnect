﻿//2020 Levi D. Smith
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject BoardPrefab;
    public GameObject PlayerPrefab;
    public Board board;

    List<Player> players;
    public Player currentPlayer;

    public List<Material> matDiscs;
    public Material matDiscHighlight;

    public bool isGameOver;
    

    void Start() {
        setupGame();
        
    }

    void Update() {
        
    }

    private void setupGame() {


        board = Instantiate(BoardPrefab, Vector3.zero, Quaternion.identity).GetComponent<Board>();
        board.gamemanager = this;
        board.setupBoard(6, 7, 4);

        players = new List<Player>();
        Player player;
        Vector3 pos;

        pos = new Vector3(-2f, 0f, 0f);
        player = Instantiate(PlayerPrefab, pos, Quaternion.identity).GetComponent<Player>();
        player.strName = "Player One";
        player.gamemanager = this;
        player.iPlayerIndex = 0;
        player.isHumanControlled = true;
        player.setupPlayer();
        players.Add(player);

        pos = new Vector3(9f, 0f, 0f);
        player = Instantiate(PlayerPrefab, pos, Quaternion.identity).GetComponent<Player>();
        player.strName = "Player Two";
        player.gamemanager = this;
        player.iPlayerIndex = 1;
        player.isHumanControlled = false;
        player.setupPlayer();
        players.Add(player);

        currentPlayer = players[0];
        isGameOver = false;
        
    }

    public void nextPlayer() {
        int iCurrentPlayer;

        iCurrentPlayer = players.IndexOf(currentPlayer);
        iCurrentPlayer++;
        if (iCurrentPlayer > players.Count - 1) {
            iCurrentPlayer = 0;
        }

        currentPlayer = players[iCurrentPlayer];
    }

    public void playColumn(int iCol) {
        Cell targetCell = board.getDroppedCell(iCol);
        if (targetCell != null) {
//            Debug.Log("targetCell: " + targetCell.iRow + ", " + targetCell.iCol);
            int iDisc = currentPlayer.discs.Count - 1;

            if (currentPlayer.discs.Count > 0) {
                targetCell.disc = currentPlayer.discs[iDisc];
                targetCell.disc.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                targetCell.disc.transform.position = new Vector3(iCol, board.getRows() + 1, 0f);
                currentPlayer.discs.RemoveAt(iDisc);
                targetCell.disc.targetPosition = targetCell.transform.position;

                Player playerWin = board.checkWinner(targetCell);
                if (playerWin != null) {
                    Debug.Log(playerWin.strName + " Wins!");
                    isGameOver = true;
                } else {
                    nextPlayer();
                }
            }
        }
    }

    public void doRestart() {
        removeAll();
        setupGame();
    }

    private void removeAll() {
        Destroy(board.gameObject);
        foreach (Player player in players) {
            Destroy(player.gameObject);
        }
    }





}