using TMPro;
using UnityEngine;

public class RadioMaker : MonoBehaviour
{
    public GameObject forestTrigger;
    public GameObject desertTrigger;
    public GameObject[] alters;
    public GameObject[] rocks;
    public bool isMicro =false;
    public bool isControl = false;
    public bool isAntenna = false;
    public PlayerLevel playerLevel;
    public GameObject allAlterPanel;
    public GameObject[] alterPanels;
    public GameObject radio;
    public bool isRadioMade = false;
    public InventoryController inventory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!isRadioMade)
        {
            radioMake();

        }
    }

    public void radioMake()
    {
        if (isMicro && isControl && isAntenna)
        {
            //insatiate radio
            inventory.AddItem(radio);
            Debug.Log("Radio made");
            isRadioMade = true;
        }

    }

    public void unlockForest()
    {
        forestTrigger.SetActive(false);
        Debug.Log("Forest Unlocked");
        
    }

    public void unlockDesert()
    {
       desertTrigger.SetActive(false);
    }

    public void unlockMicro()
    {
        if (playerLevel.levelAmount >= 100)
        {
            //Unlock mircro
            alters[0].SetActive(false);
            rocks[0].SetActive(true);
            rocks[1].SetActive(true);
            rocks[2].SetActive(true);
            playerLevel.levelAmount -= 100;
            alterPanels[0].SetActive(false);
            allAlterPanel.SetActive(false);
            PauseController.SetPause(false);
            Debug.Log("Micro unlocked");
        }
        
    }

    public void unlockControl()
    {
        if (playerLevel.levelAmount >= 100)
        {
            //Unlock Control
            alters[1].SetActive(false);
            rocks[3].SetActive(true);
            rocks[4].SetActive(true);
            rocks[5].SetActive(true);
            playerLevel.levelAmount -= 100;
            alterPanels[1].SetActive(false);
            allAlterPanel.SetActive(false);
            PauseController.SetPause(false);
             Debug.Log("COntrol unlocked");
        }
    }

    public void unlockAntenna()
    {
        if (playerLevel.levelAmount >= 100)
        {
            //Unlock Antenna
            alters[2].SetActive(false);
            rocks[6].SetActive(true);
            rocks[7].SetActive(true);
            rocks[8].SetActive(true);
            playerLevel.levelAmount -= 100;
            alterPanels[2].SetActive(false);
            allAlterPanel.SetActive(false);
            PauseController.SetPause(false);
             Debug.Log("Antenna unlocked");
        }
    }
}
