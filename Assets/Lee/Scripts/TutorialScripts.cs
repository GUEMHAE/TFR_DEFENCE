using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TutorialScripts : MonoBehaviour, IEndDragHandler
{
    public GameObject IMG; // 이전 이미지
    public GameObject IMG1; // 이전 이미지
    public GameObject ep_IMG; // 이전 이미지
    public GameObject ep_IMGGrid; // 이전 이미지
    public GameObject IMG2; // 이전 이미지
    public GameObject IMG2_1; // 이전 이미지
    public GameObject IMG2_2; // 이전 이미지
 // 이전 이미지

    public string GridName; //배치석 이름
    public GameObject IMG_Grid; // 이미지
    private bool isGrid = false; // 배치석에 장착 되었는지 확인

    public string waitsName; // 대기석 이름
    public GameObject IMG_waits; //다음 이미지
    private bool iswaits = false; // 대기석에 정착 되었는지 확인

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isGrid && !IMG_Grid.activeSelf) // 정착 상태이고 이미지가 비활성화된 경우
        {
            IMG_Grid.SetActive(true); // 이미지를 활성화
            IMG_waits.SetActive(false);
            IMG1.SetActive(false);
            ep_IMG.SetActive(false);
            ep_IMGGrid.SetActive(true);
        }
        else
        {
            IMG_Grid.SetActive(false);
        }


        if (iswaits && !IMG_waits.activeSelf) // 정착 상태이고 이미지가 비활성화된 경우
        {
            IMG_waits.SetActive(true); // 이미지를 활성화
            ep_IMGGrid.SetActive(false);
            IMG2.SetActive(false);
            IMG2_1.SetActive(false);
            IMG2_2.SetActive(false);
            IMG.SetActive(true);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == GridName) // 충돌한 게임 오브젝트의 이름이 배치석 이름과 같은 경우
        {
            isGrid = true; // 정착 상태를 true로 설정
        }

        if (collision.gameObject.name == waitsName) // 충돌한 게임 오브젝트의 이름이 대기석 이름과 같은 경우
        {
            iswaits = true; // 정착 상태를 true로 설정
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == GridName) // 배치석과 충돌이 끝난 경우
        {
            isGrid = false; // 정착 상태를 false로 설정
        }

        if (collision.gameObject.name == waitsName) // 대기석과 충돌이 끝난 경우
        {
            iswaits = false; // 정착 상태를 false로 설정
        }
    }
}
