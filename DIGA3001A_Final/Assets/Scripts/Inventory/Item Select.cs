using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ItemSelect : MonoBehaviour, IPointerClickHandler
{
    public Item items;
    public GameObject panel;
    public TextMeshProUGUI itemName;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
           Slot slot = eventData.pointerEnter?.GetComponent<Slot>();

           if (slot != null)
            {
                GameObject item = eventData.pointerEnter;
                
            }

            Debug.Log("Item selected");
                itemName.text = items.itemName;

        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
