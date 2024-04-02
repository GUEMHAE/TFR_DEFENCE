using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Round : MonoBehaviour
{
    public int totalRounds = 20; // 총 라운드 수
    public int currentRound = 1; // 현재 라운드

    public bool isRound;

    private async UniTaskVoid WaitRound()
    {
        while (currentRound <= totalRounds)
        {
            isRound = true;
            await UniTask.Delay(TimeSpan.FromMinutes(1f)); // 1분 대기
            Debug.Log("선택시간") ;
            isRound = false;
            await UniTask.Delay(TimeSpan.FromSeconds(15f)); // 15초 선택시간
            Debug.Log("선택시간 종료");

            currentRound++;
        }
    }

    private void Start()
    {
        WaitRound().Forget();
    }
}
