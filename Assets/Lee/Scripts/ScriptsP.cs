using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptsP : MonoBehaviour
{
    public GameObject scriptPrefab; // 스크립트 프리팹

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wait2")) // 충돌한 오브젝트의 태그를 확인하여 필요한 경우에만 스크립트를 추가합니다.
        {
            // 충돌한 오브젝트에 스크립트를 추가합니다.
            collision.gameObject.AddComponent<TutorialScripts>();
        }
    }
}
