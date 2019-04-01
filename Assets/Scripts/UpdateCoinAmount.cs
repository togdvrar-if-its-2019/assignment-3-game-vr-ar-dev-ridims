using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateCoinAmount : MonoBehaviour
{
    private TextMeshProUGUI coinAmount;
    private int amount = 0;

    private void Start()
    {
        coinAmount = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        coinAmount.text = amount.ToString();
    }

    public void addCoin() {
        amount++;
    }
}
