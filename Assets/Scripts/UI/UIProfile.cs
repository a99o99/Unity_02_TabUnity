using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIProfile : MonoBehaviour
{
    public Slider hpBar;
    public Image imgFill;

    public TMP_Text txtHp;

    public TMP_Text txtLevel;
    public TMP_Text txtName;
    public TMP_Text txtGold;

    void Start()
    {
        RefreshState();
    }

    public void RefreshState()
    {
        txtLevel.text = $"Lv.{GameManager.GetInstance().playerData.level}";
        txtName.text = $"{GameManager.GetInstance().playerData.name}";
        txtGold.text = $"{GameManager.GetInstance().playerData.gold}g";

        hpBar.maxValue = GameManager.GetInstance().playerData.totalHp;
        hpBar.value = GameManager.GetInstance().playerData.curHp;

        txtHp.text = $"{ hpBar.value} / {hpBar.maxValue}";
    }

}
