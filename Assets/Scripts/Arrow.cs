using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Singleton<Arrow>
{
    public float moveSpeed;

    Rigidbody2D m_rb;

    int direction;

    public override void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    private void Move() //Hàm di chuyển
    {
        switch (direction)
        {
            case 1:
                {
                    transform.position = new Vector3(
                        transform.position.x + moveSpeed * Time.deltaTime,
                        transform.position.y,
                        transform.position.z);
                    break;
                }

            case 2:
                {
                    transform.position = new Vector3(
                        transform.position.x - moveSpeed * Time.deltaTime,
                        transform.position.y,
                        transform.position.z);
                    break;
                }
            case 3:
                {
                    transform.position = new Vector3(
                        transform.position.x,
                        transform.position.y + moveSpeed * Time.deltaTime,
                        transform.position.z);
                    break;
                }
            default:
                {
                    transform.position = new Vector3(
                        transform.position.x,
                        transform.position.y - moveSpeed * Time.deltaTime,
                        transform.position.z);
                    break;
                }

        }
    }


    public void Turn(int m_direction) //Hàm xoay mũi tên
    {
        direction = m_direction;
        switch (direction)
        {
            case 1:
                {
                    transform.rotation = Quaternion.Euler(0, 0, 135);
                    break;
                }
            case 2:
                {
                    transform.rotation = Quaternion.Euler(0, 0, 315);
                    break;
                }
            case 3:
                {
                    transform.rotation = Quaternion.Euler(0, 0, 225);
                    break;
                }
            default:
                {
                    transform.rotation = Quaternion.Euler(0, 0, 45);
                    break;
                }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Player")
            && !col.gameObject.CompareTag("Monster")
            && !col.gameObject.CompareTag("Item"))
            Destroy(gameObject);
    }


}
