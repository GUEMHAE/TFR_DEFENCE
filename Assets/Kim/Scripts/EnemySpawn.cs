using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;    //�� ������
    [SerializeField]
    float spawnTime; //�� ���� �ֱ�
    [SerializeField]
    Transform[] wayPoints; //���� ���������� �̵� ���

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

            var token = this.GetCancellationTokenOnDestroy();//�ı� ���� �� UniTask���
            await UniTask.Delay(TimeSpan.FromSeconds(spawnTime), cancellationToken: token);
        }
    }
}
