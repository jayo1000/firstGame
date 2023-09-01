using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour {
    public Text txt_money;
    public int money;

    private void Awake() {
        money = PlayerPrefs.GetInt("money");
        UpdateMoney(true, 0);
    }

    public bool UpdateMoney(bool up, int value) {
        if (up) {
            money += value;
            SaveMoney();
            UpdateUi();
            return true;
        }
        else {
            if(money >= value) {
                money -= value;
                SaveMoney();
                UpdateUi();
                return true;
            }
            else {
                return false;
            }
        }
    }

    public void SaveMoney() {
        PlayerPrefs.SetInt("money", money);
    }

    public void UpdateUi() {
        txt_money.text = money.ToString("F0") + "G";
    }
}
