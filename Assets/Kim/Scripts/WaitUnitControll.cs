using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitUnitControll : MonoBehaviour
{
    [SerializeField]
    Behaviour UnitScript;//임의의 스크립트를 넣기 위해 Behaviour로 스크립트를 받아옴

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("InGrid"))
            {
                UnitScript.enabled = true; // Unit 스크립트 활성화
            }
            else if (collision.gameObject.layer == LayerMask.NameToLayer("Wait"))
            {
                UnitScript.enabled = false; // Unit 스크립트 비활성화
            }
        }
    }
}
