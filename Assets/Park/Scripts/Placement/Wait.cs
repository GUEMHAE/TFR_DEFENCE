using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : MonoBehaviour
{
    private void Start()
    {
        if (UnitLimitManager.instance.MaxunitCount <= UnitLimitManager.instance.curUnitCount)
        {
            Debug.Log("��ġ ������ ������ ������ �ʰ���");

            // �� ������Ʈ�� ��� Collider ������Ʈ ��Ȱ��ȭ
            Collider[] colliders = GetComponents<Collider>();
            foreach (Collider collider in colliders)
            {
                collider.enabled = false;
            }
        }
    }
}
