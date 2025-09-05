using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DijkstraGameplay : MonoBehaviour {

    [SerializeField] GameObject[] Crosshairs;
    [SerializeField] NeighboringNodes[] Pathways;

    private int currentNode, nextNode;

    // Start is called before the first frame update
    void Start() {
        /* "The number of crosshairs will depend on how many nodes there are." */
        // if (Crosshairs.Length > 0) {
        //     for (int i = 0; i < Crosshairs.Length; i++) {
        //         Crosshairs[i].SetActive(i == currentNode);
        //     }
        // }

        HidePaths();
        ShowPaths(currentNode);
    }

    // Update is called once per frame
    void Update() {
        /* "Use the arrow keys to select the current node." */
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            Options(-1);
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            Options(1);
        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            Selection(currentNode);
            Debug.Log("Selected Node: " + currentNode);
        }
    }

    void Selection(int nodeIndex) {
        if (Crosshairs.Length == 0) {
            return;
        }

        /* "This code caused a wraparound selection." */
        // currentNode += direction;
        // if (currentNode < 0) {
        //     currentNode = Crosshairs.Length - 1;
        // } else if (currentNode >= Crosshairs.Length) {
        //     currentNode = 0;
        // }

        /* "This code prevented said wraparound.
            It is now redirected the 'Options()' method." */
        // int nextNode = currentNode + direction;
        // if (nextNode < 0 || nextNode >= Crosshairs.Length - 1) {
        //     return;
        // }

        // Crosshairs[currentNode].SetActive(false);
        // HidePaths();

        // currentNode = nextNode;

        // Crosshairs[currentNode].SetActive(true);
        ShowPaths(nodeIndex);
    }

    void Options(int direction) {
        nextNode = currentNode + direction;
        if (nextNode < 0 || nextNode >= Crosshairs.Length) {
            return;
        }
        
        currentNode = nextNode;

        ShowPaths(currentNode);
    }

    void HidePaths() {
        foreach (var node in Pathways) {
            foreach (var lineRenderer in node.paths) {
                lineRenderer.enabled = false;
            }
        }

        foreach (var ch in Crosshairs) {
            ch.SetActive(false);
        }
    }

    void ShowPaths(int nodeIndex) {
        foreach (var ch in Crosshairs) {
            ch.SetActive(false);
        }

        Crosshairs[nodeIndex].SetActive(true);

        foreach (var lineRenderer in Pathways[nodeIndex].paths) {
            lineRenderer.enabled = true;
        }

        foreach (var neighborIndex in Pathways[nodeIndex].neighbors) {
            neighborIndex.SetActive(true);
        }
    }
}

[System.Serializable]
public class NeighboringNodes {
    public GameObject node;
    public List<LineRenderer> paths;
    public List<GameObject> neighbors;
}