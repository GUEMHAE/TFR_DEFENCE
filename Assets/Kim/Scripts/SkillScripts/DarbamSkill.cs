using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarbamSkill : MonoBehaviour
{
    [SerializeField]
    public float damage = 20f;

    public void SetDamage(float damage) // ������ ����
    {
        this.damage = damage / 1.5f;
    }

    private void Update()
    {
        Destroy(gameObject, 10f);
    }
}
