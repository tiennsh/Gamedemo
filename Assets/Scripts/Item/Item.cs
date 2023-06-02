using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemProfile itemProfile;
    public int count = 0;
    int lerpTime = 4;
    SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = itemProfile.itemSprite;
    }

    private void Update()
    {
        Invoke("MoveLerp", 2f);
    }
    public void MoveLerp()
    {
        float xPos = transform.position.x;
        float yPos = transform.position.y;
        xPos = Mathf.Lerp(xPos, Player.Ins.transform.position.x, lerpTime * Time.deltaTime);
        yPos = Mathf.Lerp(yPos, Player.Ins.transform.position.y, lerpTime * Time.deltaTime);
        transform.position = new Vector3(xPos, yPos, transform.position.z);
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
