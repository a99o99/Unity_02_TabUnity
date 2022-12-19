using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scene
{
    Menu,
    Main,
    Battle
}


public class ScenesManager : MonoBehaviour
{
    #region Singletone
    private static ScenesManager instance = null;

    public static ScenesManager GetInstance()
    {
        if (instance == null)                                //instance가 비었으면
        {
            GameObject go = new GameObject("@ScenesManager");   //오브젝트 생성하고 이름 "@ScenesManager" 로 지정
            instance = go.AddComponent<ScenesManager>();        //ScenesManager 찾아서 부여

            DontDestroyOnLoad(go);                          //씬전환이 되어도 파괴되지 않고 남아있음
        }

        return instance;                                    //기존에 만들어둔 싱글톤 반환
    }
    #endregion

    #region Scene Control
    public Scene currentScene;

    public void ChangeScene(Scene scene)             //string은 다양한 문자가 올 수 있기 때문에 이넘 활용
    {
        UIManager.GetInstance().ClearList();
        EffectManager.GetInstance().ReleasPool();

        currentScene = scene;
        SceneManager.LoadScene(scene.ToString());   //스트링으로 변환해서 받음.
    }
    #endregion
}
