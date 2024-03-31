using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Round : MonoBehaviour
{
    public int totalRounds = 20; // 총 라운드 수
    private int currentRound = 1; // 현재 라운드

    private Text roundText; 

    private async UniTaskVoid WaitRound()
    {
        while (currentRound <= totalRounds)
        {
            await UniTask.Delay(TimeSpan.FromMinutes(1f)); // 1분 대기
            Debug.Log("선택시간") ;
            await UniTask.Delay(TimeSpan.FromSeconds(15f)); // 15초 선택시간
            Debug.Log("선택시간 종료");

            roundText.text = "라운드: " + currentRound;
            currentRound++;
        }
    }

    private void Start()
    {
        WaitRound().Forget();
    }
}
