using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uintscriptfalse : MonoBehaviour
{
    //private TimeManager sp_Time; // Buy_Unit ��ũ��Ʈ�� ���� ����
    //private Round sp_Round; // Buy_Unit ��ũ��Ʈ�� ���� ����

    //public GameObject escImage; // esc �̹��� ǥ���� ���� ������Ʈ
    public bool isimage = false; // esc �̹����� ���� ����

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
       //escImage.SetActive(false); // �̹��� ��Ȱ��ȭ
        Ttab.SetActive(false); // �̹��� ��Ȱ��ȭ
    }

    void Update()
    {

        // Tab Ű�� ������ �̹����� Ȱ��ȭ
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isTab = !isTab; // Ȱ��ȭ ���� ����

            if (isTab)
            {
                Ttab.SetActive(true); // Ȱ��ȭ
                Tabtext.SetActive(false);
                if (exp == false)
                {
                    Expup.SetActive(true);
                    exp = true;
                }
            }
            else
                Ttab.SetActive(false); //��Ȱ��ȭ
        }

        if (NoSkip != null && !NoSkip.activeSelf)
        {
            Img4.SetActive(true);
        }
    }
}
