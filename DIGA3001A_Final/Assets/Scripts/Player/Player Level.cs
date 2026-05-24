using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
    public int Level = 0;
    public float levelAmount = 0f;
    public float experienceAmount = 100f;
    public Image LevelBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.CompareTag("Experience"))
        {
            gainLevel(experienceAmount);
        }
    }

    public void gainLevel(float experience)
    {
       if (levelAmount < 100)
        {
            levelAmount += experience;
            LevelBar.fillAmount = levelAmount/100f;
        }

        if (levelAmount > 100)
        {
            levelAmount = 100;
        }
    }
}
