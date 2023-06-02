using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public Inventory inventory;
    public Transform content;
    public UIItem uiItemPrefab;

    private void OnEnable()
    {
        ShowInventory();
    }


    protected virtual void ShowInventory()
    {
        ClearContent();

        UIItem uiItem;
        foreach(Item item in inventory.items)
        {
            if (item.count > 0)
            {
                uiItem = createUIItem(item);
                uiItem.transform.SetParent(content);
            }   
        }
    }

    protected virtual void ClearContent()
    {
        foreach(Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }

    protected virtual UIItem createUIItem(Item item)
    {
        UIItem uiItem = Instantiate(uiItemPrefab) as UIItem;
        uiItem.SetItem(item);
        return uiItem;
    }

    
}
