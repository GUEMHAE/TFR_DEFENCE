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
    public GameObject[] synergyPrefab; //시너지 프리팹
    public GridLayoutGroup synergyParent; //시너지의 부모 오브젝트

    public int[] synergyGradeCheck; //테스트용 코드

    public SynergyManager synergyManager; //시너지 매니저 스크립트를 참조

    public void DisplaySynergy()
    {
        if (synergyManager.synergies[0].grade > 0) //시너지의 갯수가 0개 이상일 경우만 시너지 UI에표시
        {
            synergyPrefab[0].SetActive(true);

            synergyName[0].text = synergyManager.synergies[0].name;
            synergyGrade[0].text = synergyManager.synergies[0].grade.ToString();
            synergyIcon[0].sprite = synergyManager.synergies[0].icon;
        }
        else
            synergyPrefab[0].SetActive(false);

        if (synergyManager.synergies[1].grade > 0)
        {
            synergyPrefab[1].SetActive(true);
            synergyName[1].text = synergyManager.synergies[1].name;
            synergyGrade[1].text = synergyManager.synergies[1].grade.ToString();
            synergyIcon[1].sprite = synergyManager.synergies[1].icon;
        }
        else
            synergyPrefab[1].SetActive(false);

        if (synergyManager.synergies[2].grade > 0)
        {
            synergyPrefab[2].SetActive(true);
            synergyName[2].text = synergyManager.synergies[2].name;
            synergyGrade[2].text = synergyManager.synergies[2].grade.ToString();
            synergyIcon[2].sprite = synergyManager.synergies[2].icon;
        }
        else
            synergyPrefab[2].SetActive(false);

        if (synergyManager.synergies[3].grade > 0)
        {
            synergyPrefab[3].SetActive(true);
            synergyName[3].text = synergyManager.synergies[3].name;
            synergyGrade[3].text = synergyManager.synergies[3].grade.ToString();
            synergyIcon[3].sprite = synergyManager.synergies[3].icon;
        }
        else
            synergyPrefab[3].SetActive(false);

        if (synergyManager.synergies[4].grade > 0)
        {
            synergyPrefab[4].SetActive(true);
            synergyName[4].text = synergyManager.synergies[4].name;
            synergyGrade[4].text = synergyManager.synergies[4].grade.ToString();
            synergyIcon[4].sprite = synergyManager.synergies[4].icon;
        }
        else
            synergyPrefab[4].SetActive(false);

        if (synergyManager.synergies[5].grade > 0)
        {
            synergyPrefab[5].SetActive(true);
            synergyName[5].text = synergyManager.synergies[5].name;
            synergyGrade[5].text = synergyManager.synergies[5].grade.ToString();
            synergyIcon[5].sprite = synergyManager.synergies[5].icon;
        }
        else
            synergyPrefab[5].SetActive(false);
    }

    private void Start()
    {
        synergyGradeCheck= new int[6];
        synergyGradeCheck[0] = synergyManager.synergies[0].grade; //시너지 갯수 제대로 들어가는지 체크하는 코드
        DisplaySynergy();
    }

    private void Update()
    {
        synergyManager.synergies[0].grade = synergyGradeCheck[0];

        System.Array.Sort(synergyManager.synergies, (x, y) => y.grade.CompareTo(x.grade));//시너지의 갯수가 높은 순으로 정렬
        DisplaySynergy();
    }
}
