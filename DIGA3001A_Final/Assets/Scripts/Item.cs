using UnityEngine;

public class Item : MonoBehaviour
{
   public GameObject itemPrefab;
   public int itemID;
   public string itemName;
   public virtual void UseItem()
   {
      Debug.Log("Using item" +(itemID));
   }
}
