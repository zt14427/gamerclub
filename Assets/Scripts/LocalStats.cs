﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalStats : MonoBehaviour
{
    public static int money = 0;
    public static float runSpeed = 10.0f;
    public static bool[] unlockables = new bool[10];

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}