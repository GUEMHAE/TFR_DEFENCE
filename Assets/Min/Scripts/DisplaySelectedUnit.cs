using UnityEngine;
using UnityEngine.UI;

public class DisplaySelectedUnit : MonoBehaviour
{
    public RawImage unitImage; // UI에서 이미지를 표시할 RawImage 요소

    // 랜덤하게 선택된 유닛의 이미지를 표시하는 함수
    public void DisplayRandomUnitImage(Texture2D unitTexture)
    {
        // 유닛 이미지가 유효한 경우에만 이미지를 표시
        if (unitTexture != null)
        {
            unitImage.texture = unitTexture; // RawImage의 texture 속성을 선택된 유닛의 이미지로 설정
            unitImage.enabled = true; // RawImage를 활성화하여 이미지를 표시
        }
        else
        {
            Debug.LogError("유효하지 않은 유닛 이미지입니다.");
        }
    }
}
