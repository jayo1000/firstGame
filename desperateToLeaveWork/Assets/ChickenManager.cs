﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.PlayerLoop;

[Serializable]
public class ChickenData
{
    public string name;
    public Sprite sprite;
    public string key;
    public float price;
}
public class ChickenManager : MonoBehaviour
{
    public List<ChickenData> chickens = new List<ChickenData>();
    [HideInInspector] int index = 0;


    public SpriteRenderer sprite_chicken;
    public Text txt_name;
    public Button btn_buy;
    public Text txt_price;

    public Button btn_left;
    public Button btn_right;

    [HideInInspector] string insert_string = "buy_";


    /*
     *
     * 
     * 
     */
    // Start is called before the first frame update
    private void Awake()
    {
        BuyChicken(chickens[0].key);
    }

    private void Start()
    {
        Scene curScene = SceneManager.GetActiveScene();
        if(curScene.name == "MainScene")
        {
            UpdateUi();
        }
        else if(curScene.name == "GameScene")
        {
            ChickenData chickenData = Get_SelectedChickenData();
            JUMP player = FindObjectOfType<JUMP>();
            player.transform.gameObject.GetComponent<SpriteRenderer>().sprite = chickenData.sprite; 
        }
    }

    public ChickenData GetCurChickenData()
    {
        return chickens[index];
    }
    public void UpdateUi()
    {
        ChickenData chickenData = GetCurChickenData();
        txt_name.text = chickenData.name;
        txt_price.text = chickenData.price.ToString("F0");
        sprite_chicken.sprite = chickenData.sprite;
        Set_SelectedChickenKey(chickenData.key);

        if (CheckBought(chickenData.key))
        {
            // 이미 산것
            btn_buy.gameObject.SetActive(false);
        }
        else
        {
            // 아직 안삼
            btn_buy.gameObject.SetActive(true);
        }

        if(index == 0)
        {
            btn_left.gameObject.SetActive(false);
        }
        else
        {
            btn_left.gameObject.SetActive(true);
        }


        if(index == (chickens.Count -1) )
        {
            btn_right.gameObject.SetActive(false);
        }
        else
        {
            btn_right.gameObject.SetActive(true);
        }
    }

    string selected_chicken_key = "selected_chicken";
    public void Set_SelectedChickenKey(string key)
    {
        PlayerPrefs.SetString(selected_chicken_key, key);
    }

    public ChickenData Get_SelectedChickenData()
    {
        string key = PlayerPrefs.GetString(selected_chicken_key);
        foreach(ChickenData chickenData in chickens)
        {
            if(chickenData.key == key)
            {
                return chickenData;
            }
        }
        return null;
    }

    public bool CheckBought(string key)
    {
        if(PlayerPrefs.GetInt(insert_string+key) == 1)
        {
            return true;
        }
        return false;
    }

    public void BuyChicken(string key)
    {
        PlayerPrefs.SetInt(insert_string + key, 1);
    }

    public void OnClick_Left()
    {
        if(index > 0 )
        {
            index--;
            UpdateUi();
        }
    }
    public void OnClick_Right()
    {
        if(index < (chickens.Count - 1))
        {
            index++;
            UpdateUi();
        }
    }
    public void OnClick_Buy()
    {
        ChickenData chickenData = GetCurChickenData();
        MoneyManager moneyManager = FindObjectOfType<MoneyManager>();
        if(moneyManager.UpdateMoney(false,(int)chickenData.price))
        {
            // 구매 됨
            BuyChicken(chickenData.key);
            UpdateUi();
        }
        else
        {
            Debug.Log("No money, No Chicken");
        }
    }
}
