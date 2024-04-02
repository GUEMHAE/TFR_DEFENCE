using UnityEngine;
using UnityEngine.UI;

public class RandomUnitSelector : MonoBehaviour
{
    public DisplaySelectedUnit displayUnitScript; // DisplaySelectedUnit 스크립트 참조
    public UnitData[] unitPool; // 랜덤으로 선택할 유닛들의 배열

    // 랜덤하게 유닛을 선택하여 해당 이미지를 표시하는 함수
    public void SelectRandomUnitAndDisplayImage()
    {
        // 유닛 풀에서 랜덤하게 유닛 선택
        UnitData randomUnit = unitPool[Random.Range(0, unitPool.Length)];

        // 선택된 유닛의 이미지를 DisplaySelectedUnit 스크립트를 통해 표시
        displayUnitScript.DisplayRandomUnitImage(randomUnit.unitImage);
    }
}
