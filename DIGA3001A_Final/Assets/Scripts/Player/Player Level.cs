using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLevel : MonoBehaviour
{
    public float levelAmount = 0f;
    public float experienceAmount = 20f; //Change
    //public Image LevelBar;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI microText;
    public TextMeshProUGUI controlText;
    public TextMeshProUGUI antennaText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = levelAmount.ToString();
        microText.text = levelAmount.ToString();
        controlText.text = levelAmount.ToString();
        antennaText.text = levelAmount.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.CompareTag("Experience"))
        {
            SoundEffectManager.Play("orbCollect");
            gainLevel(experienceAmount);
            Destroy(collide.gameObject);
        }
    }

    public void gainLevel(float experience)
    {
            levelAmount += experience;
          
        
    }

    public void loseLevel(float experience)
    {
        levelAmount -= experience;
     
    }
}
