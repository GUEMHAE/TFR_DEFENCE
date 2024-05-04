using UnityEngine;

public class BossHealthDecreaseArtifact : MonoBehaviour
{
    // ������ ü���� ���ҽ�Ű�� ����
    private float bossHealthDecreasePercentage = 0.2f;

    public float MaxHealth = 100f;
    public float BossHp = 100f;

    // ���� ������Ʈ
    public GameObject bossObject;

    // ���� ü�� ���� �Լ�
    public void DecreaseBossHealth()
    {
        BossHp = MaxHealth * bossHealthDecreasePercentage;
        Debug.Log("���� ü���� 20% �����߽��ϴ�!");
    }
}
