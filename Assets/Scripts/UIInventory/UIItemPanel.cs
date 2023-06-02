using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItemPanel : Singleton<UIItemPanel>
{
    public ItemPanel itemPanelPrefab;
    public Transform content;

    public void ShowItemPanel(Item item)
    {
        ClearContent();

        ItemPanel itemPanel;
        itemPanel = createItemPanel(item);
        itemPanel.transform.SetParent(content);
    }

    public void ClearContent()
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }

    protected virtual ItemPanel createItemPanel(Item item)
    {
        ItemPanel itemPanel = Instantiate(itemPanelPrefab) as ItemPanel;
        Debug.Log("createItemPanel");
        itemPanel.SetItem(item);
        return itemPanel;
    }

}
