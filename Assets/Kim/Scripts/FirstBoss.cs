using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class FirstBoss : MonoBehaviour
{
    public static FirstBoss instance; // 싱글톤을 할당할 전역 변수
    public delegate void UseFirstChanged();
    public static event UseFirstChanged OnUseFirstChanged;
    public GameObject bossSkillEffect;

    public bool isUseFirst;

    [SerializeField]
    float firstSkillDuration = 3f; //보스의 첫 스킬 지속시간
    [SerializeField]
    float skillColldown = 15f;

    [SerializeField]
    const float firstSkillUse=1f;

    async UniTaskVoid  BossSkill()
    {
        float ranNum = UnityEngine.Random.Range(0f, 1f);
        while(true)
        {
            if(ranNum<=firstSkillUse)
            {
                await UniTask.Delay((int)skillColldown * 1000);
                Instantiate(bossSkillEffect, gameObject.transform.position, Quaternion.identity);
                UseSkill1();
            }
        }
    }

    async UniTask UseSkill1()
    {
        Debug.Log("첫번째 스킬 사용 시작");
        isUseFirst = true;
        await UniTask.Delay((int)firstSkillDuration * 1000);
        Debug.Log("첫번째 스킬 사용 종료");
        isUseFirst = false;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        BossSkill();
    }
}
