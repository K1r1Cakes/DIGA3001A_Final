using UnityEngine;

public class ReadNote : MonoBehaviour
{
    public DialogueTriggers dialogueTriggers;
    public GameObject notePanel;
    private bool hasOpenedNote = false;


    private void Update()
    {
        if (dialogueTriggers.isDone && !hasOpenedNote)
        {
            hasOpenedNote = true;

            Debug.Log("Open note");

            notePanel.SetActive(true);

            PauseController.SetPause(true);
        }
    }

    public void onNoteExit()
    {
        notePanel.SetActive(false);
        PauseController.SetPause(false);
    }
}
