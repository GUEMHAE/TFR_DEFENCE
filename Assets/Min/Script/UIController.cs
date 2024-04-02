using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // 챔피언 상점 및 게임 플레이 컨트롤러 참조
    public ChampionShop championShop;
    public GamePlayController gamePlayController;

    // 챔피언 프레임 및 보너스 패널 배열
    public GameObject[] championsFrameArray;
    public GameObject[] bonusPanels;

    // 타이머, 챔피언 수, 골드, HP를 표시하는 텍스트
    public Text timerText;
    public Text championCountText;
    public Text goldText;
    public Text hpText;

    // 상점, 리스타트 버튼, 배치 텍스트, 골드, 보너스 컨테이너, 보너스 UI 프리팹 참조
    public GameObject shop;
    public GameObject placementText;
    public GameObject gold;
    public GameObject bonusContainer;
    public GameObject bonusUIPrefab;

    // 새로고침 버튼 클릭 시 호출되는 메서드
    public void Refresh_Click()
    {
        championShop.RefreshShop(false);
    }

    // 경험치 구매 버튼 클릭 시 호출되는 메서드
    public void BuyXP_Click()
    {
        championShop.BuyLvl();
    }

    // 챔피언 프레임을 숨기는 메서드
    public void HideChampionFrame(int index)
    {
        championsFrameArray[index].transform.Find("champion").gameObject.SetActive(false);
    }

    // 상점 아이템을 보여주는 메서드
    public void ShowShopItems()
    {
        for (int i = 0; i < championsFrameArray.Length; i++)
        {
            championsFrameArray[i].transform.Find("champion").gameObject.SetActive(true);
        }
    }

    // 상점 아이템을 로드하는 메서드
    public void LoadShopItem(Champion champion, int index)
    {
        Transform championUI = championsFrameArray[index].transform.Find("champion");
        Transform top = championUI.Find("top");
        Transform bottom = championUI.Find("bottom");
        Transform type1 = top.Find("type 1");
        Transform type2 = top.Find("type 2");
        Transform name = bottom.Find("Name");
        Transform cost = bottom.Find("Cost");
        Transform icon1 = top.Find("icon 1");
        Transform icon2 = top.Find("icon 2");

        name.GetComponent<Text>().text = champion.uiname;
        cost.GetComponent<Text>().text = champion.cost.ToString();
        type1.GetComponent<Text>().text = champion.type1.displayName;
        type2.GetComponent<Text>().text = champion.type2.displayName;
        icon1.GetComponent<Image>().sprite = champion.type1.icon;
        icon2.GetComponent<Image>().sprite = champion.type2.icon;
    }

    // UI를 업데이트하는 메서드
    public void UpdateUI()
    {
        goldText.text = gamePlayController.currentGold.ToString();
        championCountText.text = gamePlayController.currentChampionCount.ToString() + " / " + gamePlayController.currentChampionLimit.ToString();
        hpText.text = "HP " + gamePlayController.currentHP.ToString();

        foreach (GameObject go in bonusPanels)
        {
            go.SetActive(false);
        }

        if (gamePlayController.championTypeCount != null)
        {
            int i = 0;
            foreach (KeyValuePair<ChampionType, int> m in gamePlayController.championTypeCount)
            {
                GameObject bonusUI = bonusPanels[i];
                bonusUI.transform.SetParent(bonusContainer.transform);
                bonusUI.transform.Find("icon").GetComponent<Image>().sprite = m.Key.icon;
                bonusUI.transform.Find("name").GetComponent<Text>().text = m.Key.displayName;
                //bonusUI.transform.Find("count").GetComponent<Text>().text = m.Value.ToString() + " / " + m.Key.championBonus.championCount.ToString();
                bonusUI.SetActive(true);
                i++;
            }
        }
    }
}
