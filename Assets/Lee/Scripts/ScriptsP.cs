using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptsP : MonoBehaviour
{
    public string targetTag; // ��ũ��Ʈ�� �߰��� ��� �±�

    void Start()
    {
        // ��� �±׸� ���� ��� ������Ʈ�� ã���ϴ�.
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(targetTag);

        // �� ������Ʈ�� ��ũ��Ʈ�� �߰��մϴ�.
        foreach (GameObject obj in taggedObjects)
        {
            if (!obj.GetComponent<TutorialScripts>())
            {
                // TutorialScripts ��ũ��Ʈ�� ã�Ƽ� ���ٸ� �߰��մϴ�.
                var tutorialScript = obj.AddComponent<TutorialScripts>();

                // TutorialScripts ��ũ��Ʈ�� ������ ������ �� ��ũ��Ʈ���� �����մϴ�.
                //tutorialScript.ep_IMGGrid = GameObject.Find("6");
                tutorialScript.GridName = "111"; // ��ġ�� �̸� ����
                tutorialScript.IMG_Grid = GameObject.Find("GridEP");
                tutorialScript.waitsName = "222"; // ��⼮ �̸� ����
                tutorialScript.IMG_waits = GameObject.Find("waitEP");
                tutorialScript.goGrid = GameObject.Find("goGrid");
                tutorialScript.enemy_0 = GameObject.Find("enemy_0");
            }
        }
    }
}
