using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items;

    // Start is called before the first frame update
    void Start()
    {
        /*Add(ItemCode.Axe, 2);
        Add(ItemCode.Bow, 3);
        Add(ItemCode.Bot, 1);*/
    }

    private void Reset()
    {
        LoadItem();
    }

    protected virtual void LoadItem()
    {
        Item item;
        foreach(Transform child in transform)
        {
            item = child.GetComponent<Item>();
            items.Add(item);
        }
    }

    public virtual void Add(ItemCode itemCode)
    {
        Item item = Get(itemCode);
        if (item == null) return;
        int newCount = item.count + 1;
        if (newCount > item.itemProfile.itemMax) return;
        item.count = newCount;
    }

    public virtual Item Get(ItemCode itemCode)
    {
        return items.Find((item) => item.itemProfile.itemCode == itemCode);
    }
}
