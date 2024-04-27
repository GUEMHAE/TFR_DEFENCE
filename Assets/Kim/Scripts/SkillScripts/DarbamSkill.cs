using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarbamSkill : MonoBehaviour
{
    [SerializeField]
    public float damage = 20f;

    private void Update()
    {
        Destroy(gameObject, 10f);
    }
}
