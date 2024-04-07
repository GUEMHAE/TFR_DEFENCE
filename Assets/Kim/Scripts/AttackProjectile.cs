using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackProjectile : MonoBehaviour
{
    [SerializeField]
    public Transform attackTarget; //공격대상
    public float speed;
    public float damage;

    public void Targeting(Transform target) //공격대상 설정
    {
        this.attackTarget = target;
    }

    void Update()
    {
        if(attackTarget!=null) //타겟이 존재하면
        {
            Vector3 direction = (attackTarget.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        else //만약 타겟이 사라지면
        {
            Destroy(gameObject);
        }
    }
}
