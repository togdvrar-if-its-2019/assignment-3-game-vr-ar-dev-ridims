using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCoin : MonoBehaviour{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            UpdateCoinAmount updateCoinAmount = FindObjectOfType<UpdateCoinAmount>();
            updateCoinAmount.addCoin();
            Debug.Log("Coin Acquired");
            Destroy(this.gameObject);
        }
    }

}
