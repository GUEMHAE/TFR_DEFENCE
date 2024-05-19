using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabarianSkill : MonoBehaviour
{
    [SerializeField]
    public Transform attackTarget; //���ݴ��
    public float speed;
    public float damage;

    public void SkillTargeting(Transform target) //���ݴ�� ����
    {
        this.attackTarget = target;
    }

    public void SetDamage(float damage) // ������ ����
    {
        this.damage = damage * 1f;
    }


    void Update()
    {
        if (attackTarget != null) //Ÿ���� �����ϸ�
        {
            Vector3 direction = (attackTarget.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        else //���� Ÿ���� �������
        {
            Destroy(gameObject,3f);
        }
    }
}
