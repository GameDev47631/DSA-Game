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

    public void TitleScreen() {
        SceneManager.LoadScene("MainMenu");
    }

    public void Play() {
        SceneManager.LoadScene("LevelSelect");
    }

    // public void Settings() {
    //     SceneManager.LoadScene("Settings");
    // }

    public void Credits() {
        SceneManager.LoadScene("Credits");
    }

    public void Quit() {
        /* https://stackoverflow.com/questions/70437401/cannot-finish-the-game-in-unity-using-application-quit
         * "This whole code will get the 'Quit' button to work in the Unity Editor." */
        #if UNITY_STANDALONE
            /* "This line by itself only works in a build." */
            Application.Quit();
        #endif
        
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}