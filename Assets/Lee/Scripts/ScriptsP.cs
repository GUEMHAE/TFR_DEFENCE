using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptsP : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌된 모든 오브젝트들에 대해 반복합니다.
        foreach (var contact in collision.contacts)
        {
            // 충돌된 오브젝트에 TutorialScripts 스크립트가 추가되어 있는지 확인합니다.
            TutorialScripts tutorialScript = contact.collider.gameObject.GetComponent<TutorialScripts>();
            if (tutorialScript == null)
            {
                // 스크립트가 없는 경우 스크립트를 추가합니다.
                tutorialScript = contact.collider.gameObject.AddComponent<TutorialScripts>();
                Debug.Log("jj");
            }

            // ApplyCollision 함수를 호출하여 작업을 수행합니다.
            tutorialScript.ApplyCollision(contact.collider.gameObject);
        }
    }
}
