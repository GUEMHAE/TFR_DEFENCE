using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptsP : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �浹�� ��� ������Ʈ�鿡 ���� �ݺ��մϴ�.
        foreach (var contact in collision.contacts)
        {
            // �浹�� ������Ʈ�� TutorialScripts ��ũ��Ʈ�� �߰��Ǿ� �ִ��� Ȯ���մϴ�.
            TutorialScripts tutorialScript = contact.collider.gameObject.GetComponent<TutorialScripts>();
            if (tutorialScript == null)
            {
                // ��ũ��Ʈ�� ���� ��� ��ũ��Ʈ�� �߰��մϴ�.
                tutorialScript = contact.collider.gameObject.AddComponent<TutorialScripts>();
                Debug.Log("jj");
            }

            // ApplyCollision �Լ��� ȣ���Ͽ� �۾��� �����մϴ�.
            tutorialScript.ApplyCollision(contact.collider.gameObject);
        }
    }
}
