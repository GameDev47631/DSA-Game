using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LR_LineController : MonoBehaviour {
    /* https://youtu.be/5ZBynjAsfwI?t=75 */

    private LineRenderer lr;
    private Transform[] vertices;

    // Start is called before the first frame update
    void Start() {
        
    }

    private void Awake() {
        lr = GetComponent<LineRenderer>();
    }

    public void SetUpPath(Transform[] vertices) {
        lr.positionCount = vertices.Length;
        this.vertices = vertices;
    }

    // Update is called once per frame
    void Update() {
        for (int i = 0; i < vertices.Length; i++) {
            lr.SetPosition(i, vertices[i].position);
        }
    }
}
