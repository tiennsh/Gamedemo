using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAtk : Singleton<AxeAtk>
{
    public float moveSpeed;
    float v;
    Rigidbody2D m_rb;
    SpriteRenderer sprite;

    public override void Awake()
    {
        StartCoroutine(AxeAtkStop());
        m_rb = GetComponent<Rigidbody2D>();
        v = 0;
    }

    private void Update()
    {
        Move();
    }

    void CreateImage(Sprite itemSprite)
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = itemSprite;
    }
    private void Move()
    {
        switch (Player.Ins.direction)
        {
            case 1:
                {
                    transform.position = new Vector3(
                        transform.position.x + moveSpeed * 0.5f * Time.deltaTime,
                        transform.position.y + moveSpeed * Time.deltaTime,
                        transform.position.y);
                    break;
                }
            case 2:
                {
                    transform.position = new Vector3(
                       transform.position.x - moveSpeed * 0.5f * Time.deltaTime,
                       transform.position.y - moveSpeed * Time.deltaTime,
                       transform.position.y);
                    break;
                }
            case 3:
                {
                    transform.position = new Vector3(
                        transform.position.x - moveSpeed * Time.deltaTime,
                        transform.position.y + moveSpeed * 0.5f * Time.deltaTime,
                        transform.position.y);
                    break;
                }
            default:
                {
                    transform.position = new Vector3(
                        transform.position.x + moveSpeed * Time.deltaTime,
                        transform.position.y - moveSpeed * 0.5f * Time.deltaTime,
                        transform.position.y);
                    break;
                }
        }
        v += moveSpeed * 100 * Time.deltaTime;
        
        transform.rotation = Quaternion.Euler(0, 0, v);
    }

    public void Turn(int m_direction, Sprite itemSprite) //Hàm xoay rìu
    {
        CreateImage(itemSprite);
        switch (m_direction)
        {
            case 1:
                {
                    v = 180;
                    transform.position = new Vector3(Player.Ins.transform.position.x + 0.5f,
                        Player.Ins.transform.position.y - 0.447f,
                        Player.Ins.transform.position.z);
                    break;
                }
            case 2:
                {
                    v = 0;
                    transform.position = new Vector3(Player.Ins.transform.position.x - 0.5f,
                        Player.Ins.transform.position.y + 0.109f,
                        Player.Ins.transform.position.z);
                    break;
                }
            case 3:
                {
                    v = 270;
                    transform.position = new Vector3(Player.Ins.transform.position.x + 0.316f,
                       Player.Ins.transform.position.y + 0.399f,
                       Player.Ins.transform.position.z);
                    break;
                }
            default:
                {
                    v = 90;
                    transform.position = new Vector3(Player.Ins.transform.position.x - 0.315f,
                        Player.Ins.transform.position.y - 0.698f,
                        Player.Ins.transform.position.z);
                    break;
                }
        }
    }

    IEnumerator AxeAtkStop()
    {
        yield return new WaitForSeconds(0.6f);

        Destroy(gameObject);
    }

}
