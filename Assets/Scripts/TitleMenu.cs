//2020 Levi D. Smith
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour {
    public Music music;
    void Start() {
        music.StopAllAndPlay(music.MusicTitle);

        
    }

    void Update() {
        
    }

    public void doStart() {
        SceneManager.LoadScene("options");

    }

    public void doQuit() {
        Application.Quit();
    }
}