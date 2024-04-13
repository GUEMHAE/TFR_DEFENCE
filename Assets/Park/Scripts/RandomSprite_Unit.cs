using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSprite_Unit : MonoBehaviour
{
    public Image[] imageSlots; // 4개의 이미지 슬롯
    public Sprite[] sprites; // 16개의 스프라이트를 저장할 배열

    void Start()
    {
        RandomSprite();
    }


    public void RandomSprite()
    {
        // 스프라이트를 저장할 리스트 생성
        List<Sprite> selectedSprites = new List<Sprite>();

        // 배열에서 4개의 스프라이트를 무작위로 선택하여 리스트에 추가
        for (int i = 0; i < 4; i++)
        {
            int randomIndex = Random.Range(0, sprites.Length);
            selectedSprites.Add(sprites[randomIndex]);
        }

        // 선택된 스프라이트를 각 이미지에 표시
        for (int i = 0; i < selectedSprites.Count; i++)
        {
            imageSlots[i].sprite = selectedSprites[i];
        }
    }
}
