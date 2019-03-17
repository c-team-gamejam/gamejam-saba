using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text progressTextBox;
    [SerializeField] Text ClearTextBox;

    private void Start()
    {
        ClearTextBox.enabled = false;
    }

    public void SyncProgress(float requiredDHA, float currentDHA)
    {
        var percentage = currentDHA / requiredDHA;
        //progressTextBox.text = currentDHA + " / " + requiredDHA ;
        progressTextBox.text = string.Format("{0:###}/100%", percentage * 100);
    }

    public void DisplayClearText()
    {
        ClearTextBox.enabled = true;
    }
}
