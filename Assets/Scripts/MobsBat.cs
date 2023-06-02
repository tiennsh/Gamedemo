using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobsBat : MonoBehaviour
{
    public float moveSpeed;
    public int move_name;
    public int timeSwap;

    Rigidbody2D m_rb;

    Animator m_amin;

    float XmoveSpeed;
    float YmoveSpeed;
    bool Convert;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_amin = GetComponent<Animator>();
        Convert = true;
        isDirection();
    }

    private void Update()
    {
        if (m_amin)
            m_amin.SetInteger("Direction", move_name);
        MoveBat();
    }

    void isDirection()
    {
        if (move_name < 3)
        {
            XmoveSpeed = moveSpeed;
            YmoveSpeed = 0;
            if (move_name == 1)
                XmoveSpeed *= -1;
        }
        else
        {
            XmoveSpeed = 0;
            YmoveSpeed = moveSpeed;
            if (move_name == 4)
                YmoveSpeed *= -1;
        }
    }    

    void MoveBat()
    {
        if (m_rb)
        {
            transform.position = new Vector3(
            transform.position.x + XmoveSpeed * Time.deltaTime,
            transform.position.y + YmoveSpeed * Time.deltaTime,
            transform.position.y
            );
        }

        if ((transform.position.x < 3 || transform.position.x > 9
            || transform.position.y < 6 || transform.position.y > 11) && Convert)
        {
            Convert = false;
            Invoke("isConvert", 1f);
            XmoveSpeed *= -1;
            YmoveSpeed *= -1;
            if (m_amin)
                m_amin.SetTrigger("Convert");
        }
    }

    void isConvert()
    {
        Convert = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Arrow"))
        {
            GameManager.Ins.SwapMobsBat(transform.position, move_name, timeSwap);
            ItemController.Ins.CreateItem(transform.position, 9);
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        if (col.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Player.Ins.PlayerDeath());
        }    
    }

}
