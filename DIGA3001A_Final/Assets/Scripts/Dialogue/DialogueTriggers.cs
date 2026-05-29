using UnityEngine;
using System.Collections;
using TMPro;

public class DialogueTriggers : MonoBehaviour
{
    public static DialogueTriggers currentDialogue;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    public float textSpeed;
    public bool isDone = false;
    private int index;
    private bool isTyping;
    private Coroutine typingCoroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueText.text = string.Empty;
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.CompareTag("Player") && !dialoguePanel.activeSelf && isDone == false)
        {
            dialoguePanel.SetActive(true);
            StartDialogue();
        }
    }

    void StartDialogue()
    {
        currentDialogue = this;
        index = 0;
        PauseController.SetPause(true);

        StartTyping();
    }

    void StartTyping()
    {
        dialogueText.text = string.Empty;

        if(typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        typingCoroutine = StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char c in lines[index])
        {
            dialogueText.text += c;
            yield return new WaitForSecondsRealtime(textSpeed);
        }

        isTyping = false;
    }

    public void NextLine()
    {
        Debug.Log("Pressed next line");
        if (isTyping)
        {
            StopCoroutine(typingCoroutine);
            dialogueText.text = lines[index];
            isTyping = false;
            return;
        }

        if (index < lines.Length - 1)
        {
            index++;
            StartTyping();
        }
        else
        {
            isDone = true;
            dialoguePanel.SetActive(false);
            PauseController.SetPause(false);
        }
    }
}
