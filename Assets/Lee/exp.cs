using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class exp : MonoBehaviour
{
    public TMP_Text expText;   // 경험치를 표시할 텍스트 UI
    public TMP_Text levelText; // 레벨을 표시할 텍스트 UI
    public Button expButton; // 경험치를 증가시킬 버튼

    private float interval = 60f; // 경험치가 증가하는 간격 (초 단위)
    private int round = 1;       // 현재 라운드를 저장하는 변수
    private int experience;  // 경험치를 저장하는 변수
    private int level = 0;       // 현재 레벨을 저장하는 변수

    void Start()
    {
        expText = Round.instance.expText;
        experience = Round.instance.exp;

        // 버튼에 클릭 이벤트 연결
        expButton.onClick.AddListener(IncreaseExperience);
    }

    void Update()
    {
        // 경험치 텍스트 업데이트
       // expText.text = "Experience: " + experience.ToString();

        // 레벨 텍스트 업데이트
        levelText.text = "Level: " + level.ToString();


        // 경험치가 일정 수준 이상인 경우 레벨 업
        if (experience >= GetExperienceRequiredForLevelUp(level))
        {
            level++;
            experience = 0; // 경험치 초기화
        }
    }

    // 경험치 증가 함수
    void IncreaseExperience()
    {
        experience += 3;
    }

    // 레벨업에 필요한 경험치 양 반환 함수
    int GetExperienceRequiredForLevelUp(int currentLevel)
    {
        // 각 레벨별로 필요한 경험치 양 설정
        switch (currentLevel)
        {
            case 0: return 2;
            case 1: return 6;
            case 2: return 12;
            case 3: return 18;
            case 4: return 28;
            default: return int.MaxValue; // 최대값으로 설정하여 이후 레벨업 없음을 의미
        }
    }
}
