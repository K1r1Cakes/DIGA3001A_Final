using NUnit.Framework;
using UnityEngine;

public class RadioMaker : MonoBehaviour
{
    public GameObject forestTrigger;
    public GameObject desertTrigger;
    public bool isMicro =false;
    public bool isControl = false;
    public bool isAntenna = false;
    public PlayerLevel playerLevel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void radioMake()
    {
        if (isMicro && isControl && isAntenna)
        {
            //insatiate radio
            Debug.Log("Radio made");
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
        if (playerLevel.levelAmount == 200)
        {
            //Unlock mircro
             Debug.Log("Micro unlocked");
        }
    }

    public void unlockControl()
    {
        if (playerLevel.levelAmount == 200)
        {
            //Unlock Control
             Debug.Log("COntrol unlocked");
        }
    }

    public void unlockAntenna()
    {
        if (playerLevel.levelAmount == 200)
        {
            //Unlock Antenna
             Debug.Log("Antenna unlocked");
        }
    }
}
