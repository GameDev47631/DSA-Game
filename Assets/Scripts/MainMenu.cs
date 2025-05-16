using System.Collections;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    public GameObject gameTitle;
    public TextMeshProUGUI additionalText;
    public GameObject creditsIcon, creditsList;

    public float delay = 5f, fade = 1f;
    

    void Start() {
        if (additionalText != null) {
            Color c = additionalText.color;
            c.a = 0f;
            additionalText.color = c;
            additionalText.gameObject.SetActive(false);
            StartCoroutine(RevealText());
        }

        if (creditsIcon != null) {
            creditsIcon.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            LoadMainMenu();
        }
    }

    IEnumerator RevealText() {
        // "A text will appear if the title screen isn't already clicked."
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

        additionalText.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f);
    }

    public void LoadMainMenu() {
        gameTitle.gameObject.SetActive(false);
        additionalText.gameObject.SetActive(false);

        creditsIcon.gameObject.SetActive(true);
    }
}