using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uintscriptfalse : MonoBehaviour
{
    private TimeManager sp_Time; // Buy_Unit ��ũ��Ʈ�� ���� ����
    private Round sp_Round; // Buy_Unit ��ũ��Ʈ�� ���� ����


    void Start()
    {
        // Buy_Unit ��ũ��Ʈ�� ���� ���� ������Ʈ�� ã�� �ش� ��ũ��Ʈ�� �����ɴϴ�.
        sp_Time = GameObject.FindObjectOfType<TimeManager>();
        sp_Round = GameObject.FindObjectOfType<Round>();

        // ��ũ��Ʈ�� �����ϴ� ��쿡�� Ȱ��ȭ ���¸� �����մϴ�.
        if (sp_Time != null)
        {
            sp_Time.enabled = false; // ��ũ��Ʈ ��Ȱ��ȭ
        }
        // ��ũ��Ʈ�� �����ϴ� ��쿡�� Ȱ��ȭ ���¸� �����մϴ�.
        if (sp_Round != null)
        {
            sp_Round.enabled = false; // ��ũ��Ʈ ��Ȱ��ȭ
        }
    }

    // ��ư�� Ŭ���Ǿ��� �� ȣ��Ǵ� �Լ�
    public void TaskOnClick()
    {
        // ��ũ��Ʈ�� ��Ȱ��ȭ�� ��쿡�� Ȱ��ȭ�մϴ�.
        if (!sp_Time.enabled)
        {
            sp_Time.enabled = true; // ��ũ��Ʈ Ȱ��ȭ
        }
        // ��ũ��Ʈ�� ��Ȱ��ȭ�� ��쿡�� Ȱ��ȭ�մϴ�.
        if (!sp_Round.enabled)
        {
            sp_Round.enabled = true; // ��ũ��Ʈ Ȱ��ȭ
        }
    }
}
