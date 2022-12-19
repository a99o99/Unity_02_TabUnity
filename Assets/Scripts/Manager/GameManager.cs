using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
        #region Singletone
    private static GameManager instance = null;

    public static GameManager GetInstance()
    {
        if (instance == null) 
        {
            GameObject go = new GameObject("@GameManager");
            instance = go.AddComponent<GameManager>();

            DontDestroyOnLoad(go); 
        }

        return instance;
    }
    #endregion

    //public string playerName = "MUMU";

    //public int level = 1;

    //public int gold = 500;

    //public int totalHP = 100;
    //public int curHP = 100;

    //public int characterIdx = 0; 

    ////캐릭터1
    //public int princeHp = 100;
    //public string princeImg = "Character";
    ////캐릭터2
    //public int nikeHp = 120;
    //public string nikeImg = "Character2";

    public PlayerData[] playerDatas = new PlayerData[]
    {
        new PlayerData("Character", 1, 500, 100, 100, 0),
        new PlayerData("Character2", 1, 500, 120, 120, 1),
    };

    public PlayerData GetPlayer(int characterIdx)
    {
        playerData = playerDatas[characterIdx];
        return playerDatas[characterIdx];
    }

    public PlayerData playerData;

    //public void LoadData()
    //{
    //    playerName = PlayerPrefs.GetString("playerName", "MUMU");
    //    level = PlayerPrefs.GetInt("level", 1);
    //    gold = PlayerPrefs.GetInt("gold", 500);
    //    totalHP = PlayerPrefs.GetInt("totlaHP", 100) ;
    //    curHP = PlayerPrefs.GetInt("curHP", 100);
    //}

    //public void SaveData()
    //{
    //    PlayerPrefs.SetString("playerName", playerName);
    //    PlayerPrefs.SetInt("level", level);
    //    PlayerPrefs.SetInt("gold", gold);
    //    PlayerPrefs.SetInt("totlaHP", totalHP);
    //    PlayerPrefs.SetInt("curHP", curHP);
    //}

    public void AddGold(int gold)
    {
        playerData.gold += gold;
        //SaveData();
    }
    public bool SpendGold(int gold)
    {
        if(playerData.gold >= gold)
        {
            playerData.gold -= gold;
            //SaveData();
            return true;
        }

        return false;
    }

    public void IncreaseTotalHP(int addHP)
    {
        playerData.totalHp += addHP;
        //SaveData();
    }

    public void SetCurrentHP(int hp)
    {
        playerData.curHp += hp;

        if (playerData.curHp > playerData.totalHp)
            playerData.curHp = playerData.totalHp;

        if (playerData.curHp < 0)
            playerData.curHp = 0;

        playerData.curHp = Mathf.Clamp(playerData.curHp,0,100);
    }
}
