using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynergyManager : MonoBehaviour
{
    [SerializeField]
    public struct Synergy //시너지들의 정보를 담기 위한 내부 클래스
    {
        public string name; //시너지 이름
        public Sprite icon;  //시너지 아이콘
        public string effect; //시너지 효과 설명
        public int grade; //시너지 등급(갯수)
    }
    
    public Synergy synergie1; //시너지 구조체
    public Synergy synergie2; 
    public Synergy synergie3; 
    public Synergy synergie4; 
    public Synergy synergie5; 
    public Synergy synergie6;

    private void Awake()
    {
        synergie1 = new Synergy(); //신성 시너지
        synergie2 = new Synergy(); //암영 시너지
        synergie3 = new Synergy(); //기원 시너지
        synergie4 = new Synergy(); //황혼 시너지
        synergie5 = new Synergy(); //근원 시너지
        synergie6 = new Synergy(); //천공 시너지

        Init_Light();
        Init_Dark();
        Init_Water();
        Init_Fire();
        Init_Ground();
        Init_Air();
    }

    void Update()
    {
        
    }

    void Init_Light()
    {
        synergie1.name = "신성";
        synergie1.icon = Resources.Load<Sprite>("상징/신성"); //리소스 이름를 ""사이에 넣으면 아이콘 정보 저장 
        synergie1.effect = "1 시너지 : 초 당 마나 회복량 1증가\n2 시너지 : 초 당 마나 회복량 2증가\n3 시너지 : 초 당 마나 회복량 3.5증가\n4 시너지 : 초 당 마나 회복량 5증가\n5 시너지 : 초 당 마나 회복량 8증가";
        synergie1.grade = 0;
    }

    void Init_Dark()
    {
        synergie2.name = "암영";
        synergie2.icon = Resources.Load<Sprite>("상징/암영"); //리소스 이름를 ""사이에 넣으면 아이콘 정보 저장 
        synergie2.effect = "1 시너지 : 추가 고정 피해 5%\n2 시너지 : 추가 고정 피해 15%\n3 시너지 : 추가 고정 피해 30%\n4 시너지 : 추가 고정 피해 50%";
        synergie2.grade = 0;
    }

    void Init_Water()
    {
        synergie3.name = "기원";
        synergie3.icon = Resources.Load<Sprite>("상징/기원"); //리소스 이름를 ""사이에 넣으면 아이콘 정보 저장 
        synergie3.effect = "1 시너지 : 주문력 20증가 5%\n2 시너지 : 주문력 50증가\n3 시너지 : 주문력 100증가\n4 시너지 : 주문력 200증가";
        synergie3.grade = 0;
    }

    void Init_Fire()
    {
        synergie4.name = "황혼";
        synergie4.icon = Resources.Load<Sprite>("상징/황혼"); //리소스 이름를 ""사이에 넣으면 아이콘 정보 저장 
        synergie4.effect = "1 시너지 : 공격력 20증가 5%\n2 시너지 : 공격력 50증가\n3 시너지 : 공격력 100증가\n4 시너지 : 공격력 200증가";
        synergie4.grade = 0;
    }

    void Init_Ground()
    {
        synergie5.name = "근원";
        synergie5.icon = Resources.Load<Sprite>("상징/근원"); //리소스 이름를 ""사이에 넣으면 아이콘 정보 저장 
        synergie5.effect = "1 시너지 : 공격 적중 시 적의 방어력과 마법저항력 3감소 5%\n2 시너지 : 공격 적중 시 적의 방어력과 마법저항력 8감소\n3 시너지 : 공격 적중 시 적의 방어력과 마법저항력 16감소\n4 시너지 : 공격 적중 시 적의 방어력과 마법저항력 30감소";
        synergie5.grade = 0;
    }

    void Init_Air()
    {
        synergie6.name = "천공";
        synergie6.icon = Resources.Load<Sprite>("상징/천공"); //리소스 이름를 ""사이에 넣으면 아이콘 정보 저장 
        synergie6.effect = "1 시너지 : 공격 속도 30%증가\n\n 전장에 바람 속성 영웅이 2개체 존재할 시 시너지 효과가 사라집니다.";
        synergie6.grade = 0;
    }
}
