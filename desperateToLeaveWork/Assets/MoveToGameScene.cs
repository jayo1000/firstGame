﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToGameScene : MonoBehaviour
{
    public void OnClick_Move() {
        SceneManager.LoadScene("GameScene");
    } 
}
