using System.Collections;
using TMPro;
using UnityEngine;

public class TextProperties : MonoBehaviour {
    public TextMeshProUGUI additionalText;
    public float delay = 5f;
    public float fade = 1f;

    void Start() {
        if (additionalText != null) {
            // Set initial alpha to 0 (fully transparent)
            Color c = additionalText.color;
            c.a = 0f;
            additionalText.color = c;
            additionalText.gameObject.SetActive(false); // Activate so we can fade
            StartCoroutine(RevealText());
        }
    }

    IEnumerator RevealText() {
        yield return new WaitForSeconds(delay);

        additionalText.gameObject.SetActive(true);

        float elapsed = 0f;
        Color originalColor = additionalText.color;

        while (elapsed < fade) {
            float alpha = Mathf.Clamp01(elapsed / fade);
            additionalText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure final alpha is 1 (fully visible)
        additionalText.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f);
    }
}