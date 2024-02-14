using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [Header("�u���b�N�̑ϋv")]
    [SerializeField] private float m_blockEndurance;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �̌@�_���[�W
    public void AddMiningDamage(float power)
    {
        // �̌@�_���[�W���Z
        m_blockEndurance -= power;

        // �ϋv��0�ɂȂ���
        if (m_blockEndurance <= 0.0f)
        {
            BrokenBlock();
        }
    }

    // �u���b�N����ꂽ
    private void BrokenBlock()
    {
        // �A�C�e���h���b�v


        // ���g���폜
        Destroy(gameObject);

    }

}
