using UnityEngine;
using System;

public class LotteryArtifact : MonoBehaviour
{
    // 복권 유물 결과 정의
    public enum ArtifactResult
    {
        BossHealthIncrease,
        Gold20,
        Exp30,
        Gold30
    }

    // 각 결과의 확률
    private float[] resultProbabilities = { 0.1f, 0.35f, 0.35f, 0.2f };

    // 결과 실행 함수
    public void ExecuteArtifactResult()
    {
        ArtifactResult result = GetArtifactResult();
        switch (result)
        {
            case ArtifactResult.BossHealthIncrease:
                IncreaseBossHealth();
                break;
            case ArtifactResult.Gold20:
                GainGold(20);
                break;
            case ArtifactResult.Exp30:
                GainExperience(30);
                break;
            case ArtifactResult.Gold30:
                GainGold(30);
                break;
            default:
                Debug.LogError("Invalid artifact result!");
                break;
        }
    }

    // 결과 결정 함수
    private ArtifactResult GetArtifactResult()
    {
        float rand = UnityEngine.Random.value;
        float cumulativeProbability = 0f;
        for (int i = 0; i < resultProbabilities.Length; i++)
        {
            cumulativeProbability += resultProbabilities[i];
            if (rand < cumulativeProbability)
            {
                return (ArtifactResult)i;
            }
        }
        return ArtifactResult.BossHealthIncrease; // 기본적으로 보스 체력 증가
    }

    // 보스 체력 증가 함수
    private void IncreaseBossHealth()
    {
        // 보스의 체력을 증가시키는 코드 작성
        Debug.Log("보스 체력이 10% 증가했습니다!");
    }

    // 골드 획득 함수
    private void GainGold(int amount)
    {
        // 플레이어의 골드를 증가시키는 코드 작성
        Debug.Log(amount + "골드를 획득했습니다!");
    }

    // 경험치 획득 함수
    private void GainExperience(int amount)
    {
        // 플레이어의 경험치를 증가시키는 코드 작성
        Debug.Log(amount + "경험치를 획득했습니다!");
    }
}
