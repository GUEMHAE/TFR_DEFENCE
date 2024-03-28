using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM 
{
    private PlayerBaseState _curState;

    public FSM(PlayerBaseState initState)
    {
        _curState = initState;
        ChangeState(_curState);
    }

    public void ChangeState(PlayerBaseState nextState)
    {
        if (nextState == _curState)
            return;

        if(_curState!=null)
        {
            _curState.OnStateExit();
            _curState = nextState;
            _curState.OnstateEnter();
        }
    }

    public void UpdateState()
    {
        if(_curState!=null)
        {
            _curState.OnstateUpdate();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
