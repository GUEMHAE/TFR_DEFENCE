using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Cysharp.Threading.Tasks;
using System;

public class SynergyManager : MonoBehaviour
{
    public struct Synergy //시너지들의 정보를 담기 위한 내부 클래스
    {
        public string name; //시너지 이름
        public Sprite icon; //시너지 아이콘
        public string effect; //시너지 효과 설명
        public int grade; //시너지 등급(갯수)
    }
    public List<string> unitName;


    [SerializeField]
    public Synergy[] synergies = new Synergy[6]; //시너지 구조체 배열

    [SerializeField]
    private Transform[] grid;

    static public SynergyManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Init_Light();
        Init_Dark();
        Init_Water();
        Init_Fire();
        Init_Ground();
        Init_Air();
    }

    private void Start()
    {
        SynergyOnField.instance.allUnits = RemoveDuplicates(SynergyOnField.instance.allUnits);
        checkSynergy().Forget();
    }

    void Update()
    {
        Debug.Log(synergies[1].grade);
    }

    async UniTaskVoid checkSynergy()
    {
        int previousListLength = SynergyOnField.instance.allUnits.Count; // 처음에 이전 리스트의 길이 저장
        while (true)
        {
            await UniTask.WaitUntil(() =>
            {
                // 이전 리스트의 길이와 현재 리스트의 길이를 비교하여 변화를 감지
                int currentListLength = SynergyOnField.instance.allUnits.Count;
                if (currentListLength != previousListLength)
                {
                    // 리스트의 길이가 증가했을 때
                    if (currentListLength > previousListLength)
                    {
                        Debug.Log("List length increased!");
                        IncreaseSynergy();
                    }
                    // 리스트의 길이가 감소했을 때
                    else
                    {
                        Debug.Log("List length decreased!");
                    }

                    previousListLength = currentListLength; // 변경된 리스트의 길이로 업데이트
                    return true; // 변경되었으면 대기 해제
                }
                return false; // 변경되지 않았으면 계속 대기
            });
        }
    }

    void Init_Light()
    {
        synergies[0].name = "신성";
        synergies[0].effect = "1 시너지 : 초 당 마나 회복량 1증가\n2 시너지 : 초 당 마나 회복량 2증가\n3 시너지 : 초 당 마나 회복량 3.5증가\n4 시너지 : 초 당 마나 회복량 5증가\n5 시너지 : 초 당 마나 회복량 8증가";
        synergies[0].grade = 0;
        synergies[0].icon = Resources.Load<Sprite>("Symbol/Light"); //리소스 이름을 ""사이에 넣으면 아이콘 정보 저장
    }

    void Init_Dark()
    {
        synergies[1].name = "암영";
        synergies[1].effect = "1 시너지 : 추가 고정 피해 5%\n2 시너지 : 추가 고정 피해 15%\n3 시너지 : 추가 고정 피해 30%\n4 시너지 : 추가 고정 피해 50%";
        synergies[1].grade = 0;
        synergies[1].icon = Resources.Load<Sprite>("Symbol/Dark"); //리소스 이름을 ""사이에 넣으면 아이콘 정보 저장
    }

    void Init_Water()
    {
        synergies[2].name = "기원";
        synergies[2].effect = "1 시너지 : 주문력 20증가 5%\n2 시너지 : 주문력 50증가\n3 시너지 : 주문력 100증가\n4 시너지 : 주문력 200증가";
        synergies[2].grade = 0;
        synergies[2].icon = Resources.Load<Sprite>("Symbol/Water"); //리소스 이름을 ""사이에 넣으면 아이콘 정보 저장
    }

    void Init_Fire()
    {
        synergies[3].name = "황혼";
        synergies[3].effect = "1 시너지 : 공격력 20증가 5%\n2 시너지 : 공격력 50증가\n3 시너지 : 공격력 100증가\n4 시너지 : 공격력 200증가";
        synergies[3].grade = 0;
        synergies[3].icon = Resources.Load<Sprite>("Symbol/Fire"); //리소스 이름을 ""사이에 넣으면 아이콘 정보 저장
    }

    void Init_Ground()
    {
        synergies[4].name = "근원";
        synergies[4].effect = "1 시너지 : 공격 적중 시 적의 방어력과 마법저항력 3감소 5%\n2 시너지 : 공격 적중 시 적의 방어력과 마법저항력 8감소\n3 시너지 : 공격 적중 시 적의 방어력과 마법저항력 16감소\n4 시너지 : 공격 적중 시 적의 방어력과 마법저항력 30감소";
        synergies[4].grade = 0;
        synergies[4].icon = Resources.Load<Sprite>("Symbol/Ground"); //리소스 이름을 ""사이에 넣으면 아이콘 정보 저장
    }

    void Init_Air()
    {
        synergies[5].name = "천공";
        synergies[5].effect = "1 시너지 : 공격 속도 30%증가\n\n 전장에 바람 속성 영웅이 2개체 존재할 시 시너지 효과가 사라집니다.";
        synergies[5].grade = 0;
        synergies[5].icon = Resources.Load<Sprite>("Symbol/Air"); //리소스 이름을 ""사이에 넣으면 아이콘 정보 저장
    }

    public List<GameObject> RemoveDuplicates(List<GameObject> originalList)
    {
        List<GameObject> uniqueList = new List<GameObject>();

        foreach (GameObject obj in originalList)
        {
            // 새 리스트에 같은 이름의 요소가 없으면 추가
            if (!uniqueList.Any(item => item.name.Substring(3) == obj.name.Substring(3)))
            {
                uniqueList.Add(obj);
                //IncreaseSynergy();
            }
        }

        return uniqueList;
    }

    public Dictionary<string, int> GetSynergyCounts(Synergy[] synergies, List<GameObject> unitsOnField)
{
        Dictionary<string, int> synergyCountMap = new Dictionary<string, int>();

        // 각 시너지의 초기 갯수를 0으로 설정
        foreach (Synergy synergy in synergies)
        {
            synergyCountMap[synergy.name] = 0;
        }

        // 각 유닛을 순회하면서 시너지 갯수를 증가
        foreach (GameObject unit in unitsOnField)
        {
            string unitName = unit.name;

            // 시너지 목록을 순회하면서 해당 유닛이 어떤 시너지에 속하는지 확인
            foreach (Synergy synergy in synergies)
            {
                if (unitName.Contains(synergy.name)) // 유닛 이름에 시너지 이름이 포함되어 있는지 확인
                {
                    synergyCountMap[synergy.name]++;
                }
            }
        }

        return synergyCountMap;
    }


    public void IncreaseSynergy()
    {
        foreach (var unit in SynergyOnField.instance.allUnits)
        {
            
            Debug.Log(unit.name.Substring(3));
            switch (unit.name.Substring(3))
            {
                case "다르밤":
                    synergies[1].grade++;
                    break;
                case "바바리안":
                    synergies[4].grade++;
                    break;
                case "부르":
                    synergies[3].grade++;
                    break;
                case "스넬":
                    synergies[0].grade++;
                    synergies[2].grade++;
                    break;
                case "아록스":
                    synergies[3].grade++;
                    synergies[5].grade++;
                    break;
                case "애쉬":
                    synergies[2].grade++;
                    break;
                case "토니르":
                    synergies[0].grade++;
                    break;
                case "아르테":
                    synergies[4].grade++;
                    break;
                case "아서스":
                    synergies[1].grade++;
                    break;
                case "이르시그":
                    synergies[0].grade++;
                    synergies[1].grade++;
                    break;
                case "피오나":
                    synergies[2].grade++;
                    break;
                case "를로르":
                    synergies[0].grade++;
                    synergies[3].grade++;
                    break;
                case "일렉토":
                    synergies[0].grade++;
                    synergies[4].grade++;
                    break;
                case "카뮵":
                    synergies[1].grade++;
                    synergies[2].grade++;
                    break;
                case "링크":
                    synergies[4].grade++;
                    synergies[5].grade++;
                    break;
            }
        }
    }

}
