using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    Rigidbody2D m_rb;
    Animator m_amin;

    public int moveSpeed; //Tốc độ di chuyển của Player
    public int direction; //Hướng di chuyển của Player
    public Sprite IconPlayer; //Icon của Player

    int Xmove; //Di chuyển theo X 
    int Ymove; //Di chuyển theo Y
    bool isIdel; //Player có đứng yên không
    bool isAtk; //Có đang tấn công không

    public override void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_amin = GetComponent<Animator>();
        isIdel = true;
        isAtk = false;
    }

    private void Update()
    {
        if (!isAtk) //Nếu đang tấn công thì không di chuyển
            MoveHandle();
    }

    void MoveHandle() // Hàm di chuyển
    {
        bool isLeft = GamePadsController.Ins.CanMoveLeft;
        bool isRight = GamePadsController.Ins.CanMoveRight;
        bool isUp= GamePadsController.Ins.CanMoveUp;
        bool isDown = GamePadsController.Ins.CanMoveDown;
        if (!isLeft && !isRight && !isUp && !isDown)
        {
            Ymove = 0;
            Xmove = 0;
            isIdel = true;
        }
        else if (isLeft && !isRight && !isUp && !isDown)
        {
            Xmove = -1;
            Ymove = 0;
            direction = 2;
            isIdel = false;
        }
        else if (!isLeft && isRight && !isUp && !isDown)
        {
           
            Xmove = 1;
            Ymove = 0;
            direction = 1;
            isIdel = false;
            
        }
        else if (!isLeft && !isRight && isUp && !isDown)
        {
            Ymove = 1;
            Xmove = 0;
            direction = 3;
            isIdel = false;
            
                
        }
        else if (!isLeft && !isRight && !isUp && isDown)
        {
            Ymove = -1;
            Xmove = 0;
            direction = 4;
            isIdel = false;
        }
        
        if (m_amin)
        {
            m_amin.SetBool("Idel", isIdel);
            m_amin.SetInteger("Direction", direction);
        }    
            
        if (m_rb)
            transform.position = new Vector3(
        transform.position.x + Xmove * moveSpeed * Time.deltaTime,
        transform.position.y + Ymove * moveSpeed * Time.deltaTime,
        transform.position.y
        );
        
    }

    public void Atk() // Hàm tấn công
    {
        isAtk = true;
        if (m_amin)
        {
            m_amin.SetBool("Atk", true);
        }
        Invoke("AtkStop", 0.5f);
    }

    void AtkStop() // hàm dừng tấn công
    {
        isAtk = false;
        m_amin.SetBool("Atk", false);
    }

    public IEnumerator PlayerDeath()
    {
        transform.position = new Vector3(0, 0, 0);
        if (m_amin)
        {
            m_amin.SetBool("Death", true);
        }

        yield return new WaitForSeconds(1f);
        m_amin.SetBool("Death", false);
    }

}
