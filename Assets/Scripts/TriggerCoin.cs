using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCoin : MonoBehaviour{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            GetComponent<AudioSource>().Play();
            UpdateCoinAmount updateCoinAmount = FindObjectOfType<UpdateCoinAmount>();
            updateCoinAmount.addCoin();
            Debug.Log("Coin Acquired");

            GetComponent<SpriteRenderer>().enabled = false;

            GetComponent<PolygonCollider2D>().enabled = false;

            Destroy(this.gameObject, 3);
        }
    }

}
