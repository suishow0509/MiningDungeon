using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [Header("速さ")]
    [SerializeField] private float m_speed = 1.0f;


    // 入力
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
        // 入力方向の取得
        Vector2 velocity = m_controls.Player.Move.ReadValue<Vector2>() * Time.deltaTime * m_speed;

        // Vector3に変換して座標に加算
        transform.position += (Vector3)velocity;

    }
}
