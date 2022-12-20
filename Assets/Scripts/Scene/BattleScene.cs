using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        MonsterBase monster = BattleManager.Instance.GetRandomMonster();

        GameObject go = ObjectManager.GetInstance().CreateMonster(monster.monsterName);
        go.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        go.transform.localPosition = new Vector3(0, 0.6f, 0);

        UIManager.GetInstance().SetEventSystem();
        UIManager.GetInstance().OpenUI("UIProfile");

        BattleManager.Instance.BattleStart(monster);
    }

}
