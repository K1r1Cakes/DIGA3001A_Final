using UnityEngine;
using UnityEngine.UI;

public class PlayerUV : MonoBehaviour
{
    public float uvAmount = 100f;
    public float uvDamage = 10f;
    public float uvGain = 10f;
    public float globalUVTimer;
    public float uvTimer = 5f;
    public Image uvBar;
    //public Playerhealth playerhealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        globalUVTimer = uvTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseController.isGamePaused)
        {
            return;
        }

        globalUVTimer -= Time.deltaTime;

        if (globalUVTimer <= 0)
        {
            if (uvAmount > 0)
            {
                loseUV(uvDamage);
                globalUVTimer = uvTimer;
            }
            else
            {
                Debug.Log("Player is too hot");
                //playerhealth.TakeDamage(10);
            }

            globalUVTimer = uvTimer;
        }
    }

    public void loseUV(float uv)
    {
        uvAmount -= uv;
        uvBar.fillAmount = uvAmount/100f;
    }

    public void fillUV(float uv)
    {
        if (uvAmount < 100)
        {
            uvAmount += uv;
            uvBar.fillAmount = uvAmount/100f;
        }

        if (uvAmount > 100)
        {
            uvAmount = 100;
        }
    }
}
