using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuUi : MonoBehaviour
{
    public GameObject controlPanel;
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
    public void onIntroScene()
    {
        SceneManager.LoadScene("Introduction");
    }

    public void onControls()
    {
         if (controlPanel != null)
        {
            controlPanel.SetActive(!controlPanel.activeSelf);
        }
    }
}
