using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uintscriptfalse : MonoBehaviour
{
    // 버튼을 클릭할 때 호출될 함수
    public void OnButtonClick()
    {
        // 비활성화할 스크립트의 게임 오브젝트를 찾습니다.
        GameObject targetObject = GameObject.Find("flasescript"); //  게임오브젝트 이름

        // 해당 스크립트가 존재한다면
        if (targetObject != null && targetObject.GetComponent<Buy_Unit>() != null) 
        {
            // 스크립트를 비활성화
            targetObject.GetComponent<Buy_Unit>().enabled = false;
        }
    }
}
