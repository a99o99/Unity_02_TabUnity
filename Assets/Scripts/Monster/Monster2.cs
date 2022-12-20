using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2 : MonsterBase
{
    public Monster2(string monsterName, int atk, int hp, float delay, int gold)
    {
        this.monsterName = monsterName;
        this.atk = atk;
        this.hp = hp;
        this.delay = delay;
        this.gold = gold;
    }

    public override void Attack()
    {
        float criticalRate = Random.Range(0,100.0f);

        int damage = atk;
        if (criticalRate < 10)
            damage *= 2;

        GameManager.GetInstance().SetCurrentHP(-damage);
    }
}
