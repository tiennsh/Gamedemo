using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatBox : Singleton<ChatBox>
{
    public Message[] messages;
    public Image IconNPC;
    public Image IconPlayer;
    public TextMeshProUGUI NPCText;
    public TextMeshProUGUI PlayerText;
    public GameObject ChatBoxPanel;
    public Sprite isUI;

    int indexMessage ;
    Sprite isIconNPC;
    Sprite isIconPlayer;
    

    public override void Awake()
    {
        MakeSingleton(false);
    }

    public virtual void SetMessage(Message[] m_messages,
        Sprite m_IconNPC, Sprite m_IconPlayer)
    {
        Debug.Log("Message");
        indexMessage = 0;
        messages = m_messages;
        isIconNPC = m_IconNPC;
        isIconPlayer = m_IconPlayer;
    }

    public virtual void NextMessage()
    {
        Debug.Log("NextMessage");
        if (indexMessage == messages.Length)
        {
            ChatBoxPanel.SetActive(false);
            Time.timeScale = 1f;
            return;
        }

        if (messages[indexMessage].speaker =="NPC" )
        {
            PlayerText.text = "";
            NPCText.text = messages[indexMessage].message.ToString();
            if (isIconNPC != null) IconNPC.sprite = isIconNPC;
            if (isUI != null) IconPlayer.sprite = isUI;
        }
        else
        {
            PlayerText.text = messages[indexMessage].message.ToString();
            if (isIconPlayer != null) IconPlayer.sprite = isIconPlayer;
            if (isUI != null) IconNPC.sprite = isUI;
        }
        indexMessage++;
    }

}
