using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalStats : MonoBehaviour
{
    public static GameObject Player;
    public static int money = 0;
    public static int[] gems = new int[3];
    public static float runSpeed = 10.0f;
    public static bool[] unlockables = new bool[10];

    private void Awake()
    {
        unlockables[0] = true;
        DontDestroyOnLoad(this);
    }
}