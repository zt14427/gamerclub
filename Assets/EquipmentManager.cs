using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour
{

    // Stats
    public int health = 0;
    public int attack = 0;
    public int defense = 0;
    private Text statText;

    Equip[] equipment = new Equip[11];

    private void updateStats()
    {
        health = 0;
        attack = 0;
        defense = 0;
        foreach (Equip e in equipment)
        {
            health += e.health;
            attack += e.attack;
            defense += e.defense;
        }
        statText.text = health + "\n" + attack + "\n" + defense;
    }

    private void updateAuxiliaryStats()
    {

    }


}
