using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class youcannowescapethedeathscreen : MonoBehaviour
{
    public CanvasGroup fadeCanvas;
    public float fadeDuration = 2.0f;
    public string SceneChange;

    void Start()
    {
        fadeCanvas.alpha = 0f;

        Invoke("StartFade", 5f);
    }

    void StartFade()
    {
        StartCoroutine(FadeToBlack());
    }

    IEnumerator FadeToBlack()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);

            fadeCanvas.alpha = alpha;

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        fadeCanvas.alpha = 1f;

        ChangeScene();
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(SceneChange);
    }
}