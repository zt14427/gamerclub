using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusEffectUI : MonoBehaviour
{
    struct StatusEffect
    {
        public string name;
        public float duration;
        public string color;
        public float invokeTime;

        public StatusEffect(string name, float duration, string color)
        {
            this.name = name;
            this.duration = duration;
            this.color = color;
            this.invokeTime = Time.time;
        }
    }

    Text UIText;
    string temp;
    static List<StatusEffect> activeEffects = new List<StatusEffect>();

    public static void AddEffect(string name, float duration, string color)
    {
        activeEffects.Add(new StatusEffect(name, duration, color));
    }

    private void Awake()
    {
        UIText = GetComponent<Text>();
    }



    // Update is called once per frame
    void Update()
    {
        temp = "";
        foreach (StatusEffect effect in activeEffects)
        {
            // Remove the effect if the duration is over.
            //Debug.Log(Time.time + " : " + effect.invokeTime + " - " + effect.duration);
            if (Time.time > (effect.invokeTime + effect.duration))
            {
                activeEffects.Remove(effect);
                Debug.Log("continuing");
                continue;
            }

            //Debug.Log(effect.color);
            temp += "<color=" + effect.color.ToString() + ">" + effect.name + ": "
                + (int)(effect.duration - (Time.time - effect.invokeTime + 0.5f)) + " </color>\n";
        }
        if (temp.Length > 0) temp = temp.Remove(temp.Length - 1, 1);
        UIText.text = temp;
    }
}
