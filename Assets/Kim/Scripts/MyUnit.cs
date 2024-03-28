using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyUnit : MonoBehaviour
{
    public enum PlayerUnitState { Idle,Move,Attack } //¿Ø¥÷¿« ªÛ≈¬
    public PlayerUnitState playerUnitState;

    public struct UnitInfo
    {
        public string name;
        int cost;
        public int sellCost;
        public int grade;
        public int ad;
        public int ap;
        string synergy;

        public UnitInfo(string _name,int _cost,int _sellCost,int _grade,int _ad,int _ap,string _synergy)
        {
            name = _name;
            cost = _cost;
            sellCost = _sellCost;
            grade = _grade;
            ad = _ad;
            ap = _ap;
            synergy = _synergy;
        }
    }
    void Start()
    {
        playerUnitState = PlayerUnitState.Idle;
    }

    void Update()
    {
        
    }

    void UnitAction()
    {
        switch(playerUnitState)
        {
            case PlayerUnitState.Idle:

                break;
            case PlayerUnitState.Move:

                break;
            case PlayerUnitState.Attack:

                break;
        }
    }
}
