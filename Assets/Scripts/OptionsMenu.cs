//2020 Levi D. Smith
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour {

    public Text TextRowsValue;
    public Text TextColsValue;
    public Text TextToWinValue;

    public Toggle ToggleIsHumanPlayerOne;
    public Toggle ToggleIsHumanPlayerTwo;

    public Dropdown DropdownColorPlayerOne;
    public Dropdown DropdownColorPlayerTwo;

    const int ROWS_MIN = 4;
    const int ROWS_MAX = 7;
    const int COLS_MIN = 4;
    const int COLS_MAX = 14;
    const int TO_WIN_MIN = 4;
    const int TO_WIN_MAX = 8;

    public Music music;

    void Start() {
        updateDisplay();
        music.StopAllAndPlay(music.MusicOptions);

    }

    void Update() {
        
    }

    public void doRowsIncr() {
        Options.ROWS++;
        if (Options.ROWS > ROWS_MAX) {
            Options.ROWS = ROWS_MAX;
        }
        updateDisplay();

    }

    public void doRowsDecr() {
        Options.ROWS--;
        if (Options.ROWS < ROWS_MIN) {
            Options.ROWS = ROWS_MIN;
        }
        updateDisplay();
    }

    public void doColsIncr() {
        Options.COLS++;
        if (Options.COLS > COLS_MAX) {
            Options.COLS = COLS_MAX;
        }
        updateDisplay();

    }

    public void doColsDecr() {
        Options.COLS--;
        if (Options.COLS < COLS_MIN) {
            Options.COLS = COLS_MIN;
        }
        updateDisplay();
    }


    public void doToWinIncr() {
        Options.TO_WIN++;
        if (Options.TO_WIN > TO_WIN_MAX) {
            Options.TO_WIN = TO_WIN_MAX;
        }
        updateDisplay();

    }

    public void doToWinDecr() {
        Options.TO_WIN--;
        if (Options.TO_WIN < TO_WIN_MIN) {
            Options.TO_WIN = TO_WIN_MIN;
        }
        updateDisplay();
    }


    private void updateDisplay() {
        TextRowsValue.text = Options.ROWS.ToString();
        TextColsValue.text = Options.COLS.ToString();
        TextToWinValue.text = Options.TO_WIN.ToString();

    }

    private void setColorOptions() {
        switch (DropdownColorPlayerOne.value) {
            case 0:
                Options.colorPlayerOne = Color.red;
                break;
            case 1:
                Options.colorPlayerOne = new Color(1f, 0.5f, 0f);
                break;
            case 2:
                Options.colorPlayerOne = Color.yellow;
                break;
            case 3:
                Options.colorPlayerOne = Color.green;
                break;
            case 4:
                Options.colorPlayerOne = Color.cyan;
                break;
            case 5:
                Options.colorPlayerOne = Color.blue;
                break;
            case 6:
                Options.colorPlayerOne = new Color(0.5f, 0f, 1f);
                break;
        }

        switch (DropdownColorPlayerTwo.value) {
            case 0:
                Options.colorPlayerTwo = Color.red;
                break;
            case 1:
                Options.colorPlayerTwo = new Color(1f, 0.5f, 0f);
                break;
            case 2:
                Options.colorPlayerTwo = Color.yellow;
                break;
            case 3:
                Options.colorPlayerTwo = Color.green;
                break;
            case 4:
                Options.colorPlayerTwo = Color.cyan;
                break;
            case 5:
                Options.colorPlayerTwo = Color.blue;
                break;
            case 6:
                Options.colorPlayerTwo = new Color(0.5f, 0f, 1f);
                break;
        }



    }

    public void doStart() {
        Options.isHumanPlayerOne = ToggleIsHumanPlayerOne.isOn;
        Options.isHumanPlayerTwo = ToggleIsHumanPlayerTwo.isOn;

        setColorOptions();

        SceneManager.LoadScene("game");
    }
}