using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tonir : MonoBehaviour
{
    public UnitInfo unitInfo;
    public GameObject enemy;
    public List<GameObject> foundEnemy;
    public float shortDis;
    public string tagName="Enemy";

    void Start()
    {

    }

    private void OnEnable()
    {
        Debug.Log("Tonir - UnitName:" + unitInfo.UnitName + "Cost:" + unitInfo.Cost + "SellCost:" + unitInfo.SellCost + "Grade:" + unitInfo.Grade +
            "AD:" + unitInfo.Ad + "ap:" + unitInfo.Ap + "AttackSpeed:" + unitInfo.AttackSpeed + "AttackRange:" + unitInfo.AttackRange);

    }

    void Update()
    {
        foundEnemy = new List<GameObject>(GameObject.FindGameObjectsWithTag(tagName));
        shortDis = Vector3.Distance(gameObject.transform.position, foundEnemy[0].transform.position);
        enemy = foundEnemy[0];

        foreach (GameObject found in foundEnemy)
        {
            float Distance = Vector3.Distance(gameObject.transform.position, found.transform.position);

            if (Distance < shortDis)
            {
                enemy = found;
                shortDis = Distance;
            }

            Debug.Log(enemy.name);
        }
    }
}
