using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator m_animator;
    private Rigidbody2D m_Rigidbody;

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        SetAnimation();
    }
    public void SetAnimation()
    {
        m_animator.SetFloat("velocityX", Mathf.Abs(m_Rigidbody.velocity.x));
    }
}
