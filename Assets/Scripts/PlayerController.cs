using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("�v���C���[�̈ړ��X�N���v�g")]
    [SerializeField] private PlayerMove m_playerMove;

    [Header("�v���C���[�̍̌@�X�N���v�g")]
    [SerializeField] private PlayerMining m_playerMining;

	// ����
	private Controls m_controls = null;


	// Start is called before the first frame update
	void Start()
    {
		// �R���g���[���̐���
		m_controls = new Controls();
		// �R���g���[���̗L����
		m_controls.Enable();

	}

	// Update is called once per frame
	void Update()
    {
		// �ړ�
		// ���͕����̎擾
		Vector2 velocity = m_controls.Player.Move.ReadValue<Vector2>();
		// �ړ��̌Ăяo��
		m_playerMove.MovePlayer(velocity);

		// �̌@
		if (m_controls.Player.Attack.IsPressed())
		{
			m_playerMining.Mining();
		}

	}
}
