using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SRC_InteractionBubble : MonoBehaviour
{
    private TextMeshProUGUI thoughts;

    public void Start()
    {
        thoughts = GetComponent<TextMeshProUGUI>();
        thoughts.text =
            "My caravan was attacked, and I seem to be the only survivor...\nAt least I managed to save my equipment.";
    }

    public void GetText(string text)
    {
        thoughts.text = text;
    }
}
