using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase 
{
    public string monsterName2 { get; set; }
    
    public string monsterName;

    public int atk;
    public int hp;

    public float delay;

    public int gold;

    public virtual void Attack()
    {

    }
}
