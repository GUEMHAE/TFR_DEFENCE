using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : MonoBehaviour
{
    private void Start()
    {
        if (UnitLimitManager.instance.MaxunitCount <= UnitLimitManager.instance.curUnitCount)
        {
            Debug.Log("배치 가능한 유닛의 개수가 초과됨");

            // 이 오브젝트의 모든 Collider 컴포넌트 비활성화
            Collider[] colliders = GetComponents<Collider>();
            foreach (Collider collider in colliders)
            {
                collider.enabled = false;
            }
        }
    }
}
