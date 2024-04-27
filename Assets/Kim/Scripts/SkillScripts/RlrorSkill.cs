using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cysharp.Threading.Tasks;

public class RlrorSkill : MonoBehaviour
{
    [SerializeField]
    public Transform attackTarget; //���ݴ��
    public CircleCollider2D circleCollider2D;

    public float damage = 1200f;

    public void SkillTargeting(Transform target) //���ݴ�� ����
    {
        this.attackTarget = target;
    }

    async UniTaskVoid Start()
    {
        await UniTask.Delay(500);
        circleCollider2D.enabled = true; // CircleCollider2D ������Ʈ�� Ȱ��ȭ�մϴ�.
        await UniTask.Delay(100);
        circleCollider2D.enabled = false;
    }
}
