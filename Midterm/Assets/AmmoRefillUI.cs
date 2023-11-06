using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AmmoRefillUI : MonoBehaviour
{
    public TMP_Text ammoText;
    public PLAYER player;

    private void Start()
    {
        if (player == null)
        {
            player = FindObjectOfType<PLAYER>();
        }

        if (ammoText == null)
        {
            Debug.LogError("Ammo text reference not set in the inspector.");
        }
    }

    private void Update()
    {
        if (player != null && ammoText != null)
        {
            ammoText.text = "Ammo: " + player.currentAmmo.ToString();
        }
    }
}
