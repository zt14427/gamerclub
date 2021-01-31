using System.IO;
using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetText : MonoBehaviour
{
    public String changingText;

    // Start is called before the first frame update
    public void updateText()
    {
        Text DebugText = GameObject.Find("UI/Canvas/DebugText").GetComponent<Text>();
        string resourceLocation = Directory.GetCurrentDirectory();
        DebugText.text = "Debug Log: " + resourceLocation;
    }

}
