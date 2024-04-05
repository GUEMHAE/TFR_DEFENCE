using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Exp : MonoBehaviour
{
    public TMP_Text expText;   // 경험치를 표시할 텍스트 UI
    public TMP_Text levelText; // 레벨을 표시할 텍스트 UI

    private float interval = 60f; // 경험치가 증가하는 간격 (초 단위)
    private int round = 1;       // 현재 라운드를 저장하는 변수
    private int exp = 0;  // 경험치를 저장하는 변수
    private int level = 0;       // 현재 레벨을 저장하는 변수

    void Start()
    {
        //expText = Round.instance.expText;
        //exp = Round.instance.exp;
    }

    void Update()
    {
        // 경험치 텍스트 업데이트
       // expText.text = "Experience: " + experience.ToString();

        // 레벨 텍스트 업데이트
        levelText.text = "Level: " + level.ToString();


        // 경험치가 일정 수준 이상인 경우 레벨 업
        if (exp >= GetExperienceRequiredForLevelUp(level))
        {
            if (level < 6)
            {
                level++;
                exp = 0; // 경험치 초기화
            }
            exp = 0;
        }
    }

    // 경험치 증가 함수
    public void IncreaseExperience()
    {
        exp += 3;

        expText.text = "Exp: " + exp.ToString();
    }

    // 레벨업에 필요한 경험치 양 반환 함수
    public int GetExperienceRequiredForLevelUp(int currentLevel)
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
