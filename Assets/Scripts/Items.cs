using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Items : MonoBehaviour
{
    private TextMeshProUGUI txtCash;

    Items items;
    public int bagsRecovery;

    private void Start()
    {
        txtCash = GetComponent<TextMeshProUGUI>();
        items = this;
    }
    private void Update()
    {
        AddBags();
    }
    void AddBags()
    {
        if (TxtScore.score >= 1)
        {
            txtCash.text = "" + bagsRecovery + 1;
        }
    }

}



