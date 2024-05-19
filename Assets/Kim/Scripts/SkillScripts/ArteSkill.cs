using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArteSkill : MonoBehaviour
{
    [SerializeField]
    public Transform attackTarget; //공격대상

    public float damage = 300f;

    public void SetDamage(float damage) // 데미지 설정
    {
        this.damage = damage * 1.7f;
    }

    public void SkillTargeting(Transform target) //공격대상 설정
    {
        this.attackTarget = target;
    }
}
