using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    Place_Point place;
    public bool canPlace;

    void Update()
    {
        // �θ� ������Ʈ�� �����ɴϴ�.
        Transform parentObject = transform;

        // �ڽ� ������Ʈ�� �ִ��� Ȯ���մϴ�.
        if (parentObject.childCount > 0)
        {
            canPlace = false;
        }
        else
        {
            canPlace = true;
        }
    }
}
