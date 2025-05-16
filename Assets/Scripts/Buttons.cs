using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        //
    }

    // Update is called once per frame
    void Update() {
        //
    }

    public void OnMouseDown() {
        switch (gameObject.name) {
            case "CreditsButton":
                SceneManager.LoadScene("Credits");
                break;
            
            default:
                Debug.LogWarning("ID name changed!");
                break;
        }
    }
}
