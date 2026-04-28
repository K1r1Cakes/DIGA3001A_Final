using UnityEngine;
using TMPro;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
   public GameObject ememy1;
   public GameObject enemy2;
   public TextMeshProUGUI warningText;
   public float delay = 3f;

    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.CompareTag("Player"))
        {
            ememy1.SetActive(true);
            enemy2.SetActive(true);

            warningText.gameObject.SetActive(true);
            StartCoroutine(Hide());
        }
    }

    IEnumerator Hide()
    {
        yield return new WaitForSeconds(delay);
        warningText.gameObject.SetActive(false);
    }


}
