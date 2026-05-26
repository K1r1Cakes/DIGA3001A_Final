using UnityEngine;

public class Item : MonoBehaviour
{
   public GameObject itemPrefab;
   public int itemID;
   public string itemName;
   public Slot parentSlot;
   public virtual void UseItem()
   {
      Debug.Log("Using item" +(itemID));
   }

}
