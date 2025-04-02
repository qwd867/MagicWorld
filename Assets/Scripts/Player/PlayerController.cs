using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // ����������ϵͳ��InputSystem
    public PlayerInputControl m_playerInputControl;
    // ���̻��ֱ����뷽��
    public Vector2 m_inputDirection;
    // �������ʵ��
    private Rigidbody2D m_rb;

    [Header("��������")]
    // �ٶ�ֵ
    public float m_speed;
    // ��Ծ����
    public float m_jumpForce;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_playerInputControl = new PlayerInputControl();
        m_playerInputControl.Gameplay.Jump.started += Jump;
    }

    private void OnEnable()
    {
        m_playerInputControl.Enable();
    }

    private void OnDisable()
    {
        m_playerInputControl.Disable();
    }

    private void Update()
    {
        // ��������ϵͳ����ȡ��ǰ����ķ���
        m_inputDirection = m_playerInputControl.Gameplay.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        // �ƶ�
        Move();
    }
    public void Move()
    {
        // Time.DeltaTime ������һ֡�����ѵ�ʱ�䣨����Ϊ��λ��
        m_rb.velocity = new Vector2(m_inputDirection.x * m_speed * Time.deltaTime, m_rb.velocity.y);

        //���﷭ת
        int faceDir = (int)transform.localScale.x;
        if (m_inputDirection.x > 0)
        {
            faceDir = 1;
        }
        else if (m_inputDirection.x < 0)
        {
            faceDir = -1;
        }
        transform.localScale = new Vector3(faceDir, transform.localScale.y, transform.localScale.z);
    }
    private void Jump(InputAction.CallbackContext context)
    {
        m_rb.AddForce(transform.up * m_jumpForce, ForceMode2D.Impulse);
    }
}
