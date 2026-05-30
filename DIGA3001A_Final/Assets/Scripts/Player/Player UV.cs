using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUV : MonoBehaviour
{
    public float uvAmount = 100f;
    public float uvDamage = 10f;
    public float uvGain = 10f;
    public float globalUVTimer;
    public float uvTimer = 5f;
    public bool isFilling = false;
    public Image uvBar;
    public Playerhealth playerhealth;
    public GameObject warnPanel;
    public TextMeshProUGUI warnText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        globalUVTimer = uvTimer; //GT = 5
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
                if(isFilling == true)
                {
                    fillUV(uvGain);
                    globalUVTimer = uvTimer; 
                }
                else
                {
                    loseUV(uvDamage);
                    globalUVTimer = uvTimer; 
                }
               
            }
            else
            {
                Debug.Log("Player is too hot");
                playerhealth.TakeDamage(10);
            }

            globalUVTimer = uvTimer;
        }
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.CompareTag("Shade"))
        {
            isFilling = true;
            Debug.Log("InShade");
        }
       
    }
    private void OnTriggerExit2D(Collider2D collide)
    {
        if (collide.CompareTag("Shade"))
        {
            isFilling = false;
            Debug.Log("OutInShade");
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
