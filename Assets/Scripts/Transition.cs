using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour {
    /* https://www.youtube.com/watch?v=CE9VOZivb3I? */

    public Animator transition;
    public float transitioning = 1f;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    // public void LoadNextScene() {
    //     StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    // }

    public void LoadSceneByName(string sceneName) {
        StartCoroutine(Loading(sceneName.ToString()));
    }

    IEnumerator Loading(string sceneName) {
        // "Animate the scene transition."
        transition.SetTrigger("Start");

        // "Wait for the animation to finish completely."
        yield return new WaitForSeconds(transitioning);

        // "Now, you can interact with the next scene."
        SceneManager.LoadScene(sceneName);
    }

    // "The 'Quit()' method was originally created in the 'MainMenu' script."
    public void Quit() {
        StartCoroutine(QuitAfterTransition());
    }

    IEnumerator QuitAfterTransition() {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitioning);

        #if UNITY_STANDALONE
            Application.Quit();
        #endif

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
