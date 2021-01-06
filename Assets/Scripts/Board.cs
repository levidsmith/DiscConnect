//2020 Levi D. Smith
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    public GameObject CellPrefab;
    public GameObject ColumnSelectPrefab;

    public List<Cell> cells;

    int iConnectToWin;
    public GameManager gamemanager;

    void Start() {
        //cells = new List<Cell>();
        
    }

    void Update() {
        
    }

    public void setupBoard(int iRows, int iCols, int in_ConnectToWin) {
        int i, j;

        for (i = 0; i < iRows; i++) {
            for (j = 0; j < iCols; j++) {
                Cell cell = Instantiate(CellPrefab, Vector3.zero, Quaternion.identity).GetComponent<Cell>();
                cell.iRow = i;
                cell.iCol = j;
                cell.updatePosition();
                cell.transform.SetParent(transform);
                cells.Add(cell);

            }
        }


        for (j = 0; j < iCols; j++) {
            ColumnSelect columnselect = Instantiate(ColumnSelectPrefab, Vector3.zero, Quaternion.identity).GetComponent<ColumnSelect>();
            columnselect.iCol = j;
            columnselect.transform.SetParent(transform);
            columnselect.board = this;
            columnselect.gamemanager = gamemanager;
            columnselect.updatePosition();

            
        }


        iConnectToWin = in_ConnectToWin;



    }

    public void addDisc(Disc in_Disc, int iCol) {

    }

    public int getRows() {
        int iMaxRows = 0;

        foreach (Cell cell in cells) {
            if (cell.iRow > iMaxRows) {
                iMaxRows = cell.iRow;
            }
        }


        return iMaxRows + 1;
    }

    public int getCols() {
        int iMaxCols = 0;

        foreach (Cell cell in cells) {
            if (cell.iCol > iMaxCols) {
                iMaxCols = cell.iCol;
            }
        }

        return iMaxCols + 1;

    }

    public Cell getDroppedCell(int iCol) {
        Cell cellReturn = null;
        int i;

        i = getRows() - 1;
//        Debug.Log("i: " + i);
        while ((cellReturn == null) && (i >= 0)) {
//            Debug.Log("Checking: " + i + ", " + iCol);
            Cell cell = getCell(i, iCol);
            Cell cellNext = getCell(i - 1, iCol);

//            Debug.Log("cell: " + cell + " cellNext: " + cellNext);
//            if (cellNext != null) {
//                Debug.Log("cellNext.disc: " + cellNext.disc);
//            }
            if (cell.disc == null) {
                if (cellNext == null || cellNext.disc != null) {
                    cellReturn = cell;
                }
            }

            i--;
        }

        return cellReturn;
    }

    public Cell getCell(int iRow, int iCol) {
        Cell cellReturn = null;
        foreach (Cell cell in cells) {
            if (cell.iRow == iRow && cell.iCol == iCol) {
                cellReturn = cell;
            }
        }

        return cellReturn;


    }

    public bool isDiscMoving() {
        bool b;

        b = false;
        foreach (Cell cell in cells) {
            if (cell.disc != null && cell.disc.isMoving()) {
                b = true;
            }
        }

        return b;

    }


    public Player checkWinner() {
        Player playerWin = null;

        foreach (Cell cell in cells) {
            if (cell.disc != null && cell.disc.player == gamemanager.currentPlayer) {
                //left to right
                if (checkWinnerSequence(cell, 0, 1, gamemanager.currentPlayer)) {
                    playerWin = cell.disc.player;
                    highlightSequence(cell, 0, 1);
                }

                //right to left
                if (checkWinnerSequence(cell, 0, -1, gamemanager.currentPlayer)) {
                    playerWin = cell.disc.player;
                    highlightSequence(cell, 0, -1);
                }

                //down to up
                if (checkWinnerSequence(cell, 1, 0, gamemanager.currentPlayer)) {
                    playerWin = cell.disc.player;
                    highlightSequence(cell, 1, 0);
                }

                //up to down
                if (checkWinnerSequence(cell, -1, 0, gamemanager.currentPlayer)) {
                    playerWin = cell.disc.player;
                    highlightSequence(cell, -1, 0);
                }

                //diagonals
                if (checkWinnerSequence(cell, -1, -1, gamemanager.currentPlayer)) {
                    playerWin = cell.disc.player;
                    highlightSequence(cell, -1, -1);
                }

                if (checkWinnerSequence(cell, -1, 1, gamemanager.currentPlayer)) {
                    playerWin = cell.disc.player;
                    highlightSequence(cell, -1, 1);
                }

                if (checkWinnerSequence(cell, 1, -1, gamemanager.currentPlayer)) {
                    playerWin = cell.disc.player;
                    highlightSequence(cell, 1, -1);
                }

                if (checkWinnerSequence(cell, 1, 1, gamemanager.currentPlayer)) {
                    playerWin = cell.disc.player;
                    highlightSequence(cell, 1, 1);
                }



            }
        }

        return playerWin;

    }

    private bool checkWinnerSequence(Cell cell, int iRowIncr, int iColIncr, Player inPlayer) {
        bool hasWon;
        int i;


        i = 1;
        hasWon = true;
        while (i < iConnectToWin) {
            Cell cellCheck = getCell(cell.iRow + (i * iRowIncr), cell.iCol + (i * iColIncr));

            if (cellCheck == null) {
                hasWon = false;
            } else if (cellCheck.disc == null) {
                hasWon = false;
            } else if (cellCheck.disc.player != inPlayer) {
                hasWon = false;
            }

            i++;


        }

        return hasWon;
    }

    private void highlightSequence(Cell cell, int iRowIncr, int iColIncr) {
        int i;
        i = 0;
        while (i < iConnectToWin) {
            Cell cellCheck = getCell(cell.iRow + (i * iRowIncr), cell.iCol + (i * iColIncr));
            cellCheck.disc.setHighlighted();
            i++;
        }

    }


    public List<int> getColumnOutcomeWeights(Player p) {
        List<int> listWeights = new List<int>();
        int j;
        int iBestScore;

        Debug.Log("cols: " + getCols());
        //check winning move
        for (j = 0; j < getCols(); j++) {
            int iColumnWeight = getColumnWeight(getDroppedCell(j), p);
            listWeights.Add(iColumnWeight);

        }

        return listWeights;

    }

    private int getColumnWeight(Cell cell, Player p) {
        int iWeight;
        iWeight = 0;

        //check for vertical win
        if (cell != null) {
            int i;
            for (i = cell.iRow; i > cell.iRow - iConnectToWin; i--) {
                if (i >= 0) {
                    Cell cellCheck = getCell(i, cell.iCol);
                    if (cellCheck == null) {
                        break;
                    } else if (cellCheck.disc != null && cellCheck.disc.player != p) {
                        break;
                    } else if (cellCheck.disc != null && cellCheck.disc.player == p) {
                        iWeight++;

                    }
                }
            }
        }

        //check for vertical loss on next player turn
        if (cell != null) {
            int i;
            if (checkWinnerSequence(cell, 0, 1, gamemanager.getIdlePlayer()) ||
                checkWinnerSequence(cell, 0, -1, gamemanager.getIdlePlayer()) ||
                checkWinnerSequence(cell, 1, 0, gamemanager.getIdlePlayer()) ||
                checkWinnerSequence(cell, -1, 0, gamemanager.getIdlePlayer()) ||
                checkWinnerSequence(cell, 1, 1, gamemanager.getIdlePlayer()) ||
                checkWinnerSequence(cell, -1, 1, gamemanager.getIdlePlayer()) ||
                checkWinnerSequence(cell, 1, -1, gamemanager.getIdlePlayer()) ||
                checkWinnerSequence(cell, -1, -1, gamemanager.getIdlePlayer())
                ) {
                iWeight = iConnectToWin;
            }
        }


        return iWeight;
    }


    private int getDiscCount() {
        int iCount;
        iCount = 0;

        foreach (Cell cell in cells) {
            if (cell.disc != null) {
                iCount++;
            }
        }

        return iCount;
    }


}