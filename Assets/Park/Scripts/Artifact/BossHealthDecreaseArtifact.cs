using UnityEngine;

public class BossHealthDecreaseArtifact : MonoBehaviour
{
    // 보스의 체력을 감소시키는 비율
    private float bossHealthDecreasePercentage = 0.2f;

    public float MaxHealth = 100f;
    public float BossHp = 100f;

    // 보스 오브젝트
    public GameObject bossObject;

    // 보스 체력 감소 함수
    public void DecreaseBossHealth()
    {
        BossHp = MaxHealth * bossHealthDecreasePercentage;
        Debug.Log("보스 체력이 20% 감소했습니다!");
    }
}
