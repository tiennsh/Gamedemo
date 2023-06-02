using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public float lerpTime;
    bool m_canLerp;
    float m_lerpXDist;
    float m_lerpYDist;

    private void Update()
    {
        if(m_canLerp)
            MoveLerp();
    }

    void MoveLerp()
    {
        float xPos = transform.position.x;
        float yPos = transform.position.y;
        xPos = Mathf.Lerp(xPos, m_lerpXDist, lerpTime * Time.deltaTime);
        yPos = Mathf.Lerp(yPos, m_lerpYDist, lerpTime * Time.deltaTime);
        transform.position = new Vector3(xPos, yPos, transform.position.z);

    }

    public void LerpTriggerStop()
    {
        m_canLerp = false;
        
    }

    public void LerpTrigger(float distX, float distY)
    {
        m_canLerp = true;
        m_lerpXDist = distX;
        m_lerpYDist = distY;
    }
}
