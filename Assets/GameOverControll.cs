﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverControll : MonoBehaviour
{
    public void RestartGame() {
        SceneManager.LoadScene("SampleScene");
    }
}
