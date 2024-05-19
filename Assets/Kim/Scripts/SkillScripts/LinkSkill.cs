using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkSkill : MonoBehaviour
{
    public float damage;
    public float moveSpeed = 5f;  // Speed of the skill
    private Transform[] wayPoints;
    private int currentWayPointIndex = 0;

    public void SetDamage(float damage) // 데미지 설정
    {
        this.damage = damage * 4f;
    }

    private void Start()
    {
        if (EnemySpawnManager.instance != null)
        {
            wayPoints = EnemySpawnManager.instance.wayPoints;
        }

        // Start the movement coroutine
        if (wayPoints != null && wayPoints.Length > 0)
        {
            StartCoroutine(MoveAlongWaypoints());
        }

        Destroy(gameObject, 4.5f);
    }

    private IEnumerator MoveAlongWaypoints()
    {
        while (currentWayPointIndex < wayPoints.Length)
        {
            Transform targetWayPoint = wayPoints[currentWayPointIndex];
            while (Vector3.Distance(transform.position, targetWayPoint.position) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, moveSpeed * Time.deltaTime);
                yield return null;
            }
            currentWayPointIndex++;
        }
    }
}
