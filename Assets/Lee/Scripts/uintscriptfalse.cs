using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uintscriptfalse : MonoBehaviour
{
    //private TimeManager sp_Time; // Buy_Unit ��ũ��Ʈ�� ���� ����
    //private Round sp_Round; // Buy_Unit ��ũ��Ʈ�� ���� ����

    public GameObject escImage; // esc �̹��� ǥ���� ���� ������Ʈ
    public bool isimage = false; // esc �̹����� ���� ����

    public GameObject Ttab;
    public bool isTab = false;

    public GameObject Tabtext;
    public GameObject Expup;

    void Awake()
    {
        escImage.SetActive(false); // �̹��� ��Ȱ��ȭ
        Ttab.SetActive(false); // �̹��� ��Ȱ��ȭ
    }

    //void Start()
    //{
    //    // Buy_Unit ��ũ��Ʈ�� ���� ���� ������Ʈ�� ã�� �ش� ��ũ��Ʈ�� �����ɴϴ�.
    //    sp_Time = GameObject.FindObjectOfType<TimeManager>();
    //    sp_Round = GameObject.FindObjectOfType<Round>();

    //    // ��ũ��Ʈ�� �����ϴ� ��쿡�� Ȱ��ȭ ���¸� �����մϴ�.
    //    if (sp_Time != null)
    //    {
    //        sp_Time.enabled = false; // ��ũ��Ʈ ��Ȱ��ȭ
    //    }
    //    // ��ũ��Ʈ�� �����ϴ� ��쿡�� Ȱ��ȭ ���¸� �����մϴ�.
    //    if (sp_Round != null)
    //    {
    //        sp_Round.enabled = false; // ��ũ��Ʈ ��Ȱ��ȭ
    //    }
    //}

    void Update()
    {
        // ESC Ű�� ������ �̹����� Ȱ��ȭ
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isimage = !isimage; // Ȱ��ȭ ���� ����

            if (isimage)
            {
                escImage.SetActive(true); // Ȱ��ȭ
                Time.timeScale = 0;
            }
            else
            {
                escImage.SetActive(false); //��Ȱ��ȭ
                Time.timeScale = 1;
            }
        }

        // Tab Ű�� ������ �̹����� Ȱ��ȭ
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isTab = !isTab; // Ȱ��ȭ ���� ����

            if (isTab)
            {
                Ttab.SetActive(true); // Ȱ��ȭ
                Tabtext.SetActive(false);
                Expup.SetActive(true);
            }
            else
                Ttab.SetActive(false); //��Ȱ��ȭ
        }


    }

    //// ��ư�� Ŭ���Ǿ��� �� ȣ��Ǵ� �Լ�
    //public void TaskOnClick()
    //{
    //    // ��ũ��Ʈ�� ��Ȱ��ȭ�� ��쿡�� Ȱ��ȭ�մϴ�.
    //    if (!sp_Time.enabled)
    //    {
    //        sp_Time.enabled = true; // ��ũ��Ʈ Ȱ��ȭ
    //    }
    //    // ��ũ��Ʈ�� ��Ȱ��ȭ�� ��쿡�� Ȱ��ȭ�մϴ�.
    //    if (!sp_Round.enabled)
    //    {
    //        sp_Round.enabled = true; // ��ũ��Ʈ Ȱ��ȭ
    //    }
    //}
}
