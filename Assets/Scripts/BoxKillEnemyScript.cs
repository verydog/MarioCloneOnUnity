﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxKillEnemyScript : MonoBehaviour {
	private Animator an;
	private bool CanKill; 
	void Awake () {
		an = transform.parent.GetComponent<Animator> ();
	}
	void Update()
	{
		if (an.GetCurrentAnimatorStateInfo (0).IsTag ("Active")) {
			CanKill = true;
		} else {
			CanKill = false;
		}
	}
	void OnCollisionStay2D(Collision2D coll)
	{
		if(CanKill && coll.gameObject.tag=="Enemy"){
			Collider2D cd1 = coll.gameObject.GetComponent<CapsuleCollider2D> ();
			Rigidbody2D rigidbody2D = coll.gameObject.GetComponent<Rigidbody2D> ();
			SpriteRenderer sp1 = coll.gameObject.GetComponent<SpriteRenderer> ();
			sp1.sortingLayerName = "FrontLayer";
			sp1.sortingOrder = 10;
			sp1.flipY = true;
			coll.transform.position = new Vector2 (coll.transform.position.x, coll.transform.position.y + 0.5f);
			cd1.enabled = false;
			rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
			Destroy (coll.gameObject, 3f);
		}
	}
}