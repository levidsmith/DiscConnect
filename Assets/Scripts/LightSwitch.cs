//2020 Levi D. Smith
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour {

    bool isLightsOn;
    Color colorDefaultSky;
    Color colorDefaultEquator;
    Color colorDefaultGround;
    public Light DirectionalLight;
    public Light SwitchLight;
    public GameObject SpotLights;
    public Light SpotLight1;
    public Light SpotLight2;
    public AudioSource SoundLightSwitch;

    void Start() {
        isLightsOn = true;
        colorDefaultSky = RenderSettings.ambientSkyColor;
        colorDefaultEquator = RenderSettings.ambientEquatorColor;
        colorDefaultGround = RenderSettings.ambientGroundColor;


    }

    void Update() {
        if (!isLightsOn) {
            float fRotateSpeed = 45f;
            SpotLights.transform.Rotate(Vector3.forward, fRotateSpeed * Time.deltaTime);
        }
        
    }

    public void toggleLights() {
        Debug.Log("toggle lights");
        isLightsOn = !isLightsOn;
        updateLights();

    }

    private void updateLights() {
        if (isLightsOn) {
            //RenderSettings.ambientLight = new Color(170, 198, 255);
            RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Trilight;

            RenderSettings.ambientSkyColor = colorDefaultSky;
            RenderSettings.ambientEquatorColor = colorDefaultEquator;
            RenderSettings.ambientGroundColor = colorDefaultGround;
            DirectionalLight.enabled = true;
            SwitchLight.enabled = false;
            SpotLight1.enabled = false;
            SpotLight2.enabled = false;
            SoundLightSwitch.Play();

        } else {
            //RenderSettings.ambientLight = Color.black;
            RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
            RenderSettings.ambientLight = Color.black;
            RenderSettings.ambientSkyColor = Color.black;
            RenderSettings.ambientEquatorColor = Color.black;
            RenderSettings.ambientGroundColor = Color.black;
            DirectionalLight.enabled = false;
            SwitchLight.enabled = true;
            SpotLight1.enabled = true;
            SpotLight2.enabled = true;
            SoundLightSwitch.Play();

        }

    }
}