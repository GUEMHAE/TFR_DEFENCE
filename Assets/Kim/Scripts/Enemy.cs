using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class Enemy : MonoBehaviour
{
    //고박사의 towerDefense#01 강의 참고
    int wayPointCount;          //이동 경로 개수
    Transform[] wayPoints;     //이동 경로 정보
    int currentIndex = 0;       //현재 목표지점 인덱스
    EnemyMoveMent2D enemyMoveMent2D;  //오브젝트 이동 제어

    public void Setup(Transform[] wayPoints)
    {
        enemyMoveMent2D = GetComponent<EnemyMoveMent2D>();

        //적 이동 경로 WayPoints 정보 설정
        wayPointCount = wayPoints.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoints;

        //적의 위치를 첫번째 wayPoint위치로 설정
        transform.position = wayPoints[currentIndex].position;

        OnMove();
    }

    private async UniTask OnMove() //다음 목표지점을 설정하는 함수 호출
    {
        //다음 이동 방향 설정
        NextMoveTo();

        while(true)
        {
            //적의 현재위치와 목표위치의 거리가 0.02*EnemyMovement2D.MoveSpeed보다 작을 때 if 조건문 실행
            //EnemyMovement2D.MoveSpeed를 곱해주는 이유는 속도가 빠르면 한 프레임에 0.02보다 크게 움직이기 때문에
            //if조건문에 걸리지 않고 경로를 탈주하는 오브젝트가 발생할 수 있다.
            if(Vector3.Distance(transform.position,wayPoints[currentIndex].position)<=0.03f*enemyMoveMent2D.MoveSpeed)
            {
                NextMoveTo();
            }

            var token = this.GetCancellationTokenOnDestroy();//파괴 됬을 때 UniTask취소
            await UniTask.Delay(0, cancellationToken: token);
        }
    }

    void NextMoveTo()
    {
        //아직 이동할 wayPoints가 남아있다면
        if(currentIndex<wayPointCount-1)
        {
            //적의 위치를 정확하게 목표 위치로 설정
            transform.position = wayPoints[currentIndex].position;
            //이동 방향 설정 => 다음 목표지점(wayPoints)
            currentIndex++;
            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            enemyMoveMent2D.MoveTo(direction);
        }
        //현재 위치가 마지막 wayPoints이면
        else
        {
            //적 오브젝트 다시 waypoint0으로 향하게
            currentIndex = 0;
        }
    }
}
