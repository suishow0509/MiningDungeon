using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMining : MonoBehaviour
{
    [Header("�̌@�͈�(���a)")]
    [SerializeField] private float m_miningRange = 2.0f;

    [Header("�̌@��")]
    [SerializeField] private float m_miningPower = 1.0f;

    [Header("�̌@���x(/s)")]
    [SerializeField] private float m_miningSpeed = 1.0f;
    private float m_miningCoolTime = 0.0f;

    [Header("���C���[�}�X�N")]
    [SerializeField] private LayerMask m_layerMask;

    [Header("�f�o�b�O�\��")]
    [SerializeField] private GameObject m_debugMiningRange;
    [SerializeField] private GameObject m_debugMiningPoint;

    // Start is called before the first frame update
    void Start()
    {
        // �̌@�͈͂̐ݒ�
        m_debugMiningRange.transform.localScale = new Vector3(m_miningRange * 2.0f, m_miningRange * 2.0f, m_miningRange * 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // �̌@�N�[���^�C��
        if (m_miningCoolTime > 0.0f)
        {
            m_miningCoolTime -= Time.deltaTime;
        }

        // �v���C���[�̈ʒu
        Vector2 playerPos = transform.position;

        // �}�E�X�̈ʒu���擾
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // �v���C���[�̈ʒu����}�E�X�̈ʒu�ւ̃x�N�g��
        Vector2 playerToMouse = mousePos - playerPos;
        // �x�N�g�����K��
        playerToMouse.Normalize();

        // �v���C���[����̌@�����ւ�RayCast
        RaycastHit2D rayCast = Physics2D.Raycast(playerPos, playerToMouse, m_miningRange, m_layerMask);
        // �����������̂�����Γ��������ʒu���̌@�|�C���g
        if (rayCast)
        {
            m_debugMiningPoint.transform.position = rayCast.point;
        }
        // �����������̂��Ȃ����
        else
        {
            // �̌@�|�C���g
            m_debugMiningPoint.transform.position = playerPos + (playerToMouse * m_miningRange);
        }



	}

    // �̌@����
    public void Mining()
    {
        // �̌@�N�[���^�C����
        if (m_miningCoolTime > 0.0f)
            return;

		// �v���C���[�̈ʒu
		Vector2 playerPos = transform.position;

		// �}�E�X�̈ʒu���擾
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		// �v���C���[�̈ʒu����}�E�X�̈ʒu�ւ̃x�N�g��
		Vector2 playerToMouse = mousePos - playerPos;
		// �x�N�g�����K��
		playerToMouse.Normalize();

        // �v���C���[����̌@�����ւ�RayCast
        RaycastHit2D rayCast = Physics2D.Raycast(playerPos, playerToMouse, m_miningRange, m_layerMask);
		// �����������̂�����΍̌@
		if (rayCast)
		{
            // [Block] �̎擾�����݂�
            if (rayCast.transform.TryGetComponent(out Block block))
            {
                // �̌@�_���[�W���Z
                block.AddMiningDamage(m_miningPower);
            }
            Debug.Log("MINING");
		}

        // �N�[���^�C���ݒ�
        m_miningCoolTime = 1.0f / m_miningSpeed;

	}
}
