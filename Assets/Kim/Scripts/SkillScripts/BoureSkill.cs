using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoureSkill : MonoBehaviour
{
    [SerializeField]
    public Transform attackTarget; //공격대상
    public float speed;
    public float damage;

    public void SkillTargeting(Transform target) //공격대상 설정
    {
        this.attackTarget = target;
    }

    public void SetDamage(float damage) // 데미지 설정
    {
        this.damage = damage * 1.15f;
    }

    void Update()
    {
        if (attackTarget != null) //타겟이 존재하면
        {
            Vector3 direction = (attackTarget.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        else //만약 타겟이 사라지면
        {
            Destroy(GetComponentInParent<Transform>().gameObject);
            Destroy(gameObject);
        }
    }
}
