using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [Header("ブロックの耐久")]
    [SerializeField] private float m_blockEndurance;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 採掘ダメージ
    public void AddMiningDamage(float power)
    {
        // 採掘ダメージ加算
        m_blockEndurance -= power;

        // 耐久が0になった
        if (m_blockEndurance <= 0.0f)
        {
            BrokenBlock();
        }
    }

    // ブロックが壊れた
    private void BrokenBlock()
    {
        // アイテムドロップ


        // 自身を削除
        Destroy(gameObject);

    }

}
