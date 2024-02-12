using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [Header("����")]
    [SerializeField] private float m_speed = 1.0f;


    // ����
    private Controls m_controls = null;


    // Start is called before the first frame update
    void Start()
    {
        m_controls = new Controls();
        m_controls.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // ���͕����̎擾
        Vector2 velocity = m_controls.Player.Move.ReadValue<Vector2>() * Time.deltaTime * m_speed;

        // Vector3�ɕϊ����č��W�ɉ��Z
        transform.position += (Vector3)velocity;

    }
}
