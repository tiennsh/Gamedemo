using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    public Item item;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemNumber;
    public Image itemImage;

    private void Start()
    {
        transform.localScale = new Vector3(1,1,1);
        
    }
    public virtual void SetItem(Item m_item)
    {
        item = m_item;
        
        if(itemName) itemName.text = m_item.name;
        if(itemNumber && !m_item.itemProfile.isUse) itemNumber.text = m_item.count.ToString();
        if (itemImage) itemImage.sprite = m_item.itemProfile.itemSprite;
    }

    private void OnMouseDown()
    {
        UIItemPanel.Ins.ShowItemPanel(item);
    }

}
