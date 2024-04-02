using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;    //적 프리팹
    [SerializeField]
    float spawnTime;  //적 생성 주기
    [SerializeField]
    Transform[] wayPoints;   //현재 스테이지의 이동 경로
    [SerializeField]
    int enemyCount=0; //라운드 당 유닛 20기 제한 을 위한 변수
    [SerializeField]
    Transform EnemyPool; //생성된 적 유닛이 남아있는지 체크하기 위한 부모 객체

    private void Awake()
    {
        SpawnEnemy();
    }

    async UniTask SpawnEnemy()
    {
        while (true)
        {
            if (enemyCount < 20)
            {
                GameObject clone = Instantiate(enemyPrefab,EnemyPool);
                enemyCount++;

                Enemy enemy = clone.GetComponent<Enemy>();

                enemy.Setup(wayPoints);
            }

            var token = this.GetCancellationTokenOnDestroy();//파괴 됬을 때 UniTask취소
            await UniTask.Delay(TimeSpan.FromSeconds(spawnTime), cancellationToken: token);
        }
    }
}
