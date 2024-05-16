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
    TMP_Text roundTime; //현재 라운드 시간 표시해주는 UI
    [SerializeField]
    TMP_Text _currentRound; //현재 라운드 표시 해주는 UI

    float _roundTime; //현재 라운드 시간 받아오는 변수

    [SerializeField]
    GameObject bossWarning;

    [SerializeField]
    Button synergyButton; //시너지 표시 버튼
    [SerializeField]
    GameObject synergyPannel; //시너지 표시 패널

    [SerializeField]
    TMP_Text goldText;

    public bool isSynergyPannelOn;

    string UnitName;
    float UnitAd;//공격력
    float UnitAp;//스킬공격력
    float UnitAS;//공격속도
    float UnitAR;//공격사거리

    [Header("-유닛 정보 UI")]
    [SerializeField]
    TMP_Text UnitName_UI;
    [SerializeField]
    TMP_Text UnitAd_UI;//공격력 표시
    [SerializeField]
    TMP_Text UnitAp_UI;//스킬공격력 표시
    [SerializeField]
    TMP_Text UnitAS_UI;//공격속도 표시
    [SerializeField]
    TMP_Text UnitAR_UI;//공격사거리 표시

    [SerializeField]
    Image Synergy1; //시너지 표시 UI 첫 번째
    [SerializeField]
    Image Synergy2; //시너지 표시 UI 두 번쨰
    [SerializeField]
    GameObject _Synergy2; //시너지 표시 UI두번째를 끄고 켜기 위해
    [SerializeField]
    Sprite[] Synergys; //시너지 UI배열
    [SerializeField]
    UnitType[] UnitType;
    [SerializeField]
    TMP_Text SynergyText1;
    [SerializeField]
    TMP_Text SynergyText2;
    [SerializeField]
    GameObject _SynergyText2;//시너지 이름 표시 UI두번째를 끄고 켜기 위해
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

    public void ActiveSynergyPannel() //시너지 표시 버튼 눌럿을때 시너지 패널 활성화
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
                if (UnitType1 == "천공")
                {
                    Synergy1.sprite = Synergys[0];
                    SynergyText1.text = "천공";
                }
                else if (UnitType1 == "신성")
                {
                    Synergy1.sprite = Synergys[1];
                    SynergyText1.text = "신성";
                }
                else if (UnitType1 == "황혼")
                {
                    Synergy1.sprite = Synergys[2];
                    SynergyText1.text = "황혼";
                }
                else if (UnitType1 == "암영")
                {
                    Synergy1.sprite = Synergys[3];
                    SynergyText1.text = "암영";
                }
                else if (UnitType1 == "근원")
                {
                    Synergy1.sprite = Synergys[4];
                    SynergyText1.text = "근원";
                }
                else if (UnitType1 == "기원")
                {
                    Synergy1.sprite = Synergys[5];
                    SynergyText1.text = "기원";
                }

                if(UnitType.Length<2)//시너지가 두개 이하면 두번째 시너지 표시 UI 끄기
                {
                    _Synergy2.SetActive(false);
                    _SynergyText2.SetActive(false);
                }

                if(UnitType.Length==2)
                {
                    _Synergy2.SetActive(true);
                    _SynergyText2.SetActive(true);

                    UnitType2 = UnitType[1].ToString().Substring(0, 2);

                    if (UnitType2 == "천공")
                    {
                        Synergy2.sprite = Synergys[0];
                        SynergyText2.text = "천공";
                    }
                    else if (UnitType2 == "신성")
                    {
                        Synergy2.sprite = Synergys[1];
                        SynergyText2.text = "신성";
                    }
                    else if (UnitType2 == "황혼")
                    {
                        Synergy2.sprite = Synergys[2];
                        SynergyText2.text = "황혼";
                    }
                    else if (UnitType2 == "암영")
                    {
                        Synergy2.sprite = Synergys[3];
                        SynergyText2.text = "암영";
                    }
                    else if (UnitType2 == "근원")
                    {
                        Synergy2.sprite = Synergys[4];
                        SynergyText2.text = "근원";
                    }
                    else if (UnitType2 == "기원")
                    {
                        Synergy2.sprite = Synergys[5];
                        SynergyText2.text = "기원";
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
        _currentRound.text = Round.instance.currentRound.ToString("F0")+"라운드";
        goldText.text = GameManager.instance.gold.ToString();

        MouseClickDown();
    }
}
