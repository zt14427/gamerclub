using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUpdater : MonoBehaviour
{
    private static Text inventoryText;
    void Start()
    {
        inventoryText = GetComponent<Text>();
        Debug.Log("Current text: " + inventoryText.text);
        updateInventoryText();
    }

    public static void updateInventoryText()
    {
        string tempText = "";
        tempText += (LocalStats.gems[0] > 0) ? "<color=red>Ruby: </color>" + LocalStats.gems[0] + "\n" : "";
        tempText += (LocalStats.gems[1] > 0) ? "<color=green>Emerald: </color> " + LocalStats.gems[1] + "\n" : "";
        tempText += (LocalStats.ores[0] > 0) ? "<color=brown>Copper: </color> " + LocalStats.ores[0] + "\n" : "";
        tempText += (LocalStats.ores[1] > 0) ? "<color=grey>Iron: </color> " + LocalStats.ores[1] + "\n" : "";
        tempText += (LocalStats.money > 0) ? "<color=yellow>Money: </color> " + LocalStats.money + "\n" : "";
        inventoryText.text = tempText;
    }

}
