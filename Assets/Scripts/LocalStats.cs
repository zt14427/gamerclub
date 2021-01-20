using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalStats : MonoBehaviour
{
    public static GameObject Player;
    public static int money = 0;
    public static int[] gems = new int[3];
    public static float runSpeed = 10.0f;
    public static int jumps = 9;
    public static bool[] unlockables = new bool[10];

    private static float scaleTimer = 0f;
    public static float scaleDuration;
    public static float scale = 1.0f;

    private void Awake()
    {
        gems[0] = 10;
        gems[1] = 1;
        unlockables[0] = true;
        DontDestroyOnLoad(this.gameObject);
    }

    public static void Scale()
    {
        scaleTimer = Time.time;
    }

    private void Update()
    {
        Debug.Log(Time.time);
        if (scale != 1.0f && (Time.time > scaleTimer + scaleDuration))
        {
            scale = 1.0f;
        }
    }


}