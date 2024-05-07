using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uintscriptfalse : MonoBehaviour
{
    //private TimeManager sp_Time; // Buy_Unit 스크립트에 대한 참조
    //private Round sp_Round; // Buy_Unit 스크립트에 대한 참조

    public GameObject escImage; // esc 이미지 표시할 게임 오브젝트
    public bool isimage = false; // esc 이미지의 여부 저장

    public GameObject Ttab;
    public bool isTab = false;

    public GameObject Tabtext;
    public GameObject Expup;

    void Awake()
    {
        escImage.SetActive(false); // 이미지 비활성화
        Ttab.SetActive(false); // 이미지 비활성화
    }

    //void Start()
    //{
    //    // Buy_Unit 스크립트를 가진 게임 오브젝트를 찾고 해당 스크립트를 가져옵니다.
    //    sp_Time = GameObject.FindObjectOfType<TimeManager>();
    //    sp_Round = GameObject.FindObjectOfType<Round>();

    //    // 스크립트가 존재하는 경우에만 활성화 상태를 변경합니다.
    //    if (sp_Time != null)
    //    {
    //        sp_Time.enabled = false; // 스크립트 비활성화
    //    }
    //    // 스크립트가 존재하는 경우에만 활성화 상태를 변경합니다.
    //    if (sp_Round != null)
    //    {
    //        sp_Round.enabled = false; // 스크립트 비활성화
    //    }
    //}

    void Update()
    {
        // ESC 키를 누르면 이미지를 활성화
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isimage = !isimage; // 활성화 상태 반전

            if (isimage)
            {
                escImage.SetActive(true); // 활성화
                Time.timeScale = 0;
            }
            else
            {
                escImage.SetActive(false); //비활성화
                Time.timeScale = 1;
            }
        }

        // Tab 키를 누르면 이미지를 활성화
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isTab = !isTab; // 활성화 상태 반전

            if (isTab)
            {
                Ttab.SetActive(true); // 활성화
                Tabtext.SetActive(false);
                Expup.SetActive(true);
            }
            else
                Ttab.SetActive(false); //비활성화
        }


    }

    //// 버튼이 클릭되었을 때 호출되는 함수
    //public void TaskOnClick()
    //{
    //    // 스크립트가 비활성화된 경우에만 활성화합니다.
    //    if (!sp_Time.enabled)
    //    {
    //        sp_Time.enabled = true; // 스크립트 활성화
    //    }
    //    // 스크립트가 비활성화된 경우에만 활성화합니다.
    //    if (!sp_Round.enabled)
    //    {
    //        sp_Round.enabled = true; // 스크립트 활성화
    //    }
    //}
}
