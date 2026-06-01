using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class ButtonActions : MonoBehaviour, IPointerEnterHandler
{
    private Dialogue dialogue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onExitClick()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void onResetClick()
    {
        SceneManager.LoadScene("Start Menu");
    }

    public void onIslandClick()
    {
        SceneManager.LoadScene("Island");
    }

    public void onIntroScene()
    {
        SceneManager.LoadScene("Introduction");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SoundEffectManager.Play("Hover");
    }
}
