using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text roundTime; //���� ���� �ð� ǥ�����ִ� UI
    [SerializeField]
    TMP_Text _currentRound; //���� ���� ǥ�� ���ִ� UI

    float _roundTime; //���� ���� �ð� �޾ƿ��� ����

    [SerializeField]
    GameObject bossWarning;

    [SerializeField]
    Button synergyButton; //�ó��� ǥ�� ��ư
    [SerializeField]
    GameObject synergyPannel; //�ó��� ǥ�� �г�

    [SerializeField]
    TMP_Text goldText;

    public bool isSynergyPannelOn;

    string UnitName;
    float UnitAd;//���ݷ�
    float UnitAp;//��ų���ݷ�
    float UnitAS;//���ݼӵ�
    float UnitAR;//���ݻ�Ÿ�

    [Header("-���� ���� UI")]
    [SerializeField]
    TMP_Text UnitName_UI;
    [SerializeField]
    TMP_Text UnitAd_UI;//���ݷ� ǥ��
    [SerializeField]
    TMP_Text UnitAp_UI;//��ų���ݷ� ǥ��
    [SerializeField]
    TMP_Text UnitAS_UI;//���ݼӵ� ǥ��
    [SerializeField]
    TMP_Text UnitAR_UI;//���ݻ�Ÿ� ǥ��

    [SerializeField]
    Image Synergy1; //�ó��� ǥ�� UI ù ��°
    [SerializeField]
    Image Synergy2; //�ó��� ǥ�� UI �� ����
    [SerializeField]
    GameObject _Synergy2; //�ó��� ǥ�� UI�ι�°�� ���� �ѱ� ����
    [SerializeField]
    Sprite[] Synergys; //�ó��� UI�迭
    [SerializeField]
    UnitType[] UnitType;
    [SerializeField]
    TMP_Text SynergyText1;
    [SerializeField]
    TMP_Text SynergyText2;
    [SerializeField]
    GameObject _SynergyText2;//�ó��� �̸� ǥ�� UI�ι�°�� ���� �ѱ� ����
    [SerializeField]
    Image[] unitImage;

    async UniTask BossWarning()
    {
        while(true)
        {
            if (Round.instance.currentRound % 5 == 0)
            {
                bossWarning.SetActive(true);
                await UniTask.Delay(5000);
                bossWarning.SetActive(false);
                await UniTask.WaitUntil(() => Round.instance.currentRound % 5 == 0);
            }
            await UniTask.WaitUntil(() => Round.instance.currentRound % 5 == 0);
        }
    }

    public void ActiveSynergyPannel() //�ó��� ǥ�� ��ư �������� �ó��� �г� Ȱ��ȭ
    {

        if (!isSynergyPannelOn)
        {
            synergyPannel.SetActive(true);
            isSynergyPannelOn = true;
        }
        else if (isSynergyPannelOn)
        {
            synergyPannel.SetActive(false);
            isSynergyPannelOn = false;
        }
    }

    private void MouseClickDown()
    {
        if (Input.GetMouseButtonDown(1))
        {            
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null&&hit.collider.tag=="Unit")
            {
                UnitName=hit.collider.GetComponent<GetUnitInfo>().unitName;
                UnitAd = hit.collider.GetComponent<GetUnitInfo>().ad;
                UnitAp=hit.collider.GetComponent<GetUnitInfo>().ap;
                UnitAS=hit.collider.GetComponent<GetUnitInfo>().attackSpeed;
                UnitAR=hit.collider.GetComponent<GetUnitInfo>().attackRange;
                UnitType = hit.collider.GetComponent<GetUnitInfo>().unitType;

                UnitName_UI.text = UnitName;
                UnitAd_UI.text = UnitAd.ToString();
                UnitAp_UI.text = UnitAp.ToString();
                UnitAS_UI.text = UnitAS.ToString();
                UnitAR_UI.text = UnitAR.ToString();

                string UnitType1;
                string UnitType2;

                UnitType1 = UnitType[0].ToString().Substring(0, 2);                
                if (UnitType1 == "õ��")
                {
                    Synergy1.sprite = Synergys[0];
                    SynergyText1.text = "õ��";
                }
                else if (UnitType1 == "�ż�")
                {
                    Synergy1.sprite = Synergys[1];
                    SynergyText1.text = "�ż�";
                }
                else if (UnitType1 == "Ȳȥ")
                {
                    Synergy1.sprite = Synergys[2];
                    SynergyText1.text = "Ȳȥ";
                }
                else if (UnitType1 == "�Ͽ�")
                {
                    Synergy1.sprite = Synergys[3];
                    SynergyText1.text = "�Ͽ�";
                }
                else if (UnitType1 == "�ٿ�")
                {
                    Synergy1.sprite = Synergys[4];
                    SynergyText1.text = "�ٿ�";
                }
                else if (UnitType1 == "���")
                {
                    Synergy1.sprite = Synergys[5];
                    SynergyText1.text = "���";
                }

                if(UnitType.Length<2)//�ó����� �ΰ� ���ϸ� �ι�° �ó��� ǥ�� UI ����
                {
                    _Synergy2.SetActive(false);
                    _SynergyText2.SetActive(false);
                }

                if(UnitType.Length==2)
                {
                    _Synergy2.SetActive(true);
                    _SynergyText2.SetActive(true);

                    UnitType2 = UnitType[1].ToString().Substring(0, 2);

                    if (UnitType2 == "õ��")
                    {
                        Synergy2.sprite = Synergys[0];
                        SynergyText2.text = "õ��";
                    }
                    else if (UnitType2 == "�ż�")
                    {
                        Synergy2.sprite = Synergys[1];
                        SynergyText2.text = "�ż�";
                    }
                    else if (UnitType2 == "Ȳȥ")
                    {
                        Synergy2.sprite = Synergys[2];
                        SynergyText2.text = "Ȳȥ";
                    }
                    else if (UnitType2 == "�Ͽ�")
                    {
                        Synergy2.sprite = Synergys[3];
                        SynergyText2.text = "�Ͽ�";
                    }
                    else if (UnitType2 == "�ٿ�")
                    {
                        Synergy2.sprite = Synergys[4];
                        SynergyText2.text = "�ٿ�";
                    }
                    else if (UnitType2 == "���")
                    {
                        Synergy2.sprite = Synergys[5];
                        SynergyText2.text = "���";
                    }
                }
            }
        }
    }


    private void Start()
    {
        BossWarning();
    }

    void Update()
    {
        _roundTime = TimeManager.instance.roundTime; 
        roundTime.text = _roundTime.ToString("F0");
        _currentRound.text = Round.instance.currentRound.ToString("F0")+"����";
        goldText.text = GameManager.instance.gold.ToString();

        MouseClickDown();
    }
}
