using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptsP : MonoBehaviour
{
    public string targetTag; // 스크립트를 추가할 대상 태그

    void Start()
    {
        // 대상 태그를 가진 모든 오브젝트를 찾습니다.
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(targetTag);

        // 각 오브젝트에 스크립트를 추가합니다.
        foreach (GameObject obj in taggedObjects)
        {
            if (!obj.GetComponent<TutorialScripts>())
            {
                // TutorialScripts 스크립트를 찾아서 없다면 추가합니다.
                var tutorialScript = obj.AddComponent<TutorialScripts>();

                // TutorialScripts 스크립트에 설정된 변수를 이 스크립트에서 참조합니다.
                //tutorialScript.ep_IMGGrid = GameObject.Find("6");
                tutorialScript.GridName = "111"; // 배치석 이름 설정
                tutorialScript.IMG_Grid = GameObject.Find("GridEP");
                tutorialScript.waitsName = "222"; // 대기석 이름 설정
                tutorialScript.IMG_waits = GameObject.Find("waitEP");
                tutorialScript.goGrid = GameObject.Find("goGrid");
                tutorialScript.enemy_0 = GameObject.Find("enemy_0");
            }
        }
    }
}
