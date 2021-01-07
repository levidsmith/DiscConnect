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



    public void doStart() {
        SceneManager.LoadScene("game");
    }
}