using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uintscriptfalse : MonoBehaviour
{
    //private TimeManager sp_Time; // Buy_Unit 스크립트에 대한 참조
    //private Round sp_Round; // Buy_Unit 스크립트에 대한 참조

    //public GameObject escImage; // esc 이미지 표시할 게임 오브젝트
    public bool isimage = false; // esc 이미지의 여부 저장

    public GameObject Ttab;
    public bool isTab = false;

    public GameObject Tabtext;
    public GameObject Expup;

    public GameObject Img4;

    private bool exp = false;
    public GameObject NoSkip;

    private void Start()
    {
        Img4.SetActive(false);
    }


    void Awake()
    {
       //escImage.SetActive(false); // 이미지 비활성화
        Ttab.SetActive(false); // 이미지 비활성화
    }

    void Update()
    {

        // Tab 키를 누르면 이미지를 활성화
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isTab = !isTab; // 활성화 상태 반전

            if (isTab)
            {
                Ttab.SetActive(true); // 활성화
                Tabtext.SetActive(false);
                if (exp == false)
                {
                    Expup.SetActive(true);
                    exp = true;
                }
            }
            else
                Ttab.SetActive(false); //비활성화
        }

        if (NoSkip != null && !NoSkip.activeSelf)
        {
            Img4.SetActive(true);
        }
    }
}
