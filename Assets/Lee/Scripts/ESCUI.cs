using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESCUI : MonoBehaviour
{
    public GameObject escImage; // esc �̹��� ǥ���� ���� ������Ʈ
    public bool isimage = false; // esc �̹����� ���� ����

    public GameObject Shop;
    public bool isTab = false;
    // Start is called before the first frame update
    void Start()
    {
        escImage.SetActive(false); // �̹��� ��Ȱ��ȭ
        Shop.SetActive(false); // �̹��� ��Ȱ��ȭ
    }

    // Update is called once per frame
    void Update()
    {
        // ESC Ű�� ������ �̹����� Ȱ��ȭ
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isimage = !escImage.activeSelf; // Ȱ��ȭ ���� ����

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
                Shop.SetActive(true); // Ȱ��ȭ
            }
            else
                Shop.SetActive(false); //��Ȱ��ȭ
        }


    }
    public void OnButtonClick()
    {
        escImage.SetActive(false); //��Ȱ��ȭ
        Time.timeScale = 1;
    }
}
