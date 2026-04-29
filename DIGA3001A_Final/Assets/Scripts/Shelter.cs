using UnityEngine;
using TMPro;
using System.Collections;

public class Shelter : MonoBehaviour
{
    public TextMeshProUGUI  shelterText;
    public float delay = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        if (shelterText == null)
        {
            shelterText = FindObjectOfType<TextMeshProUGUI>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.CompareTag("Player"))
        {
            shelterText.gameObject.SetActive(true);
            StartCoroutine(Hide());
        }
    }

    IEnumerator Hide()
    {
        yield return new WaitForSeconds(delay);
        shelterText.gameObject.SetActive(false);
    }
}
