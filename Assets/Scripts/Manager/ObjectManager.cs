using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    #region Singletone
    private static ObjectManager instance = null;

    public static ObjectManager GetInstance()
    {
        if (instance == null) 
        {
            GameObject go = new GameObject("@ObjectManager");
            instance = go.AddComponent<ObjectManager>();

            DontDestroyOnLoad(go); 
        }

        return instance;
    }
    #endregion

    public GameObject CreateCharacter(string characterName)
    {
        Object characterObj = Resources.Load("Sprite/"+characterName);
        GameObject charactre = (GameObject)Instantiate(characterObj);

        return charactre;
    }

    public GameObject CreateMonster(string monsterName)
    {
        Object MonsterObj = Resources.Load("Sprite/"+monsterName);
        GameObject charactre = (GameObject)Instantiate(MonsterObj);

        return charactre;
    }

    public ParticleSystem CreateHitEffect()
    {
        //GameObject go = ObjectManager.GetInstance().CreateMonster();
        //go.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        //go.transform.localPosition = new Vector3(0, 0.6f, 0);

        Object effectObj = Resources.Load("Effect/Hit_blood");
        GameObject effect = (GameObject)Instantiate(effectObj);

        return effect.GetComponent<ParticleSystem>();
    }
}
