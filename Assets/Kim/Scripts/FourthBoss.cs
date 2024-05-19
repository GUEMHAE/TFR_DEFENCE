using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class FourthBoss : MonoBehaviour
{
    public bool isInvincible;

    [SerializeField]
    float coolTime;
    [SerializeField]
    float duration;

    public GameObject shieldParticle;
    public GameObject hpShieldParticle;
    public GameObject hpRegen;

    [SerializeField]
    Enemy enemy;

    float curHp;

    float UnitAd;//공격력
    float UnitAp;//스킬공격력
    float UnitAS;//공격속도

    private bool shieldHasRun; //쉴드 패턴이 이미 실행됬는지 확인

    bool isDestroyUnit;

    int roundCount;


    public async UniTaskVoid OneRoundBoss()
    {
        while (true)
        {
            await UniTask.WaitUntil(() => enemy.currentIndex == 5);

            enemy.hp += 5000;
            roundCount++;
            for (int i = 0; i < UnitLimitManager.instance.allUnits.Count; i++)
            {
                var unit = UnitLimitManager.instance.allUnits[i];
                var unitInfo = unit.GetComponent<GetUnitInfo>();
                if (unitInfo != null)
                {
                    // 각 능력치들을 10% 감소시킴
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

            if (roundCount % 2 != 0)
            {
                isDestroyUnit = false;
            }
        }
    }

    public async UniTaskVoid Invincible() //보스의 무적 관리하는 UniTask_첫번째 패턴
    {
        while (true)
        {
            var destroyToken = this.GetCancellationTokenOnDestroy();

            await UniTask.WaitForSeconds(coolTime, cancellationToken: destroyToken);//쿨타임 동안 대기 후 무적 활성화
            isInvincible = true;
            GameObject shield = Instantiate(shieldParticle, transform.position, Quaternion.identity, transform);
            shield.transform.SetParent(gameObject.transform);
            shield.transform.localPosition += new Vector3(-0.6f, 1.8f, 0);
            shield.transform.localScale = new Vector3(12f, 12f, 1.5f); // 필요에 따라 크기 조절
            Destroy(shield, 4f);
            await UniTask.WaitForSeconds(duration, cancellationToken: destroyToken);//지속시간 동안 무적
            isInvincible = false;
        }
    }

    public async UniTaskVoid HpRegen() //두번 째 패턴
    {
        if (!shieldHasRun)
        {
            await UniTask.WaitUntil(() => enemy.hp <= 50000);
            GameObject hpShield = Instantiate(hpShieldParticle, gameObject.transform);
            hpShield.transform.SetParent(gameObject.transform);
            hpShield.transform.localPosition += new Vector3(-0.6f, 1.8f, 0);
            hpShield.transform.localScale = new Vector3(1, 1, 1); // 필요에 따라 크기 조절
            curHp = enemy.hp;
            Debug.Log("실행");
            await UniTask.WaitForSeconds(6f);//6초동안 보스의 체력이 2000이상 달면 1000회복
            if (curHp - 20000 > enemy.hp)
            {
                GameObject heal = Instantiate(hpRegen, gameObject.transform);
                heal.transform.SetParent(gameObject.transform);
                enemy.hp += 15000;
            }
            shieldHasRun = true;
        }
    }

    private void OnDestroy()
    {
        // 파괴되는 보스의 영향으로 감소된 능력치를 원래 능력치로 되돌림
        foreach (var unit in UnitLimitManager.instance.allUnits)
        {
            var unitInfo = unit.GetComponent<GetUnitInfo>();
            if (unitInfo != null)
            {
                unitInfo.ad = unitInfo.originAD;
                unitInfo.ap = unitInfo.originAP;
                unitInfo.attackSpeed = unitInfo.originAS;
                Debug.Log("유닛 능력치 복원");

                UnitAd = unitInfo.GetComponent<GetUnitInfo>().ad;
                UnitAp = unitInfo.GetComponent<GetUnitInfo>().ap;
                UnitAS = unitInfo.GetComponent<GetUnitInfo>().attackSpeed;

                UIManager.instance.UnitAd_UI.text = UnitAd.ToString("F1");
                UIManager.instance.UnitAp_UI.text = UnitAp.ToString("F1");
                UIManager.instance.UnitAS_UI.text = UnitAS.ToString("F1");
            }
        }
    }

    private void DestroyRandomUnit() //유닛파괴 패턴
    {
        if (UnitLimitManager.instance.allUnits.Count > 0)
        {
            int randomIndex = Random.Range(0, UnitLimitManager.instance.allUnits.Count);
            GameObject unitToDestroy = UnitLimitManager.instance.allUnits[randomIndex];
            Destroy(unitToDestroy);
            UnitLimitManager.instance.allUnits.RemoveAt(randomIndex);

            isDestroyUnit = true;
        }
    }

    private void Update()
    {
        if(roundCount%2==0&&roundCount!=0&&isDestroyUnit==false)
        {
            DestroyRandomUnit();
        }
    }

    private void Start()
    {
        roundCount = 0;
        enemy = GetComponent<Enemy>();
        coolTime = 14f;
        duration = 4f;
        OneRoundBoss();
        Invincible();
        HpRegen();
    }

}
