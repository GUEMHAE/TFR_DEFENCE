using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsusSkill : MonoBehaviour
{
    [SerializeField]
    public float damage;

    public void SetDamage(float damage) // ������ ����
    {
        this.damage = damage*2f;
    }

    private void Update()
    {
        Destroy(this.gameObject, 8f);
    }
}
