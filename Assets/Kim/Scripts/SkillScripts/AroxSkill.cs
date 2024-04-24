using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroxSkill : MonoBehaviour
{
    [SerializeField]
    public float damage =40f;

    private void Update()
    {
        Destroy(gameObject, 6f);
    }
}
