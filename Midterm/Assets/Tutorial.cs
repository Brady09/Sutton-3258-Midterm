using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public TMP_Text tutorialText;
    public Button dismissButton;

    void Start()
    {
        tutorialText.enabled = true;
        dismissButton.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tutorialText.enabled = false;
            dismissButton.gameObject.SetActive(false);
        }
    }
}
