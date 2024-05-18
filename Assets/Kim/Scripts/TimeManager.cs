using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class TimeManager : MonoBehaviour
{
    public float roundTime=45f; //���� ���� �ð� ����
    public bool isRoundTime ;
    public static TimeManager instance; //�̱��� ����
    public bool isNoEnemy; //���� ������ ���� ���� ���� �ð��� 3���� ���̱� ���� ����
    [SerializeField]
    GameObject enemyPool;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    async UniTaskVoid timeReduce()//���� ������ �ð��� ����
    {
        while(true)
        {
            await UniTask.WaitUntil(() => EnemySpawnManager.instance.isFullSpawnEnemy);
            if (enemyPool.transform.childCount==0&&isNoEnemy==false&&Round.instance.isRound==true)
            {
                roundTime = 3;
                isNoEnemy = true;
            }
            else if(enemyPool.transform.childCount>0&&isNoEnemy==true&&Round.instance.isRound==true)
            {
                isNoEnemy = false;
            }
        }
    }

    void Start()
    {
        timeReduce();
        isRoundTime = true;
        roundTime = 45f;
    }

    void Update()
    {
        roundTime -= Time.deltaTime;

        if (isRoundTime == true && Round.instance.isRound == true&&roundTime<=0)
        {
            roundTime = 15;
            isRoundTime = false;
        }

        else if (isRoundTime == false && Round.instance.isRound == false && roundTime <= 0)
        {
            roundTime = 45;
            isRoundTime = true;
        }
    }
}
