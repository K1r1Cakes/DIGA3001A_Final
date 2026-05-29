using UnityEngine;

public class DialogueButton : MonoBehaviour
{
    public void OnNextPressed()
    {
        if (DialogueTriggers.currentDialogue != null)
        {
            DialogueTriggers.currentDialogue.NextLine();
        }
    }
}
