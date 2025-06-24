using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {
    /* https://youtu.be/5ZBynjAsfwI?t=169 */

    [SerializeField] private Transform[] vertices;
    [SerializeField] private LR_LineController path;
    
    // Start is called before the first frame update
    void Start() {
        path.SetUpPath(vertices);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
