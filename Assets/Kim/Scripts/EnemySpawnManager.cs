using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class EnemySpawnManager : MonoBehaviour
{
    public static EnemySpawnManager instance;

    public GameObject[] enemyPrefab;    //적 프리팹
    [SerializeField]
    float spawnTime;  //적 생성 주기
    [SerializeField]
    Transform[] wayPoints;   //현재 스테이지의 이동 경로

    public int enemyCount=0; //라운드 당 유닛 20기 제한 을 위한 변수
    [SerializeField]
    Transform EnemyPool; //생성된 적 유닛이 남아있는지 체크하기 위한 부모 객체


    void Awake()
    {
        if (instance == null)  //싱글톤 패턴
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        SpawnEnemy();
    }

    async UniTask SpawnEnemy() //적을 소환하는 함수
    {
        while (true)
        {
            if (enemyCount < 20&&Round.instance.isRound==true) //적이 생성된 숫자가 20보다 작고 라운드가 진행중일때 보스라운드가 아닐 때(일반 라운드)
            {
                if ((Round.instance.currentRound % 5) != 0)
                {
                    GameObject clone = Instantiate(enemyPrefab[Round.instance.currentRound - 1], EnemySpawnManager.instance.EnemyPool);
                    // Round클래스의 currentRound-1인덱스에 있는 게임 오브젝트 생성, 오브젝트 풀링을 사용하지 않는 이유는 재사용하지 않기 떄문
                    enemyCount++; //유닛 수 제한을 위한 enemyCount증가

                    Enemy enemy = clone.GetComponent<Enemy>();

                    enemy.Setup(wayPoints);
                }


                else if (Round.instance.currentRound == 5) //첫번 째 보스 라운드
                {

                }

                else if (Round.instance.currentRound == 10) //두번 째 보스 라운드
                {

                }

                else if (Round.instance.currentRound == 15) //세번 째 보스 라운드
                {

                }

                else if (Round.instance.currentRound == 20) //마지막 보스 라운드
                {

                }
            }

            var token = this.GetCancellationTokenOnDestroy();//파괴 됬을 때 UniTask취소
            await UniTask.Delay(TimeSpan.FromSeconds(spawnTime), cancellationToken: token);
        }
    }
}
