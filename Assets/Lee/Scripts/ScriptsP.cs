using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptsP : MonoBehaviour
{
    public string targetTag;
    public GameObject enemy_0;
    public GameObject IMG_waits;

    private GameObject enemyPoolObj;
    private GameObject unit222;

    void Start()
    {
        enemyPoolObj = GameObject.Find("EnemyPool");
        unit222 = GameObject.Find("222");
        TimeManager.instance.isRoundTime = false;
        TScript();
    }

    void OnEnable()
    {
        Invoke("ui_false", 1f);
    }

    private void LateUpdate()
    {
        if (enemyPoolObj != null)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length == 0)
            {
                enemy_0.SetActive(true);
                IMG_waits.SetActive(true);
                ui_false();
            }
        }
    }

    private void TScript()
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(targetTag);
        foreach (GameObject obj in taggedObjects)
        {
            if (!obj.GetComponent<TutorialScripts>())
            {
                var tutorialScript = obj.AddComponent<TutorialScripts>();
                tutorialScript.GridName = "111";
                tutorialScript.IMG_Grid = GameObject.Find("GridEP");
                tutorialScript.goGrid = GameObject.Find("goGrid");
            }
        }
    }

    private void ui_false()
    {
        if (unit222 != null)
        {
            Transform[] childTransforms = unit222.GetComponentsInChildren<Transform>();
            foreach (Transform childTransform in childTransforms)
            {
                if (childTransform.CompareTag("Unit"))
                {
                    enemy_0.SetActive(false);
                    IMG_waits.SetActive(false);
                    break;
                }
            }
        }
    }
}