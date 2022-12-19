using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData 
{
    public string name;

    public int level;

    public int gold;
    public int totalHp;
    public int curHp;

    public int characterIdx;

    public PlayerData(string name, int level, int gold, 
        int totalHp, int curHp, int characterIdx)
    {
        this.name = name;
        this.level = level;
        this.gold = gold;
        this.totalHp = totalHp;
        this.curHp = curHp;
        this.characterIdx = characterIdx;

    }
}
