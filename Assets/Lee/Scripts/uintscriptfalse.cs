using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uintscriptfalse : MonoBehaviour
{
    private TimeManager sp_Time; // Buy_Unit 스크립트에 대한 참조
    private Round sp_Round; // Buy_Unit 스크립트에 대한 참조


    void Start()
    {
        // Buy_Unit 스크립트를 가진 게임 오브젝트를 찾고 해당 스크립트를 가져옵니다.
        sp_Time = GameObject.FindObjectOfType<TimeManager>();
        sp_Round = GameObject.FindObjectOfType<Round>();

        // 스크립트가 존재하는 경우에만 활성화 상태를 변경합니다.
        if (sp_Time != null)
        {
            sp_Time.enabled = false; // 스크립트 비활성화
        }
        // 스크립트가 존재하는 경우에만 활성화 상태를 변경합니다.
        if (sp_Round != null)
        {
            sp_Round.enabled = false; // 스크립트 비활성화
        }
    }

    // 버튼이 클릭되었을 때 호출되는 함수
    public void TaskOnClick()
    {
        // 스크립트가 비활성화된 경우에만 활성화합니다.
        if (!sp_Time.enabled)
        {
            sp_Time.enabled = true; // 스크립트 활성화
        }
        // 스크립트가 비활성화된 경우에만 활성화합니다.
        if (!sp_Round.enabled)
        {
            sp_Round.enabled = true; // 스크립트 활성화
        }
    }
}
