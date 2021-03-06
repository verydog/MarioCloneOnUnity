﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FungsFlower : MonoBehaviour {
	public Transform bonusPrefab;
	public float yPosition = 0.68f;
	private bool make;

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.name == "Player" && 
			c.gameObject.GetComponent<Rigidbody2D>().velocity.y>0
			&& !make) {
			if (c.gameObject.GetComponent<PlayerScript>().status!=PlayerStatus.Small) {
				transform.parent.GetComponent<Animator> ().SetTrigger ("isFlower");
			} else {
				transform.parent.GetComponent<Animator> ().SetTrigger ("isFungs");
				Invoke ("createBonus", 0.5f);
			}

			SoundEffectsHelper.Instance.Make_show_bonus_Sound ();

			make = true;
		}
	}

	private void createBonus()
	{
		Vector3 tp = new Vector3 (transform.position.x, transform.position.y + yPosition, transform.position.z);
		Instantiate (bonusPrefab, tp , Quaternion.identity);
	}
}

