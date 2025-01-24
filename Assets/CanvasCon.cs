using UnityEngine;

public class CanvasCon : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private float fadeDuration =0.8f;
    private float delay = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.interactable = false;
        canvasGroup.alpha = 0;
        StartCoroutine(FadeIn());

    }
    private System.Collections.IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(delay);
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
    }
}
