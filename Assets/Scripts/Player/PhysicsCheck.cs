using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    public Vector2 m_bottomOffset;
    public float m_checkRadius;
    public LayerMask m_groundLayer;
    public bool m_isGround;

    private void Update()
    {
        Check();
    }

    public void Check()
    {
        //ºÏ≤‚µÿ√Ê
        m_isGround = Physics2D.OverlapCircle((Vector2)transform.position + m_bottomOffset, m_checkRadius, m_groundLayer);
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + m_bottomOffset, m_checkRadius);
    }
}
