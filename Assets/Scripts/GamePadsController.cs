using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePadsController : Singleton<GamePadsController>
{
    public bool isOnMobile;

    bool m_canMoveLeft;
    bool m_canMoveRight;
    bool m_canMoveUp;
    bool m_canMoveDown;

    public bool CanMoveLeft { get => m_canMoveLeft; set => m_canMoveLeft = value; }
    public bool CanMoveRight { get => m_canMoveRight; set => m_canMoveRight = value; }
    public bool CanMoveUp { get => m_canMoveUp; set => m_canMoveUp = value; }
    public bool CanMoveDown { get => m_canMoveDown; set => m_canMoveDown = value; }

    private void Update()
    {
        if (!isOnMobile)
            PCHandle();
    }

    void PCHandle()
    {
        m_canMoveLeft = Input.GetAxisRaw("Horizontal") < 0;
        m_canMoveRight = Input.GetAxisRaw("Horizontal") > 0; 
        m_canMoveUp = Input.GetAxisRaw("Vertical") > 0;
        m_canMoveDown = Input.GetAxisRaw("Vertical") < 0;
    }
}
