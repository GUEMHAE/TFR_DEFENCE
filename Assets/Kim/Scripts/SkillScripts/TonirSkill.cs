using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TonirSkill : MonoBehaviour
{
    public float fallSpeed = 5f;//�ν����Ϳ��� ����
    public Transform attackTarget;
    public float trackingSpeed; //�ν����Ϳ��� ����
    public float damage;//�ν����Ϳ��� ����

    public void SkillTargeting(Transform target) //���ݴ�� ����
    {
        this.attackTarget = target;
    }

    private void Update()
    {
        if (attackTarget != null)
        {
            trackingSpeed = attackTarget.GetComponent<EnemyMoveMent2D>().moveSpeed*2;
            Vector3 horizontalDirection = (attackTarget.position - transform.position).normalized;
            horizontalDirection.y = 0;
            transform.position += horizontalDirection * trackingSpeed * Time.deltaTime;
        }

        if(attackTarget==null)
        {
            Destroy(gameObject);
        }
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
    }
}
