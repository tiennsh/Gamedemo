using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public CamController mainCam;
    public Arrow arrowPrefab;
    public AxeAtk axeAtkPrefab;
    public MobsBat[] mobsBats;
    public GameObject ChatBoxPanel;
    

    bool m_isShoot;
    public ItemProfile isItem;
    ItemCode m_isItem;

    public override void Awake()
    {
        MakeSingleton(false);
    }

    private void Update()
    {
        Lerp();
        if (Input.GetKeyDown(KeyCode.J))
        {
            Atk();
            Debug.Log("Atk");
        }

        if (Input.GetKeyDown(KeyCode.V))
        {

        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (ChatBox.Ins.messages == null) return;
            Time.timeScale = 0f;
            ChatBoxPanel.SetActive(true);
            ChatBox.Ins.NextMessage();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            GameGUIManager.Ins.ShowBag();
        }

    }

    

    IEnumerator ReducedTime(Vector3 pos, int move_name, int timeSwap)
    {
        yield return new WaitForSeconds(timeSwap);

        if (mobsBats != null)
        {
            MobsBat arrowMobsBat = Instantiate(mobsBats[move_name], pos, Quaternion.identity);
        }
    }

    public void SwapMobsBat(Vector3 pos, int move_name, int timeSwap)  //Tạo quái sau XXs
    {
        StartCoroutine(ReducedTime(pos, move_name-1, timeSwap));
    }


    public void Atk()
    {
        if (m_isShoot) return;
        m_isItem = isItem.itemCode;
        if ((m_isItem == ItemCode.Bow_1 || m_isItem == ItemCode.Bow_2
            || m_isItem == ItemCode.Bow_3) && arrowPrefab != null)
        {
            Arrow arrowClone = Instantiate(arrowPrefab, Player.Ins.transform.position, Quaternion.identity);

            arrowClone.Turn(Player.Ins.direction);
        }
        else if ((m_isItem == ItemCode.Axe_1 || m_isItem == ItemCode.Axe_2
            || m_isItem == ItemCode.Axe_3) && axeAtkPrefab != null)
        {
            AxeAtk axeAtkClone = Instantiate(axeAtkPrefab, Player.Ins.transform.position, Quaternion.identity);
            axeAtkClone.Turn(Player.Ins.direction, isItem.itemSprite);
        }
          
        Player.Ins.Atk();
        m_isShoot = true;
        StartCoroutine(AtkStop());
    }
    IEnumerator AtkStop()
    {
        yield return new WaitForSeconds(1f);

        m_isShoot = false;
    }

    void Lerp()
    {
        if (mainCam != null)
        {
            mainCam.LerpTrigger(Player.Ins.transform.position.x, Player.Ins.transform.position.y);
        }
        if (Player.Ins.transform.position.x == mainCam.transform.position.x
            && Player.Ins.transform.position.y == mainCam.transform.position.y)
            mainCam.LerpTriggerStop();
    }

    
    
}
