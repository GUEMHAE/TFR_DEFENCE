using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PionaSkill : MonoBehaviour
{
    [SerializeField]
    public Transform attackTarget; //���ݴ��
    public float speed;

    [SerializeField]
    public float damage;

    public void SetDamage(float damage) // ������ ����
    {
        this.damage = damage * 2.6f;
    }

    public void SkillTargeting(Transform target) //���ݴ�� ����
    {
        this.attackTarget = target;
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
            Destroy(GetComponentInParent<Transform>().gameObject);
            Destroy(gameObject);
        }
    }
}
