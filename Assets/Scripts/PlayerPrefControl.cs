using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefControl : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("testkey", 2);
        Debug.Log(PlayerPrefs.HasKey("testkey"));
        Debug.Log(PlayerPrefs.GetInt("testkey"));
    }

}
