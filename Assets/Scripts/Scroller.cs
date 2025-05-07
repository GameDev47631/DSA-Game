using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour {
    /* https://www.youtube.com/watch?v=-6H-uYh80vc */
    [SerializeField] private RawImage backgroundImage;
    [SerializeField] private float xAxis, yAxis;

   void Update() {
       backgroundImage.uvRect = new Rect(backgroundImage.uvRect.position + new Vector2(xAxis, yAxis) * Time.deltaTime, backgroundImage.uvRect.size);
   }
}
