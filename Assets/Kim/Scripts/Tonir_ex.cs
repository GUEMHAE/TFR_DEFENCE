using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tonir_ex : MyUnit
{
    private enum State { Idle,Move,Attack,UpGrade}

    private State _curState;
    private FSM _fsm;

    public UnitInfo tonir = new UnitInfo("토니르",1,1,1,50,0,"light");

    void Start()
    {
        _curState = State.Idle;
        _fsm = new FSM(new UnitIdleState(this));
    }

    void Update()
    {
        switch(_curState)
        {
            case State.Idle :
                if(DetectEnemy())
                {
                    if (AttackEnemy())
                        ChangeState(State.Attack);
                    else
                        ChangeState(State.Move);
                }
                break;
            case State.Move :
                if(DetectEnemy())
                {
                    if (AttackEnemy())
                        ChangeState(State.Attack);
                }
                else if(UpGrade())
                {
                    ChangeState(State.UpGrade);
                }
                else
                    ChangeState(State.Idle);
                break;
            case State.Attack :
                if(DetectEnemy())
                {
                    if (!AttackEnemy())
                        ChangeState(State.Move);
                }
                else
                    ChangeState(State.Idle);
                break;
            case State.UpGrade :
                ChangeState(State.Idle);
                tonir.grade = 2;
                tonir.sellCost = 3;
                break;
        }
        _fsm.UpdateState();
    }

    private void ChangeState(State nextState)
    {
        _curState = nextState;
        switch(_curState)
        {
            case State.Idle :
                _fsm.ChangeState(new UnitIdleState(this));
                break;
            case State.Move :
                _fsm.ChangeState(new UnitIdleState(this));
                break;
            case State.Attack:
                _fsm.ChangeState(new UnitIdleState(this));
                break;
        }
    }

    private bool DetectEnemy() //적 탐지 구현
    {
        return true;
    }

    private bool AttackEnemy() //사정거리 체크 구현
    {
        return true;
    }
    bool UpGrade() //유닛 등급 업그레이드시 구현
    {
        return true;
    }
}
