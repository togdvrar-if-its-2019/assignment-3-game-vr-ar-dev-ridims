using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCoin : MonoBehaviour{

    public GameObject Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player) {
            Debug.Log("Coin Acquired");
            Destroy(this.gameObject);
        }
    }

}
