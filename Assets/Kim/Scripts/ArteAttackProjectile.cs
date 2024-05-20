using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArteAttackProjectile : MonoBehaviour
{
    public float damage;

    public void SetDamage(float damage) // 데미지 설정
    {
        this.damage = damage;
    }

}
