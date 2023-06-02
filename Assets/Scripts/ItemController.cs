using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : Singleton<ItemController>
{
    public Inventory itemInventory;
    public Item_1 item;



    public virtual void CreateItem(Vector3 pos, int index)
    {
        if(item != null && itemInventory.items[index]!=null)
        {
            Item_1 item_1 = Instantiate(item, pos , Quaternion.identity);
            item_1.CreateProfile(itemInventory.items[index].itemProfile);
        }
        
    }


}
