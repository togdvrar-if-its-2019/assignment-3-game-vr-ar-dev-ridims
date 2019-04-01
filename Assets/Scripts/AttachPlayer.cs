using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPlayer : MonoBehaviour {

	public GameObject Player;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject == Player){
			Player.transform.parent = transform;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject == Player){
			Player.transform.parent = null;
		}
	}

}
