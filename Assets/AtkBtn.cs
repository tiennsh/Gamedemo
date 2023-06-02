using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtkBtn : MonoBehaviour
{
    public Image itemImage;

    private void Start()
    {
        transform.localScale = new Vector3(1, 1, 1);
        transform.localPosition = new Vector3(0, 0, 0);

    }

    public void Atk()
    {
        GameManager.Ins.Atk();
    }

    public void CreateImage(Sprite itemSprite)
    {
        itemImage.sprite = itemSprite;
    }

}
