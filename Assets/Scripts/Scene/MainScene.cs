using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GameManager.GetInstance().LoadData();

        string characterName = "";
        //if (GameManager.GetInstance().characterIdx == 0)
        //{
        //    characterName = GameManager.GetInstance().princeImg;
        //    GameManager.GetInstance().curHP = GameManager.GetInstance().princeHp;
        //    GameManager.GetInstance().totalHP = GameManager.GetInstance().princeHp;

        //}
        //else
        //{
        //    characterName = GameManager.GetInstance().nikeImg;
        //    GameManager.GetInstance().curHP = GameManager.GetInstance().nikeHp;
        //    GameManager.GetInstance().totalHP = GameManager.GetInstance().nikeHp;

        //}

        var player = GameManager.GetInstance().playerData;

        if(GameManager.GetInstance().playerData.characterIdx == 0)
        {
            player = GameManager.GetInstance().GetPlayer(0);
        }

        else
        {
            player = GameManager.GetInstance().GetPlayer(1);
        }

        GameObject go = ObjectManager.GetInstance().CreateCharacter(player.name);  //캐릭터 지정
        go.transform.localScale = new Vector3(2, 2, 2);                 //스케일 조정
        go.transform.localPosition = new Vector3(0, 1.1f, 0);           //포지션 조정

        UIManager.GetInstance().SetEventSystem();
        UIManager.GetInstance().OpenUI("UIProfile");
        UIManager.GetInstance().OpenUI("UIActionMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
