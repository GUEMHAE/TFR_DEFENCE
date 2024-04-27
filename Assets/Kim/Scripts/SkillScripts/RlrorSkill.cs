using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cysharp.Threading.Tasks;

public class RlrorSkill : MonoBehaviour
{
    [SerializeField]
    public Transform attackTarget; //공격대상
    public CircleCollider2D circleCollider2D;

    public float damage = 1200f;

    public void SkillTargeting(Transform target) //공격대상 설정
    {
        this.attackTarget = target;
    }

    async UniTaskVoid Start()
    {
        await UniTask.Delay(500);
        circleCollider2D.enabled = true; // CircleCollider2D 컴포넌트를 활성화합니다.
        await UniTask.Delay(100);
        circleCollider2D.enabled = false;
    }
}
