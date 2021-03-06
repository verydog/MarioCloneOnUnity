﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questionCoinScript : MonoBehaviour {
	public Transform score;
	private bool canDo=true;

	void OnTriggerEnter2D(Collider2D c)
	{
		if (canDo) {
			if (c.gameObject.name == "Player" &&
			   c.gameObject.GetComponent<Rigidbody2D> ().velocity.y > 0) {
				Vector2 position = new Vector2 (c.transform.position.x, c.transform.position.y + 2f);
				showScore (position);

				SoundEffectsHelper.Instance.Make_coins_Sound ();

				transform.parent.GetComponent<Animator> ().SetTrigger ("isActive");
				canDo = false;
			}
		}
	}

	private void showScore(Vector2 position){
		Transform trans = Instantiate (score, position, Quaternion.identity);
		trans.gameObject.GetComponentInChildren<MeshRenderer> ().sortingLayerName = "FrontLayer";
		trans.gameObject.GetComponentInChildren<MeshRenderer> ().sortingOrder = 100;
		trans.gameObject.GetComponentInChildren<TextMesh> ().text="200";
		gameInfo.mario_score+=200;
		gameInfo.coins_count+=1;
		Destroy (trans.gameObject, 0.5f);
	}
}
