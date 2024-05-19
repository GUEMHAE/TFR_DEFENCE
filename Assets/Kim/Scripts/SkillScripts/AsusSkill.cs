using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsusSkill : MonoBehaviour
{
    [SerializeField]
    public float damage;

    public void SetDamage(float damage) // 데미지 설정
    {
        this.damage = damage*2f;
    }

    private void Update()
    {
        Destroy(this.gameObject, 8f);
    }
}
