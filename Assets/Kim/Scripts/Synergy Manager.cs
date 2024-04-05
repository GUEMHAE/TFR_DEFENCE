using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SynergyManager : MonoBehaviour
{
    public struct Synergy //시너지들의 정보를 담기 위한 내부 클래스
    {
        public string name; //시너지 이름
        public Sprite icon; //시너지 아이콘
        public string effect; //시너지 효과 설명
        [SerializeField]
        public int grade; //시너지 등급(갯수)
    }

    [SerializeField]
    public Synergy[] synergies = new Synergy[6]; //시너지 구조체 배열

    private void Awake()
    {
        Init_Light();
        Init_Dark();
        Init_Water();
        Init_Fire();
        Init_Ground();
        Init_Air();
    }

    private void Start()
    {

    }

    void Update()
    {

    }

    void Init_Light()
    {
        synergies[0].name = "신성";
        synergies[0].effect = "1 시너지 : 초 당 마나 회복량 1증가\n2 시너지 : 초 당 마나 회복량 2증가\n3 시너지 : 초 당 마나 회복량 3.5증가\n4 시너지 : 초 당 마나 회복량 5증가\n5 시너지 : 초 당 마나 회복량 8증가";
        synergies[0].grade = 0;
        synergies[0].icon = Resources.Load<Sprite>("Synergy/Light"); //리소스 이름을 ""사이에 넣으면 아이콘 정보 저장
    }

    void Init_Dark()
    {
        synergies[1].name = "암영";
        synergies[1].effect = "1 시너지 : 추가 고정 피해 5%\n2 시너지 : 추가 고정 피해 15%\n3 시너지 : 추가 고정 피해 30%\n4 시너지 : 추가 고정 피해 50%";
        synergies[1].grade = 5;
        synergies[1].icon = Resources.Load<Sprite>("Synergy/Dark"); //리소스 이름을 ""사이에 넣으면 아이콘 정보 저장
    }

    void Init_Water()
    {
        synergies[2].name = "기원";
        synergies[2].effect = "1 시너지 : 주문력 20증가 5%\n2 시너지 : 주문력 50증가\n3 시너지 : 주문력 100증가\n4 시너지 : 주문력 200증가";
        synergies[2].grade = 3;
        synergies[2].icon = Resources.Load<Sprite>("Synergy/Water"); //리소스 이름을 ""사이에 넣으면 아이콘 정보 저장
    }

    void Init_Fire()
    {
        synergies[3].name = "황혼";
        synergies[3].effect = "1 시너지 : 공격력 20증가 5%\n2 시너지 : 공격력 50증가\n3 시너지 : 공격력 100증가\n4 시너지 : 공격력 200증가";
        synergies[3].grade = 4;
        synergies[3].icon = Resources.Load<Sprite>("Synergy/Fire"); //리소스 이름을 ""사이에 넣으면 아이콘 정보 저장
    }

    void Init_Ground()
    {
        synergies[4].name = "근원";
        synergies[4].effect = "1 시너지 : 공격 적중 시 적의 방어력과 마법저항력 3감소 5%\n2 시너지 : 공격 적중 시 적의 방어력과 마법저항력 8감소\n3 시너지 : 공격 적중 시 적의 방어력과 마법저항력 16감소\n4 시너지 : 공격 적중 시 적의 방어력과 마법저항력 30감소";
        synergies[4].grade = 0;
        synergies[4].icon = Resources.Load<Sprite>("Synergy/Ground"); //리소스 이름을 ""사이에 넣으면 아이콘 정보 저장
    }

    void Init_Air()
    {
        synergies[5].name = "천공";
        synergies[5].effect = "1 시너지 : 공격 속도 30%증가\n\n 전장에 바람 속성 영웅이 2개체 존재할 시 시너지 효과가 사라집니다.";
        synergies[5].grade = 0;
        synergies[5].icon = Resources.Load<Sprite>("Synergy/Air"); //리소스 이름을 ""사이에 넣으면 아이콘 정보 저장
    }
}
