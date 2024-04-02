using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // è�Ǿ� ���� �� ���� �÷��� ��Ʈ�ѷ� ����
    public ChampionShop championShop;
    public GamePlayController gamePlayController;

    // è�Ǿ� ������ �� ���ʽ� �г� �迭
    public GameObject[] championsFrameArray;
    public GameObject[] bonusPanels;

    // Ÿ�̸�, è�Ǿ� ��, ���, HP�� ǥ���ϴ� �ؽ�Ʈ
    public Text timerText;
    public Text championCountText;
    public Text goldText;
    public Text hpText;

    // ����, ����ŸƮ ��ư, ��ġ �ؽ�Ʈ, ���, ���ʽ� �����̳�, ���ʽ� UI ������ ����
    public GameObject shop;
    public GameObject placementText;
    public GameObject gold;
    public GameObject bonusContainer;
    public GameObject bonusUIPrefab;

    // ���ΰ�ħ ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    public void Refresh_Click()
    {
        championShop.RefreshShop(false);
    }

    // ����ġ ���� ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    public void BuyXP_Click()
    {
        championShop.BuyLvl();
    }

    // è�Ǿ� �������� ����� �޼���
    public void HideChampionFrame(int index)
    {
        championsFrameArray[index].transform.Find("champion").gameObject.SetActive(false);
    }

    // ���� �������� �����ִ� �޼���
    public void ShowShopItems()
    {
        for (int i = 0; i < championsFrameArray.Length; i++)
        {
            championsFrameArray[i].transform.Find("champion").gameObject.SetActive(true);
        }
    }

    // ���� �������� �ε��ϴ� �޼���
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

    // UI�� ������Ʈ�ϴ� �޼���
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
