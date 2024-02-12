using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [Header("‘¬‚³")]
    [SerializeField] private float m_speed = 1.0f;


    // “ü—Í
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
        // “ü—Í•ûŒü‚Ìæ“¾
        Vector2 velocity = m_controls.Player.Move.ReadValue<Vector2>() * Time.deltaTime * m_speed;

        // Vector3‚É•ÏŠ·‚µ‚ÄÀ•W‚É‰ÁZ
        transform.position += (Vector3)velocity;

    }
}
