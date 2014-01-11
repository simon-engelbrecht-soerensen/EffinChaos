﻿using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {
	bool isDead = false;
	Rect rect;
	Movement movement;
	Highscores highscores;
	void Start() {
		float h = Screen.height / 4;
		rect = new Rect (Screen.width/2-h, Screen.height/2-h, h*2, h*2);
		movement = GetComponent<Movement>();
		highscores = GetComponent<Highscores>();
	}
	void OnCollisionEnter(Collision c) {
		//float dot = 0;
		/*foreach (ContactPoint cp in c.contacts) {
			float d = Vector3.Dot (Vector3.forward, cp.normal);
			if (d < dot) dot = d;
		}
		if (dot < -0.7f) {*/
			LevelSpawner.instance.enabled = false;	
			isDead = true;
			movement.enabled = false;
			rigidbody.isKinematic = true;
			CurveWorld.instance.enabled = false;
			highscores.dead = true;
			
		//}
		//Debug.Log(dot);
	}
	void OnGUI() {
		if (isDead && GUI.Button (rect, "Game Over!\nPlay Again?")) {
			Application.LoadLevel (Application.loadedLevelName);
		}
	}
}
