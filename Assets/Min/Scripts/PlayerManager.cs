using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int gold = 10; // 플레이어의 골드

    // 골드를 감소시키는 함수
    public void DecreaseGold(int amount)
    {
        gold -= amount;
    }

    // 골드를 증가시키는 함수
    public void IncreaseGold(int amount)
    {
        gold += amount;
    }
}
