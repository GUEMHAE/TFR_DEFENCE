using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    Place_Point place;
    public bool canPlace;

    void Update()
    {
        // 부모 오브젝트를 가져옵니다.
        Transform parentObject = transform;

        // 자식 오브젝트가 있는지 확인합니다.
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
