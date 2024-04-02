using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStage { Preparation, Combat, Loss };

public class GamePlayController : MonoBehaviour
{
    //public InputController inputController;
    //public GameData gameData;
    public UIController uIController;
    public ChampionShop championShop;

    [HideInInspector]
    public GameObject[] ownChampionInventoryArray;
    [HideInInspector]
    public GameObject[] oponentChampionInventoryArray;
    [HideInInspector]
    public GameObject[,] gridChampionsArray;

    public GameStage currentGameStage;
    private float timer = 0;

    public int PreparationStageDuration = 16;
    public int baseGoldIncome = 5;

    [HideInInspector]
    public int currentChampionLimit = 3;
    [HideInInspector]
    public int currentChampionCount = 0;
    [HideInInspector]
    public int currentGold = 5;
    [HideInInspector]
    public int currentHP = 100;
    [HideInInspector]
    public int timerDisplay = 0;
    [HideInInspector]
    public int currentExp = 1;

    public Dictionary<ChampionType, int> championTypeCount;
    public List<SynergyManager> activeBonusList;

    private int playerLevel = 1; // 초기 플레이어 레벨

    void Start()
    {
        currentGameStage = GameStage.Preparation;

        //ownChampionInventoryArray = new GameObject[Map.inventorySize];
        //oponentChampionInventoryArray = new GameObject[Map.inventorySize];
        //gridChampionsArray = new GameObject[Map.hexMapSizeX, Map.hexMapSizeZ / 2];


        uIController.UpdateUI();
    }

    void Update()
    {
        //if (currentGameStage == GameStage.Preparation)
        //{
        //    timer += Time.deltaTime;

        //    timerDisplay = (int)(PreparationStageDuration - timer);

        //    uIController.UpdateTimerText();

        //    if (timer > PreparationStageDuration)
        //    {
        //        timer = 0;

        //        OnGameStageComplate();
        //    }
        //}
        //else if (currentGameStage == GameStage.Combat)
        //{
        //    timer += Time.deltaTime;

        //    timerDisplay = (int)timer;

        //    if (timer > CombatStageDuration)
        //    {
        //        timer = 0;

        //        OnGameStageComplate();
        //    }
        //}
    }


    public bool BuyChampionFromShop(Champion champion)
    {
        int emptyIndex = -1;
        for (int i = 0; i < ownChampionInventoryArray.Length; i++)
        {
            if (ownChampionInventoryArray[i] == null)
            {
                emptyIndex = i;
                break;
            }
        }

        if (emptyIndex == -1)
            return false;

        if (currentGold < champion.cost)
            return false;

        GameObject championPrefab = Instantiate(champion.prefab);

        //ChampionController championController = championPrefab.GetComponent<ChampionController>();

        //championController.Init(champion, ChampionController.TEAMID_PLAYER);

        //championController.SetGridPosition(Map.GRIDTYPE_OWN_INVENTORY, emptyIndex, -1);

        //championController.SetWorldPosition();
        //championController.SetWorldRotation();

        //StoreChampionInArray(Map.GRIDTYPE_OWN_INVENTORY, map.ownTriggerArray[emptyIndex].gridX, -1, championPrefab);


        //if (currentGameStage == GameStage.Preparation)
        //    TryUpgradeChampion(champion);


        currentGold -= champion.cost;

        uIController.UpdateUI();

        return true;
    }

    private int CalculateIncome()
    {
        int income = 0;

        int bank = (int)(currentGold / 10);


        income += baseGoldIncome;
        income += bank;

        return income;
    }
    public void Buylvl()
    {
        if (currentGold < 4)
            return;

        if (currentChampionLimit < 9)
        {
            currentChampionLimit++;

            currentGold -= 4;

            uIController.UpdateUI();

        }

    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        uIController.UpdateUI();

    }

    public void EndRound()
    {

    }

    // 플레이어 레벨을 증가시키는 메서드
    public void IncreasePlayerLevel()
    {
        currentExp += 4;
        if (currentExp == 2)
        {
            playerLevel = 2;
            currentExp = 0;
        }
        else if (currentExp == 6)
        {
            playerLevel = 3;
            currentExp = 0;
        }
        else if (currentExp == 12)
        {
            playerLevel = 4;
            currentExp = 0;
        }
        else if (currentExp == 18)
        {
            playerLevel = 5;
            currentExp = 0;
        }
        else if (currentExp == 28)
        {
            playerLevel = 6;
            currentExp = 0;
        }
        Debug.Log("Player level increased to: " + playerLevel);
    }

    public int GetPlayerLevel()
    {
        return playerLevel;
    }

}
