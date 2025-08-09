using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DijkstraGameplay : MonoBehaviour {

    [SerializeField] GameObject[] Crosshairs;
    [SerializeField] NeighboringNodes[] Pathways;

    private int currentNode = 0;

    // Start is called before the first frame update
    void Start() {
        // "The number of crosshairs will depend on how many nodes there are."
        if (Crosshairs.Length > 0) {
            for (int i = 0; i < Crosshairs.Length; i++) {
                Crosshairs[i].SetActive(i == currentNode);
            }
        }

        HidePaths();
        ShowPaths(currentNode);
    }

    // Update is called once per frame
    void Update() {
        /* "Use the arrow keys to select the current node." */
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            Selection(-1);
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            Selection(1);
        }

        // if (Input.GetKeyDown(KeyCode.UpArrow)) {
        //     ToggleActiveState(true);
        // } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
        //     ToggleActiveState(false);
        // }

    }

    void Selection(int direction) {
        if (Crosshairs.Length == 0) {
            return;
        }

        /* "This code caused a wrap around selection." */
        // currentNode += direction;
        // if (currentNode < 0) {
        //     currentNode = Crosshairs.Length - 1;
        // } else if (currentNode >= Crosshairs.Length) {
        //     currentNode = 0;
        // }

        int nextNode = currentNode + direction;

        /* "Node selections no longer wrap around."*/
        if (nextNode < 0 || nextNode >= Crosshairs.Length) {
            return;
        }

        Crosshairs[currentNode].SetActive(false);
        HidePaths();

        currentNode = nextNode;

        Crosshairs[currentNode].SetActive(true);
        ShowPaths(currentNode);
    }

    // void ToggleActiveState(bool active) {
    //     if (Crosshairs.Length == 0) {
    //         return;
    //     }
    //
    //     Crosshairs[currentNode].SetActive(active);
    // }

    void HidePaths() {
        foreach (var node in Pathways) {
            foreach (var lineRenderer in node.paths) {
                lineRenderer.enabled = false;
            }
        }
    }

    void ShowPaths(int nodeIndex) {
        foreach (var lineRenderer in Pathways[nodeIndex].paths) {
            lineRenderer.enabled = true;
        }
    }
}

[System.Serializable]
public class NeighboringNodes {
    public GameObject node;
    public List<LineRenderer> paths;
}