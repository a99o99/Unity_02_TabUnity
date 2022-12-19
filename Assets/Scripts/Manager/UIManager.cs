using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    #region Singletone
    private static UIManager instance = null;

    public static UIManager GetInstance()
    {
        if(instance == null) 
        {
            GameObject go = new GameObject("@UIManager");
            instance = go.AddComponent<UIManager>();

            DontDestroyOnLoad(go);
        }

        return instance;
    }
    #endregion

    #region UI Control

    public void SetEventSystem()
    {
        if(FindObjectOfType<EventSystem>() == false)
        {
            GameObject go = new GameObject("@EventSystem");
            go.AddComponent<EventSystem>();
            go.AddComponent<StandaloneInputModule>();
        }
    }

    Dictionary<string, GameObject> uiList = new Dictionary<string, GameObject>();


    public void OpenUI(string uiName)
    {
        if (uiList.ContainsKey(uiName) == false)                //이미 만들어져있는지 확인
        {
            Object uiObj = Resources.Load("UI/"+uiName);        //오브젝트 불러오기
            GameObject go = (GameObject)Instantiate(uiObj);     //불러온 오브젝트를 게임오브젝트 형태로 저장하고 생성
            uiList.Add(uiName, go);
        }

        else
            uiList[uiName].SetActive(true);         //  = GameObject ui = uiList[uiName]
                                                    //    ui.SetActive(true);
    }

    public void CloseUI(string uiName)
    {
        if (uiList.ContainsKey(uiName))
            uiList[uiName].SetActive(false);
    }


    public GameObject GetUI(string uiName)
    {
        if (uiList.ContainsKey(uiName))
            return uiList[uiName];

        return null;
    }

    public void ClearList()
    {
        uiList.Clear();
    }

    #endregion

}
