using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitUnitControll : MonoBehaviour
{
    [SerializeField]
    Behaviour UnitScript;//������ ��ũ��Ʈ�� �ֱ� ���� Behaviour�� ��ũ��Ʈ�� �޾ƿ�

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("InGrid"))
            {
                UnitScript.enabled = true; // Unit ��ũ��Ʈ Ȱ��ȭ
            }
            else if (collision.gameObject.layer == LayerMask.NameToLayer("Wait"))
            {
                UnitScript.enabled = false; // Unit ��ũ��Ʈ ��Ȱ��ȭ
            }
        }
    }
}
