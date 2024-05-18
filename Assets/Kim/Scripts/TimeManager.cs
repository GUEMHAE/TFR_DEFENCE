using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class TimeManager : MonoBehaviour
{
    public float roundTime=45f; //현재 라운드 시간 변수
    public bool isRoundTime ;
    public static TimeManager instance; //싱글톤 패턴
    public bool isNoEnemy; //적이 없을때 현재 남은 라운드 시간을 3으로 줄이기 위한 변수
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

    async UniTaskVoid timeReduce()//적이 없을때 시간을 줄임
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
