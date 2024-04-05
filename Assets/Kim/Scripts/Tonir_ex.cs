using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tonir_ex : MyUnit
{
    private enum State { Idle,Move,Attack,UpGrade}

    private State _curState;
    private FSM _fsm;

    public UnitInfo tonir = new UnitInfo("��ϸ�",1,1,1,50,0,"light");

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

    private bool DetectEnemy() //�� Ž�� ����
    {
        return true;
    }

    private bool AttackEnemy() //�����Ÿ� üũ ����
    {
        return true;
    }
    bool UpGrade() //���� ��� ���׷��̵�� ����
    {
        return true;
    }
}
