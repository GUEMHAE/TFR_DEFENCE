using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SynergyUI : MonoBehaviour
{
    public TMP_Text[] synergyName; //텍스트에 표시되는 시너지 이름
    public TMP_Text[] synergyGrade; //텍스트에 표시되는 시너지 수
    public Image[] synergyIcon; //이미지에 표시되는 시너지 아이콘

    public SynergyManager synergyManager; //시너지 매니저 스크립트를 참조

    public void DisplaySynergy()
    {
        synergyName[0].text = synergyManager.synergie1.name;
        synergyGrade[0].text = synergyManager.synergie1.grade.ToString();
        synergyIcon[0].sprite = synergyManager.synergie1.icon;

        synergyName[1].text = synergyManager.synergie2.name;
        synergyGrade[1].text = synergyManager.synergie2.grade.ToString();
        synergyIcon[1].sprite = synergyManager.synergie2.icon;

        synergyName[2].text = synergyManager.synergie3.name;
        synergyGrade[2].text = synergyManager.synergie3.grade.ToString();
        synergyIcon[2].sprite = synergyManager.synergie3.icon;

        synergyName[3].text = synergyManager.synergie4.name;
        synergyGrade[3].text = synergyManager.synergie4.grade.ToString();
        synergyIcon[3].sprite = synergyManager.synergie4.icon;

        synergyName[4].text = synergyManager.synergie5.name;
        synergyGrade[4].text = synergyManager.synergie5.grade.ToString();
        synergyIcon[4].sprite = synergyManager.synergie5.icon;

        synergyName[5].text = synergyManager.synergie6.name;
        synergyGrade[5].text = synergyManager.synergie6.grade.ToString();
        synergyIcon[5].sprite = synergyManager.synergie6.icon;
    }
    
    void Start()
    {
        DisplaySynergy();
    }

    void Update()
    {
        //if()
    }
}
