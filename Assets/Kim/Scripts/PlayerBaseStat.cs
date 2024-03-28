using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState //�÷��̾� ������ �� ���¸� �����ϱ� ���� �߻� Ŭ����
{
    protected MyUnit _myUnit; //MyUnit�� �ൿ�� �����ϱ� ���� �뵵�� ����ϱ� ���� ����

    protected PlayerBaseState(MyUnit myUnit)
    {
        _myUnit = myUnit;
    }

    public abstract void OnstateEnter(); //���¿� ó�� �������� �� �� ���� ȣ��Ǵ� �޼���
    public abstract void OnstateUpdate(); //�� �����Ӹ��� ȣ��Ǿ�� �ϴ� �޼���
    public abstract void OnStateExit(); //���°� ����Ǹ� ȣ��Ǵ� �޼���
}
