using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Exp : MonoBehaviour
{
    public TMP_Text levelText; // 레벨을 표시할 텍스트 UI

    public float exp;  // 경험치를 저장하는 변수
    private float level = 0;  // 현재 레벨을 저장하는 변수
    public float expBar; // 레벨까지 필요한 경험치
    public Slider ExpBarSlider; // 경험치 슬라이더
    public TMP_Text exping; // 현재 경험치 / 레벨까지 필요한 경험치

    void Start()
    {
        ExpBarSlider.value = (float)exp / (float)expBar; // Exp의 값을 현재 경험치 / 레벨까지 필요한 경험치로 시작
    }


    void Update()
    {
        exp = Round.instance.exp; // Round 스크립트에 있는 exp에 저장
        expBar = Levelup(level); // 레벨 업 할 때마다 필요한 경험치 양을 갱신

        exping.text = exp.ToString() + " / " + expBar.ToString();

        // 레벨 텍스트 업데이트
        levelText.text = "Level: " + level.ToString();


        // 경험치가 일정 수준 이상인 경우 레벨 업
        if (exp >= Levelup(level))
        {
            if (level < 6) //6레벨 까지 반복
            {
                Round.instance.exp -= Levelup(level); // 필요항 경험치를 총 경험치에서 뺌
                level++; // 레벨 업
            }
            else
                Round.instance.exp = 0; // 최대 레벨까지 가면 경험치 0으로 초기화 // 더 이상 얻지 못함
        }
    }



    // 버튼 클릭 경험치 증가 함수
    public void IncreaseExperience()
    {
        Round.instance.exp += 3;
        CheckExp();
    }

    public void CheckExp()
    {
            ExpBarSlider.value = (float)exp / (float)expBar;
    }

    // 레벨업에 필요한 경험치 양 반환 함수
    public float Levelup(float currentLevel)
    {
        // 각 레벨별로 필요한 경험치 양 설정
        switch (currentLevel)
        {
            case 1: return 2;
            case 2: return 6;
            case 3: return 12;
            case 4: return 18;
            case 5: return 28;
            case 6: return 0;
        }
        return exp;
    }
}
