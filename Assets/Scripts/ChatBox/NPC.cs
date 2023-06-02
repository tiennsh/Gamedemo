using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Message[] messages;
    public Sprite IconNPC;
    public GameObject ChatBoxPanel;


    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Va cham Player");
            if (messages == null) return;
            ChatBoxPanel.SetActive(true);
            ChatBox.Ins.SetMessage(messages, IconNPC, Player.Ins.IconPlayer);
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            ChatBoxPanel.SetActive(false);
        }
    }
}
