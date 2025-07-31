using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LR_LineController : MonoBehaviour {
    /* https://www.youtube.com/watch?v=RMM3BAick4I */

    [SerializeField] private float animating = 5f;
    private LineRenderer lineRenderer;
    private Vector3[] vertices;
    private int numVertices;

    // Start is called before the first frame update
    void Start() {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.sortingOrder = -1;

        numVertices = lineRenderer.positionCount;
        vertices = new Vector3[numVertices];
        for (int i = 0; i < numVertices; i++) {
            vertices[i] = lineRenderer.GetPosition(i);
        }

        StartCoroutine(AnimateLine());
    }

    // Update is called once per frame
    void Update() {

    }

    private IEnumerator AnimateLine() {
        float segmentTime = animating / numVertices;

        for (int i = 0; i < numVertices; i++) {
            float startTime = Time.time;

            Vector3 startPoint = lineRenderer.GetPosition(0);
            Vector3 endPoint = lineRenderer.GetPosition(1);

            Vector3 position = startPoint;
            while (position != endPoint) {
                float f = (Time.time - startTime) / segmentTime;
                position = Vector3.Lerp(startPoint, endPoint, f);

                for (int j = i + 1; j < numVertices; j++) {
                    lineRenderer.SetPosition(j, position);
                }

                yield return null;
            }
        }
    }
}
