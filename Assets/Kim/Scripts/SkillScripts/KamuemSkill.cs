using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamuemSkill : MonoBehaviour
{
    public float damage;

    public void SetDamage(float damage) // 데미지 설정
    {
        this.damage = damage * 2.3f;
    }
}
