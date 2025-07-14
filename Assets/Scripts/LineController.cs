using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LR_LineController : MonoBehaviour {
    /* https://www.youtube.com/watch?v=RMM3BAick4I */

    [SerializeField] private float animating = 5f;
    private LineRenderer lineRenderer;
    
    // Start is called before the first frame update
    void Start() {
        lineRenderer = GetComponent<LineRenderer>();

        StartCoroutine(AnimateLine());
    }

    // Update is called once per frame
    void Update() {
        
    }

    private IEnumerator AnimateLine() {
        float start = Time.time;

        Vector3 startPoint = lineRenderer.GetPosition(0);
        Vector3 endPoint = lineRenderer.GetPosition(1);

        Vector3 position = startPoint;
        while (position != endPoint) {
            float f = (Time.time - start) / animating;
            position = Vector3.Lerp(startPoint, endPoint, f);
            lineRenderer.SetPosition(1, position);
            yield return null;
        }
    }
}
