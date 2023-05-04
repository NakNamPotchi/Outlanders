using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinCheckerManager : Singleton<CoinCheckerManager>
{
    [SerializeField] private GameObject insufficientCoinPanel;
    [SerializeField] private TextMeshProUGUI insufficientCoinText;

    private float fadeDuration = 1f;
    private bool isFading = false;

    public void Start()
    {
        insufficientCoinPanel.SetActive(false);
    }

    public void ShowMessage()
    {
        if (!isFading)
        {
            isFading = true;
            StartCoroutine(ExecuteMessageFadeIn(0.1f));
        }
    }

    IEnumerator ExecuteMessageFadeIn(float time)
    {
        yield return new WaitForSeconds(time);
        AudioManager.Instance.PlaySound("NotEnoughCoin");
        insufficientCoinText.color = new Color(insufficientCoinText.color.r, insufficientCoinText.color.g, insufficientCoinText.color.b, 0);

        float timeElapsed = 0;
        insufficientCoinPanel.SetActive(true);

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            insufficientCoinText.color = new Color(insufficientCoinText.color.r, insufficientCoinText.color.g, insufficientCoinText.color.b, alpha);
            yield return null;
        }

        StartCoroutine(ExecuteMessageFadeOut(1f));
    }

    IEnumerator ExecuteMessageFadeOut(float time)
    {
        yield return new WaitForSeconds(time);

        insufficientCoinText.color = new Color(insufficientCoinText.color.r, insufficientCoinText.color.g, insufficientCoinText.color.b, 1);
        float timeElapsed = 0;
        float startAlpha = 1f; 
        float targetAlpha = 0f; 

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, timeElapsed / fadeDuration);
            insufficientCoinText.color = new Color(insufficientCoinText.color.r, insufficientCoinText.color.g, insufficientCoinText.color.b, alpha);
            yield return null;
        }

        insufficientCoinPanel.SetActive(false);
        isFading = false;
    }
}
