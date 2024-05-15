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
    public bool isLock = false;
    public Image lockimg;
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
            isLock = false;
            lockimg.color = Color.white;
            await UniTask.WaitUntil(() => !TimeManager.instance.isRoundTime );

            Debug.Log("선택시간");
            isRound = false;

            if (GameManager.instance.gold < 10)
            {
                GameManager.instance.gold += 6;
                break;
            }
            else if (GameManager.instance.gold < 20)
            {
                GameManager.instance.gold += 7;
                break;
            }
            else if (GameManager.instance.gold < 30)
            {
                GameManager.instance.gold += 8;
                break;
            }
            else if (GameManager.instance.gold >= 30)
            {
                GameManager.instance.gold += 9;
                break;
            }


            if (isLock == false)
            {
                RandomSprite_Unit.instance.RoundRandomSprite();
            }

            await UniTask.WaitUntil(() => TimeManager.instance.isRoundTime);
            Debug.Log("선택시간 종료");

            currentRound++;
            EnemySpawnManager.instance.enemyCount = 0; //유닛 재 생성을 위해 EnemySpawnManager의 enemyCount를 0으로 초기화
        }

    }

    private void Start()
    {
        WaitRound();
    }
}
