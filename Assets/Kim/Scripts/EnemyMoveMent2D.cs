using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveMent2D : MonoBehaviour
{
    //고박사의 유니티 강의_TowerDefense#01 참고함
    public float moveSpeed = 0.0f; //적의 이동속도
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero; //적의 이동 방향
    [SerializeField]
    Enemy enemy;

    public float MoveSpeed => moveSpeed; //moveSpeed 변수의 프로퍼티(Get 가능)

    void Update()
    {
        if (enemy.hp > 0)
        {
            transform.position += moveDirection * moveSpeed * Time.deltaTime; //적을 이동시키는 코드
        }
    }

    public void MoveTo(Vector3 direction) //외부에서 이동방향을 설정하는 MoveTo함수
    {
        moveDirection = direction;
    }
}
