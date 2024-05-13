using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Round : MonoBehaviour
{
    public static Round instance;

    public int totalRounds = 20; // 총 라운드 수
    public int currentRound = 1; // 현재 라운드

    public bool isRound;

    void Awake()
    {
        if (instance == null) //싱글톤 패턴
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private async UniTaskVoid WaitRound()
    {
        while (currentRound <= totalRounds)
        {
            isRound = true;
            await UniTask.WaitUntil(() => !TimeManager.instance.isRoundTime );

            if (GameManager.instance.gold < 10) //이자
            {
                GameManager.instance.gold += 6;
            }
            else if(GameManager.instance.gold<20)
            {
                GameManager.instance.gold += 7;
            }
            else if (GameManager.instance.gold < 30)
            {
                GameManager.instance.gold += 8;
            }
            else
            {
                GameManager.instance.gold += 9;
            }

            Debug.Log("선택시간");
            isRound = false;
            RandomSprite_Unit.instance.RoundRandomSprite();
            await UniTask.WaitUntil(() => TimeManager.instance.isRoundTime);
            Debug.Log("선택시간 종료");

            currentRound++;
            EnemySpawnManager.instance.enemyCount = 0; //유닛 재 생성을 위해 EnemySpawnManager의 enemyCount를 0으로 초기화
        }

    }

    private void Start()
    {
        WaitRound().Forget();
    }
}
