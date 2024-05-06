using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESCUI : MonoBehaviour
{
    public GameObject escImage; // esc �̹��� ǥ���� ���� ������Ʈ
    public bool isimage = false; // esc �̹����� ���� ����

    public GameObject Ttab;
    public bool isTab = false;

    // Start is called before the first frame update
    void Awake()
    {
        escImage.SetActive(false); // �̹��� ��Ȱ��ȭ
        Ttab.SetActive(false); // �̹��� ��Ȱ��ȭ
    }

    // Update is called once per frame
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
            }
            else
                Ttab.SetActive(false); //��Ȱ��ȭ
        }


    }
}
