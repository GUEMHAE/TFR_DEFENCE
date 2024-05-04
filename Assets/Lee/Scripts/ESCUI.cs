using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESCUI : MonoBehaviour
{
    public GameObject escImage; // esc 이미지 표시할 게임 오브젝트
    public bool isimage = false; // esc 이미지의 여부 저장

    public GameObject Ttab;
    public bool isTab = false;

    public GameObject Tabtext;
    public GameObject Expup;

    // Start is called before the first frame update
    void Awake()
    {
        escImage.SetActive(false); // 이미지 비활성화
        Ttab.SetActive(false); // 이미지 비활성화
    }

    // Update is called once per frame
    void FixedUpdate()
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
}
