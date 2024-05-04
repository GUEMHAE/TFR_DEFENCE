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
        Shop.SetActive(false); // 이미지 비활성화
    }

    // Update is called once per frame
    void Update()
    {
        // Tab 키를 누르면 이미지를 활성화
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isTab = !isTab; // 활성화 상태 반전

            if (isTab)
            {
                Shop.SetActive(true); // 활성화
            }
            else
                Shop.SetActive(false); //비활성화
        }


    }
}
