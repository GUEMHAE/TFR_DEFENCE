using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class EnemySpawnManager : MonoBehaviour
{
    public static EnemySpawnManager instance;

    public GameObject[] enemyPrefab;    //�� ������
    [SerializeField]
    float spawnTime;  //�� ���� �ֱ�
    [SerializeField]
    Transform[] wayPoints;   //���� ���������� �̵� ���

    public int enemyCount=0; //���� �� ���� 20�� ���� �� ���� ����
    [SerializeField]
    Transform EnemyPool; //������ �� ������ �����ִ��� üũ�ϱ� ���� �θ� ��ü


    void Awake()
    {
        if (instance == null)  //�̱��� ����
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        SpawnEnemy();
    }

    async UniTask SpawnEnemy() //���� ��ȯ�ϴ� �Լ�
    {
        while (true)
        {
            if (enemyCount < 20&&Round.instance.isRound==true) //���� ������ ���ڰ� 20���� �۰� ���尡 �������϶� �������尡 �ƴ� ��(�Ϲ� ����)
            {
                if ((Round.instance.currentRound % 5) != 0)
                {
                    GameObject clone = Instantiate(enemyPrefab[Round.instance.currentRound - 1], EnemySpawnManager.instance.EnemyPool);
                    // RoundŬ������ currentRound-1�ε����� �ִ� ���� ������Ʈ ����, ������Ʈ Ǯ���� ������� �ʴ� ������ �������� �ʱ� ����
                    enemyCount++; //���� �� ������ ���� enemyCount����

                    Enemy enemy = clone.GetComponent<Enemy>();

                    enemy.Setup(wayPoints);
                }


                else if (Round.instance.currentRound == 5) //ù�� ° ���� ����
                {

                }

                else if (Round.instance.currentRound == 10) //�ι� ° ���� ����
                {

                }

                else if (Round.instance.currentRound == 15) //���� ° ���� ����
                {

                }

                else if (Round.instance.currentRound == 20) //������ ���� ����
                {

                }
            }

            var token = this.GetCancellationTokenOnDestroy();//�ı� ���� �� UniTask���
            await UniTask.Delay(TimeSpan.FromSeconds(spawnTime), cancellationToken: token);
        }
    }
}
