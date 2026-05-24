using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLevel : MonoBehaviour
{
    public int Level = 0;
    public float levelAmount = 0f;
    public float experienceAmount = 100f;
    public Image LevelBar;
    public TextMeshProUGUI levelText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = Level.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.CompareTag("Experience"))
        {
            gainLevel(experienceAmount);
            Destroy(collide.gameObject);
        }
    }

    public void gainLevel(float experience)
    {
       if (levelAmount < 100)
        {
            levelAmount += experience;
            LevelBar.fillAmount = levelAmount/100f;
        }

        if (levelAmount >= 100)
        {
            Level++;
        }
    }

    public void loseLevel(float experience)
    {
        levelAmount -= experience;
        LevelBar.fillAmount = levelAmount/100f;
        Level--;
    }
}
