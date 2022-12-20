using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    #region Singletone
    private static BattleManager instance = null;

    public static BattleManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("@BattleManager");
                instance = go.AddComponent<BattleManager>();

                DontDestroyOnLoad(go);
            }

            return instance;
        }

    }
    #endregion

    public MonsterBase[] monsterDatas = new MonsterBase[]
    {
        new Monster1("Monster1", 10, 30, 2.5f, 300),
        new Monster2("Monster2", 15, 50, 2f, 1000),
        new Monster3("Monster3", 6, 30, 2f, 500)
    };

    public MonsterBase GetRandomMonster()
    {
        int rand = Random.Range(0, monsterDatas.Length);

        return monsterDatas[rand];
    }

    public MonsterBase monsterData;

    GameObject uiTab;
    
    public void BattleStart(MonsterBase monster)
    {
        monsterData = monster;

        EffectManager.GetInstance().InitEffectPool(3);
        UIManager.GetInstance().OpenUI("UITab");

        StartCoroutine("BattleProgress");
    }

    IEnumerator BattleProgress()
    {
        while (GameManager.GetInstance().playerData.curHp > 0)
        {
            yield return new WaitForSeconds(monsterData.delay);

            int damage = monsterData.atk;
            GameManager.GetInstance().SetCurrentHP(-damage);

            monsterData.Attack();

            GameObject ui = UIManager.GetInstance().GetUI("UIProfile");
            if(ui != null)
            {
                ui.GetComponent<UIProfile>().RefreshState();
            }
            Debug.Log($"���Ͱ� �÷��̾�� ������ �߽��ϴ�. - ������ : {damage}   ����ü�� : {GameManager.GetInstance().playerData.curHp}");

        }

        Lose();
    }

    public void AttackMonster()
    {
        EffectManager.GetInstance().UseEffect();

        monsterData.hp--;

        if(monsterData.hp <= 0)
        {
            Victory();
        }
    }

    void Victory()
    {
        Debug.Log("�¸��Ͽ����ϴ�.");
        StopCoroutine("BattleProgress");
        UIManager.GetInstance().CloseUI("UITab");

        GameManager.GetInstance().AddGold(monsterData.gold);

        Invoke("MoveToMain", 2.5f);
    }

    void Lose()
    {
        Debug.Log("�й�.");
        UIManager.GetInstance().CloseUI("UITab");

        if (GameManager.GetInstance().SpendGold(500))
            GameManager.GetInstance().SetCurrentHP(80);
        else
            GameManager.GetInstance().SetCurrentHP(10);

        Invoke("MoveToMain", 2.5f);

    }

    void MoveToMain()
    {
        ScenesManager.GetInstance().ChangeScene(Scene.Main);
    }
}
