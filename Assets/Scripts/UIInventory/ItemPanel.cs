using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemPanel : MonoBehaviour
{
    public Item item;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;
    public Image itemImage;
    public GameObject useBtn;

    private void Start()
    {
        transform.localScale = new Vector3(1, 1, 1);
        transform.position = Player.Ins.transform.position;
    }
    public virtual void SetItem(Item m_item)
    {
        item = m_item;
        if (itemName) itemName.text = m_item.name;
        if (itemDescription) itemDescription.text = m_item.itemProfile.itemDescription;
        if (itemImage) itemImage.sprite = m_item.itemProfile.itemSprite;
        if (useBtn) useBtn.SetActive(m_item.itemProfile.isUse);
    }

    public void Used()
    {
        GameGUIManager.Ins.ItemUsed(item);
        Destroy(gameObject);
    }

    public virtual void Exit()
    {
        Destroy(gameObject);
    }
}
