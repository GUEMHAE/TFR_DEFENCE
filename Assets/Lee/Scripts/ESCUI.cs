using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESCUI : MonoBehaviour
{

    public GameObject Shop;
    public bool isTab = false;

    // Start is called before the first frame update
    void Start()
    {
        Shop.SetActive(false); // �̹��� ��Ȱ��ȭ
    }

    // Update is called once per frame
    void Update()
    {
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
}
