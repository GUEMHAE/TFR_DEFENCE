using UnityEngine;
using Cysharp.Threading.Tasks;

public class Unit : MonoBehaviour
{
    UnitInfo unit;
    public int damage = 0;
    public float attackRange = 1.5f;
    public float attackCooldown = 1f;
    private float lastAttackTime = 0f;

    public bool isAttack = false;

    public Transform enemyPos;

    private void Start()
    {
        damage = unit.Ad + unit.Ap;
    }

    private void Update()
    {
        if (!isAttack)
        {
            Attack().Forget();
        }
    }

    private async UniTaskVoid Attack()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemyPos.position); //���ְ� �� �Ÿ� ���
            if (distanceToEnemy <= attackRange)
            {
                isAttack = true;
                Debug.Log("������");
                lastAttackTime = Time.time;
                isAttack = false;
            }
        }
    }

}
