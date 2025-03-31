using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerInputControl m_playerInputControl;

    public Vector2 m_inputDirection;

    private void Awake()
    {
        m_playerInputControl = new PlayerInputControl();
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
        m_inputDirection = m_playerInputControl.Gameplay.Move.ReadValue<Vector2>();
    }
}
