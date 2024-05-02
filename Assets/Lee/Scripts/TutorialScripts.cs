using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TutorialScripts : MonoBehaviour, IEndDragHandler
{
    //   public GameObject IMG; // 이전 이미지
    //   public GameObject IMG1; // 이전 이미지
    //   public GameObject ep_IMG; // 이전 이미지
    //   public GameObject ep_IMGGrid; // 이전 이미지
    //   public GameObject IMG2; // 이전 이미지
    //   public GameObject IMG2_1; // 이전 이미지
    //   public GameObject IMG2_2; // 이전 이미지
    //// 이전 이미지

    private T_IMG waitsAnimation; // T_IMG 스크립트 참조

    public string GridName; //배치석 이름
    public GameObject IMG_Grid; // 이미지
    private bool isGrid = false; // 배치석에 장착 되었는지 확인

    public string waitsName; // 대기석 이름
    public GameObject IMG_waits; //다음 이미지
    private bool iswaits = false; // 대기석에 정착 되었는지 확인

    void Start()
    {
        IMG_waits.SetActive(false);
        waitsAnimation = IMG_waits.GetComponent<T_IMG>(); // T_IMG 스크립트 참조 가져오기
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isGrid && !IMG_Grid.activeSelf) // 정착 상태이고 이미지가 비활성화된 경우
        {
            IMG_Grid.SetActive(true); // 이미지를 활성화
        }
        else
        {
            IMG_Grid.SetActive(false); // 배치석 이미지를 비활성화합니다.
            Debug.Log("1");
        }

        if(isGrid==true)
        {
            IMG_waits.SetActive(true);

            // IMG_waits 이미지의 애니메이션 시작
            if (waitsAnimation != null)
            {
                waitsAnimation.StartAnimation();
                Debug.Log("2");
            }
        }
        else
        {
            IMG_waits.SetActive(false);
        }

        //// IMG_Grid가 비활성화된 경우 대기석 이미지를 활성화합니다.
        //if (!IMG_Grid.activeSelf)
        //{
        //    IMG_waits.SetActive(true); // 대기석 이미지를 활성화합니다.
        //    Debug.Log("ddd"); // 디버그 로그 출력
        //}


        //if (iswaits && !IMG_waits.activeSelf) // 정착 상태이고 이미지가 비활성화된 경우
        //{
        //    IMG_waits.SetActive(true); // 이미지를 활성화
        //    //ep_IMGGrid.SetActive(false);
        //    //IMG2.SetActive(false);
        //    //IMG2_1.SetActive(false);
        //    //IMG2_2.SetActive(false);
        //    //IMG.SetActive(true);

        //}
        //else
        //{
        //    IMG_waits.SetActive(false);
        //}
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
