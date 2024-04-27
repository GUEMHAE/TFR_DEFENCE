using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingParticle : MonoBehaviour //Particle의 SortingOrder를 정하기 위한 스크립트
{
    [SerializeField]
    public int sortingOrder;

    private void Start()
    {
        gameObject.GetComponent<Renderer>().sortingOrder= sortingOrder;
    }
}
