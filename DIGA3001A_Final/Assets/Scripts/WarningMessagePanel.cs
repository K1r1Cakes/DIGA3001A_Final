using UnityEngine;
using TMPro;
using System.Collections;

public class WarningMessagePanel : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public TextMeshProUGUI warningText;

    private float Duration = 0.4f;
    private Coroutine currentWarning;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //showWarning("TEST", 2f);
        canvasGroup.alpha = 0;
       // canvasGroup.gameObject.SetActive(false);
    }

    public void showWarning(string message, float displayTime)
    {
        SoundEffectManager.Play("Alert");
    Debug.Log("ShowWarning called");

        if (currentWarning != null)
        {
            StopCoroutine(currentWarning);
        }

        currentWarning = StartCoroutine(warningRoutine(message, displayTime));
    }

    private IEnumerator warningRoutine(string message, float displayTime)
    {
        warningText.text = message;
        //canvasGroup.gameObject.SetActive(true);

        yield return StartCoroutine(DoFade(canvasGroup, 0f, 1f));
        yield return new WaitForSeconds(displayTime);
        yield return StartCoroutine(DoFade(canvasGroup, 1f, 0f));

        //canvasGroup.gameObject.SetActive(false);
    }

    

    public IEnumerator DoFade(CanvasGroup canvasGroup, float start, float end)
    {
        float counter = 0f;

        while(counter < Duration)
        {
            counter += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, counter / Duration);

            yield return null;
        }

        canvasGroup.alpha = end;
    }
}
