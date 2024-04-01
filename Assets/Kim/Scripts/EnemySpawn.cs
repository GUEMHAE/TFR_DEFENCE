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
    float spawnTime; //적 생성 주기
    [SerializeField]
    Transform[] wayPoints; //현재 스테이지의 이동 경로

    private void Awake()
    {
        SpawnEnemy();
    }

    async UniTask SpawnEnemy()
    {
        while(true)
        {
            GameObject clone = Instantiate(enemyPrefab);
            Enemy enemy = clone.GetComponent<Enemy>();

            enemy.Setup(wayPoints);

            var token = this.GetCancellationTokenOnDestroy();//파괴 됬을 때 UniTask취소
            await UniTask.Delay(TimeSpan.FromSeconds(spawnTime), cancellationToken: token);
        }
    }
}
