using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalStats : MonoBehaviour
{
    public static GameObject Player;
    public static int money = 0;
    public static int[] gems = new int[3];
    public static float runSpeed = 10.0f;
    public static int jumps = 1;

    public static int[] ores = new int[7];
    public static int miningXP = 0;

    public static bool[] unlockables = new bool[10];

    public static float buoyancy = 1.0f;
    private static float scaleTimer = 0f;
    public static float scaleDuration;
    public static float scale = 1.0f;

    // {metalized(0 buoyancy), ... }
    public static bool[] modifiers = new bool[2];

    private void Awake()
    {
        //gems[0] = 10;
        //gems[1] = 1;
        unlockables[0] = true;
        DontDestroyOnLoad(this.gameObject);
    }

    public static void Scale()
    {
        scaleTimer = Time.time;
    }

    private void Update()
    {
        if (scale != 1.0f && (Time.time > scaleTimer + scaleDuration))
        {
            scale = 1.0f;
        }
    }


}