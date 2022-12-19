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
        if (instance == null)                                //instance�� �������
        {
            GameObject go = new GameObject("@ScenesManager");   //������Ʈ �����ϰ� �̸� "@ScenesManager" �� ����
            instance = go.AddComponent<ScenesManager>();        //ScenesManager ã�Ƽ� �ο�

            DontDestroyOnLoad(go);                          //����ȯ�� �Ǿ �ı����� �ʰ� ��������
        }

        return instance;                                    //������ ������ �̱��� ��ȯ
    }
    #endregion

    #region Scene Control
    public Scene currentScene;

    public void ChangeScene(Scene scene)             //string�� �پ��� ���ڰ� �� �� �ֱ� ������ �̳� Ȱ��
    {
        UIManager.GetInstance().ClearList();
        EffectManager.GetInstance().ReleasPool();

        currentScene = scene;
        SceneManager.LoadScene(scene.ToString());   //��Ʈ������ ��ȯ�ؼ� ����.
    }
    #endregion
}
