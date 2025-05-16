using System.Collections;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    public GameObject gameTitle;
    public TextMeshProUGUI shortText;
    private Coroutine noShortText;
    public GameObject creditsIcon;

    public float delay = 5f, fade = 1f;
    private bool screenClicked = false;
    

    void Start() {
        gameTitle.gameObject.SetActive(true);

        if (shortText != null) {
            Color c = shortText.color;
            c.a = 0f;
            shortText.color = c;
            shortText.gameObject.SetActive(false);
            StartCoroutine(RevealText());
        }

        if (creditsIcon != null) {
            creditsIcon.gameObject.SetActive(false);
        }
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

    IEnumerator RevealText() {
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

    public void LoadMainMenu() {
        gameTitle.gameObject.SetActive(false);
        shortText.gameObject.SetActive(false);

        creditsIcon.gameObject.SetActive(true);
    }
}