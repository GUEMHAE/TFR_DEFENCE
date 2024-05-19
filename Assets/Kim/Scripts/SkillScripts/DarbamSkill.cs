using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarbamSkill : MonoBehaviour
{
    [SerializeField]
    public float damage = 20f;

    public void SetDamage(float damage) // 데미지 설정
    {
        this.damage = damage / 1.5f;
    }

    private void Update()
    {
        Destroy(gameObject, 10f);
    }
}
