using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackProjectile : MonoBehaviour
{
    [SerializeField]
    public Transform attackTarget; //공격대상
    public float speed;
    public float damage;
    private Quaternion targetRotation;

    public void Targeting(Transform target) //공격대상 설정
    {
        this.attackTarget = target;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Enemy")
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(attackTarget!=null) //타겟이 존재하면
        {
            Vector3 direction = (attackTarget.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //방향 벡터를 기반으로한 회전 각도 방향 벡터가 이루는 각도를 라디안 단위로 계산
            targetRotation = Quaternion.Euler(new Vector3(0, 0, angle-180));
            transform.rotation = targetRotation;
        }
        else //만약 타겟이 사라지면
        {
            Destroy(gameObject);
        }
    }
}
