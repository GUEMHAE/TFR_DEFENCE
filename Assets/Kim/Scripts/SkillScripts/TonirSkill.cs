using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cysharp.Threading.Tasks;

public class TonirSkill : MonoBehaviour
{
    [SerializeField]
    public Transform attackTarget; //���ݴ��
    public float speed;
    public float damage;
    private Quaternion targetRotation;

    public void SkillTargeting(Transform target) //���ݴ�� ����
    {
        this.attackTarget = target;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.tag == "Enemy")
        //{
        //    Destroy(gameObject);
        //}
    }

    void Update()
    {
        if (attackTarget != null) //Ÿ���� �����ϸ�
        {
            Vector3 direction = (attackTarget.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //���� ���͸� ��������� ȸ�� ���� ���� ���Ͱ� �̷�� ������ ���� ������ ���
            targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 270));
            transform.rotation = targetRotation;
        }
        else //���� Ÿ���� �������
        {
            Destroy(gameObject,1.3f);
        }
    }
}
