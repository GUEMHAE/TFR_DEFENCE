using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

public interface IEnemy
{
    string enemyName { get; set; }
    int enemyHp { get; set; }
}