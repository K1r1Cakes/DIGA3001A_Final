using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ItemSelect : MonoBehaviour, IPointerClickHandler
{   
    public Item items;
    public TextMeshProUGUI itemName;
    public bool isItemSelected = false;
    public UseItem useItem;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
           Slot slot = GetComponentInParent<Slot>();

           if (slot != null  && slot.currentItem != null)
            {
                Item itemData = slot.currentItem.GetComponent<Item>();
                
                if (itemData != null)
                {
                    items = itemData;
                    itemName.text = items.itemName;

                    useItem.currentItem = items;

                     Debug.Log("Item selected");
                     isItemSelected = true;
                }
            }



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
