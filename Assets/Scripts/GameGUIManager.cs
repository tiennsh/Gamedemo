using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameGUIManager : Singleton<GameGUIManager>
{
    public Item itemUsed;
    public AtkBtn atkBtnPrefab;
    public Transform tranform;
    public GameObject BagInventory;

    bool isShowBag;

    public override void Awake()
    {
        MakeSingleton(false);
        isShowBag = false;
        CreateAtkBtn();
    }

    public void ShowBag()
    {
        isShowBag = !isShowBag;
        BagInventory.SetActive(isShowBag);
        UIItemPanel.Ins.ClearContent();
    }

    void CreateAtkBtn()
    {
        ClearContent();

        AtkBtn atkBtn = Instantiate(atkBtnPrefab);
        atkBtn.transform.SetParent(tranform);
        atkBtn.CreateImage(itemUsed.itemProfile.itemSprite);
    }

    protected virtual void ClearContent()
    {
        foreach (Transform child in tranform)
        {
            Destroy(child.gameObject);
        }
    }

    public void ItemUsed(Item itemUsed)
    {
        this.itemUsed = itemUsed;
        ShowBag();
        CreateAtkBtn();
        GameManager.Ins.isItem = itemUsed.itemProfile;
    }
}
