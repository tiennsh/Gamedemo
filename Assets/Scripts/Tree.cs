using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public float timeSwap;
    public GameObject Item;

    Animator m_amin;
    float m_time;

    private void Start()
    {
        m_amin = GetComponent<Animator>();
        transform.position = new Vector3(
            transform.position.x, transform.position.y, transform.position.y);
    }

    void SwapTreeSmall()
    {
        m_amin.SetInteger("Tree", 1);
        Invoke("SwapTreeBig", timeSwap*5);
    }

    void SwapTreeBig()
    {
        if (Time.time - m_time < timeSwap*6) return;
        m_amin.SetInteger("Tree", 2);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("AxeAtk"))
        {

            if (m_amin.GetInteger("Tree") == 2)
            {
                ItemController.Ins.CreateItem(new Vector3(transform.position.x, 
                    transform.position.y, transform.position.y+1), 15);
            }
            m_amin.SetInteger("Tree", 0);
            m_time = Time.time;
            Invoke("SwapTreeSmall", timeSwap);
        }
    }
}
