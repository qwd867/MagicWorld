using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // 玩家输入控制系统，InputSystem
    public PlayerInputControl m_playerInputControl;
    // 键盘或手柄输入方向
    public Vector2 m_inputDirection;
    // 刚体组件实例
    private Rigidbody2D m_rb;

    [Header("基本参数")]
    // 速度值
    public float m_speed;
    // 跳跃的力
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
        // 根据输入系统，获取当前输入的方向
        m_inputDirection = m_playerInputControl.Gameplay.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        // 移动
        Move();
    }
    public void Move()
    {
        // Time.DeltaTime 代表上一帧所花费的时间（以秒为单位）
        m_rb.velocity = new Vector2(m_inputDirection.x * m_speed * Time.deltaTime, m_rb.velocity.y);

        //人物翻转
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
