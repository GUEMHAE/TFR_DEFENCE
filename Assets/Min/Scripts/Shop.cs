using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public PlayerManager playerManager; // 플레이어 매니저 참조
    public Text goldText; // UI Text 요소
    public RandomUnitSelector randomUnitSelector; // 랜덤 유닛 선택기 스크립트 참조

    // 상점에서 유닛을 구매하는 함수
    public void BuyUnit()
    {
        // 구매에 필요한 골드
        int unitCost = 1; // 예시로 1으로 설정

        // 플레이어의 골드가 유닛의 코스트보다 많을 경우에만 유닛을 구매
        if (playerManager.gold >= unitCost)
        {
            // 플레이어 골드 감소
            playerManager.DecreaseGold(unitCost);

            // 골드 텍스트 업데이트
            UpdateGoldText();

            // 랜덤하게 유닛 선택 및 이미지 표시
            randomUnitSelector.SelectRandomUnitAndDisplayImage();
        }
        else
        {
            Debug.Log("골드가 부족합니다.");
        }
    }

    // 골드 텍스트 업데이트 함수
    void UpdateGoldText()
    {
        goldText.text = "Gold: " + playerManager.gold.ToString();
    }
}
