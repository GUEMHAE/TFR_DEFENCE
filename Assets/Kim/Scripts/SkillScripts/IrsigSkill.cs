using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrsigSkill : MonoBehaviour
{
    public float damage;

    public void SetDamage(float damage) // ������ ����
    {
        this.damage = damage * 2.1f;
    }

    private void Update()
    {
        Destroy(this.gameObject, 4f);
    }
}
