using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ItemSelect : MonoBehaviour, IPointerClickHandler
{   
    public Item items;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemStatus;
    public bool isItemSelected = false;
    public UseItem useItem;

    public void Awake()
    {
        // if (itemName == null)
        // {
        //     itemName = GameObject.Find("Item Name").GetComponent<TextMeshProUGUI>();
        // }

        if (useItem == null)
        {
            useItem = FindObjectOfType<UseItem>();
        }
    }
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

                    if (itemName != null)
                    {
                        itemName.text = items.itemName;
                        Debug.Log("Label changed to: " + itemName.text);
                    }
                    
                    if (useItem != null)
                    {
                         useItem.currentItem = items;
                    }
                   

                     Debug.Log("Item selected");
                     useItem.useButton.interactable = true;
                     SoundEffectManager.Play("itemSelect");
                     isItemSelected = true;
                }
            }



        }
    }



}
