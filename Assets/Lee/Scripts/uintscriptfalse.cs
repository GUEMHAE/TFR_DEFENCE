using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uintscriptfalse : MonoBehaviour
{
    // ��ư�� Ŭ���� �� ȣ��� �Լ�
    public void OnButtonClick()
    {
        // ��Ȱ��ȭ�� ��ũ��Ʈ�� ���� ������Ʈ�� ã���ϴ�.
        GameObject targetObject = GameObject.Find("flasescript"); //  ���ӿ�����Ʈ �̸�

        // �ش� ��ũ��Ʈ�� �����Ѵٸ�
        if (targetObject != null && targetObject.GetComponent<Buy_Unit>() != null) 
        {
            // ��ũ��Ʈ�� ��Ȱ��ȭ
            targetObject.GetComponent<Buy_Unit>().enabled = false;
        }
    }
}
