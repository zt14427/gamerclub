using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Equip", menuName = "Inventory")]
public class Equip
{
    public string name;
    public Image sprite;

    public int health;
    public int attack;
    public int defense;

    public Equip()
    {
        this.name = "default";
        health = 0;
        attack = 0;
        defense = 0;
    }
}
