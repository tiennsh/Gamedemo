using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_1 : Item
{
    SpriteRenderer sprite;

    private void Update()
    {
        Invoke("MoveLerp", 2f);
    }

    public void CreateProfile(ItemProfile m_itemProfile)
    {
        itemProfile = m_itemProfile;
        CreateImage();
    }

    void CreateImage()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = itemProfile.itemSprite;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            ItemController.Ins.itemInventory.Add(itemProfile.itemCode);
            Destroy(gameObject);

        }
    }
}
