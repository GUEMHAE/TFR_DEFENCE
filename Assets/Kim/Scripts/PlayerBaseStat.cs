using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState //플레이어 유닛의 각 상태를 구현하기 위한 추상 클래스
{
    protected MyUnit _myUnit; //MyUnit의 행동을 제어하기 위한 용도로 사용하기 위한 변수

    protected PlayerBaseState(MyUnit myUnit)
    {
        _myUnit = myUnit;
    }

    public abstract void OnstateEnter(); //상태에 처음 진입했을 때 한 번만 호출되는 메서드
    public abstract void OnstateUpdate(); //매 프레임마다 호출되어야 하는 메서드
    public abstract void OnStateExit(); //상태가 변경되면 호출되는 메서드
}
