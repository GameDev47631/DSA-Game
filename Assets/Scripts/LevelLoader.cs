using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    /* https://www.youtube.com/watch?v=CE9VOZivb3I? */
     
    public Animator transition;
    public float transitioning = 1f;
    
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        // "Clicking the button."
        if (Input.GetMouseButtonDown(0)) {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel() {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex) {
        // "Animate the scene transition."
        transition.SetTrigger("Start");

        // "Wait for the animation to finish completely."
        yield return new WaitForSeconds(transitioning);

        // "Now, you can interact with the next scene."
        SceneManager.LoadScene(levelIndex);
    }
}
