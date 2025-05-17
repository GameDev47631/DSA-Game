using System.Collections;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    public TextMeshProUGUI gameTitle, shortText;
    private readonly Coroutine noShortText;
    public GameObject playButton, creditsButton;

    public float delay = 5f, fade = 1f;
    private bool screenClicked = false;
    

    void Start() {
        gameTitle.gameObject.SetActive(true);

        if (shortText != null) {
            Color c = shortText.color;
            c.a = 0f;
            shortText.color = c;
            shortText.gameObject.SetActive(false);
            StartCoroutine(FadeIn());
        }

        playButton?.gameObject.SetActive(false);
        creditsButton?.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0) && !screenClicked) {
            screenClicked = true;
    
            // Stop text reveal coroutine if it's still running
            if (noShortText != null) {
                StopCoroutine(noShortText);
            }

            LoadMainMenu();
        }
    }

    IEnumerator FadeIn() {
        // "A text will appear if the title screen isn't already clicked."
        yield return new WaitForSeconds(delay);

        if (screenClicked) yield break;
        
        shortText.gameObject.SetActive(true);

        float elapsed = 0f;
        Color originalColor = shortText.color;

        while (elapsed < fade) {
            if (screenClicked) yield break;
            float alpha = Mathf.Clamp01(elapsed / fade);
            shortText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsed += Time.deltaTime;
            yield return null;
        }

        shortText.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f);
    }

    IEnumerator FadeOut() {
        float elapsed = 0f;
        Color originalColor = gameTitle.color;

        while (elapsed < fade) {
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fade);
            gameTitle.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsed += Time.deltaTime;
            yield return null;
        }

        gameTitle.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        gameTitle.gameObject.SetActive(false);
    }

    public void LoadMainMenu() {
        /* gameTitle.gameObject.SetActive(false); */
        StartCoroutine(FadeOut());

        shortText.gameObject.SetActive(false);

        playButton.gameObject.SetActive(true);
        creditsButton.gameObject.SetActive(true);
    }
}