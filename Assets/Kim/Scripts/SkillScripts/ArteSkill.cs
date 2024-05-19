using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArteSkill : MonoBehaviour
{
    [SerializeField]
    public Transform attackTarget; //���ݴ��

    public float damage = 300f;

    public void SetDamage(float damage) // ������ ����
    {
        this.damage = damage * 1.7f;
    }

    public void SkillTargeting(Transform target) //���ݴ�� ����
    {
        this.attackTarget = target;
    }
}
