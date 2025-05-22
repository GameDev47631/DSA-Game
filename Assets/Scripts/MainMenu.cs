using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    /* https://www.youtube.com/watch?v=-GWjA6dixV4 */

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void Play() {
        SceneManager.LoadScene("LevelSelect");
    }

    public void Settings() {
        SceneManager.LoadScene("Settings");
    }

    public void Credits() {
        SceneManager.LoadScene("Credits");
    }

    public void Quit() {
        Application.Quit();
    }
}