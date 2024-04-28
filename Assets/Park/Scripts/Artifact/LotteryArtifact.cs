using UnityEngine;
using System;

public class LotteryArtifact : MonoBehaviour
{
    // ���� ���� ��� ����
    public enum ArtifactResult
    {
        BossHealthIncrease,
        Gold20,
        Exp30,
        Gold30
    }

    // �� ����� Ȯ��
    private float[] resultProbabilities = { 0.1f, 0.35f, 0.35f, 0.2f };

    // ��� ���� �Լ�
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

    // ��� ���� �Լ�
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
        return ArtifactResult.BossHealthIncrease; // �⺻������ ���� ü�� ����
    }

    // ���� ü�� ���� �Լ�
    private void IncreaseBossHealth()
    {
        // ������ ü���� ������Ű�� �ڵ� �ۼ�
        Debug.Log("���� ü���� 10% �����߽��ϴ�!");
    }

    // ��� ȹ�� �Լ�
    private void GainGold(int amount)
    {
        // �÷��̾��� ��带 ������Ű�� �ڵ� �ۼ�
        Debug.Log(amount + "��带 ȹ���߽��ϴ�!");
    }

    // ����ġ ȹ�� �Լ�
    private void GainExperience(int amount)
    {
        // �÷��̾��� ����ġ�� ������Ű�� �ڵ� �ۼ�
        Debug.Log(amount + "����ġ�� ȹ���߽��ϴ�!");
    }
}
