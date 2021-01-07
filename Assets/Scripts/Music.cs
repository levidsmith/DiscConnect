//2020 Levi D. Smith
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {
    public AudioSource MusicTitle;
    public AudioSource MusicOptions;
    public AudioSource MusicTheme;
    public AudioSource MusicFanfare;
    public AudioSource MusicGameover;

    bool isPlayingFanfare = false;

    void Start() {
        
    }

    void Update() {
        if (!MusicFanfare.isPlaying && isPlayingFanfare) {
            isPlayingFanfare = false;
            MusicGameover.Play();

        }
        
    }

    public void StopAllAndPlay(AudioSource audiosource) {
        MusicTitle.Stop();
        MusicOptions.Stop();
        MusicTheme.Stop();
        MusicFanfare.Stop();
        MusicGameover.Stop();

        audiosource.Play();

        if (audiosource == MusicFanfare) {
            isPlayingFanfare = true;
        }
    }
}