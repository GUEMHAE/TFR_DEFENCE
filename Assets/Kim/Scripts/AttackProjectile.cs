using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackProjectile : MonoBehaviour
{
    [SerializeField]
    public Transform attackTarget; //���ݴ��
    public float speed;
    public float damage;

    public void Targeting(Transform target) //���ݴ�� ����
    {
        this.attackTarget = target;
    }

    void Update()
    {
        if(attackTarget!=null) //Ÿ���� �����ϸ�
        {
            Vector3 direction = (attackTarget.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        else //���� Ÿ���� �������
        {
            Destroy(gameObject);
        }
    }
}
