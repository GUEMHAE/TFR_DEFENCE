using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using TMPro;

public class SecondBoss : MonoBehaviour
{
    [SerializeField]
    Enemy enemy;
    
    float UnitAd;//���ݷ�
    float UnitAp;//��ų���ݷ�
    float UnitAS;//���ݼӵ�

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        DebuffUnit();
    }

    public async UniTaskVoid DebuffUnit()
    {
        while (true)
        {
            await UniTask.WaitUntil(() => enemy.currentIndex == 5);

            for (int i = 0; i < UnitLimitManager.instance.allUnits.Count; i++)
            {
                var unit = UnitLimitManager.instance.allUnits[i];
                var unitInfo = unit.GetComponent<GetUnitInfo>();
                if (unitInfo != null)
                {
                    // �� �ɷ�ġ���� 10% ���ҽ�Ŵ
                    unitInfo.adP *= 0.9f;
                    unitInfo.apP *= 0.9f;
                    unitInfo.attackSpeedP *= 0.9f;

                    UnitAd = unitInfo.GetComponent<GetUnitInfo>().ad;
                    UnitAp = unitInfo.GetComponent<GetUnitInfo>().ap;
                    UnitAS = unitInfo.GetComponent<GetUnitInfo>().attackSpeed;

                    UIManager.instance.UnitAd_UI.text = UnitAd.ToString();
                    UIManager.instance.UnitAp_UI.text = UnitAp.ToString();
                    UIManager.instance.UnitAS_UI.text = UnitAS.ToString();
                }
            }

            await UniTask.WaitUntil(() => enemy.currentIndex == 0);
        }
    }

    private void OnDestroy()
    {
        // �ı��Ǵ� ������ �������� ���ҵ� �ɷ�ġ�� ���� �ɷ�ġ�� �ǵ���
        foreach (var unit in UnitLimitManager.instance.allUnits)
        {
            var unitInfo = unit.GetComponent<GetUnitInfo>();
            if (unitInfo != null)
            {
                unitInfo.ad = unitInfo.originAD;
                unitInfo.ap = unitInfo.originAP;
                unitInfo.attackSpeed = unitInfo.originAS;
                Debug.Log("���� �ɷ�ġ ����");

                UnitAd = unitInfo.GetComponent<GetUnitInfo>().ad;
                UnitAp = unitInfo.GetComponent<GetUnitInfo>().ap;
                UnitAS = unitInfo.GetComponent<GetUnitInfo>().attackSpeed;

                UIManager.instance.UnitAd_UI.text = UnitAd.ToString();
                UIManager.instance.UnitAp_UI.text = UnitAp.ToString();
                UIManager.instance.UnitAS_UI.text = UnitAS.ToString();
            }
        }
    }
}
