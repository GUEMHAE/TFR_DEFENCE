using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptsP : MonoBehaviour
{
    public GameObject scriptPrefab; // ��ũ��Ʈ ������

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wait2")) // �浹�� ������Ʈ�� �±׸� Ȯ���Ͽ� �ʿ��� ��쿡�� ��ũ��Ʈ�� �߰��մϴ�.
        {
            // �浹�� ������Ʈ�� ��ũ��Ʈ�� �߰��մϴ�.
            collision.gameObject.AddComponent<TutorialScripts>();
        }
    }
}
