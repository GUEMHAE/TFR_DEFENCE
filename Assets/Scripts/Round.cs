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

    public bool expRound = false; // 이전 라운드 진행 여부 저장 변수
    public int exp = 0; // 경험치 저장 함수
    public TMP_Text expText;   // 경험치를 표시할 텍스트 UI

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

    void Update()
    {
        // 경험치 텍스트 업데이트
        expText.text = "Experience: " + exp.ToString();
    }

    private async UniTaskVoid WaitRound()
    {
        while (currentRound <= totalRounds)
        {
            isRound = true;
            await UniTask.Delay(TimeSpan.FromMinutes(1f)); // 1분 대기
            Debug.Log("선택시간") ;
            isRound = false;

            exp++;

            await UniTask.Delay(TimeSpan.FromSeconds(15f)); // 15초 선택시간
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
