using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    public float textSpeed;
    private int index;
    private Coroutine typingCoroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
    yield return new WaitForEndOfFrame();
    yield return null;

    if (dialogueText == null)
    {
        Debug.LogError("DialogueText is NULL after scene load!");
        yield break;
    }

    dialogueText.text = "";
    StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartDialogue()
    {
        index = 0;

        if (typingCoroutine != null)
        StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine()
    {
        if (index < lines.Length - 1)
    {
        SoundEffectManager.Play("Next");
        index++;

        dialogueText.text = string.Empty;

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeLine());
    }
    else
    {
        SceneManager.LoadScene("Island");
    }
    }
}
