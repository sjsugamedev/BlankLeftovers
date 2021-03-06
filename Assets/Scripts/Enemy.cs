﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	private GameObject Player;
	public GameObject projectile;
	Vector2 dir;
	private float currTime;
	public float cooldown = 5;
	public float speed = 10;
	private float yVelCap = 100f;

	void Start() {
		Player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {
		if (rigidbody2D.velocity.y > yVelCap) {
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, yVelCap);
		}
		if (rigidbody2D.velocity.y < -yVelCap) {
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, -yVelCap);
		}
		rigidbody2D.velocity = new Vector2(-speed, rigidbody2D.velocity.y);
		if (Player != null) {
			if (currTime <= Time.time) {
				currTime = Time.time + cooldown;
				dir = new Vector2(-20f, Player.transform.position.y - transform.position.y);
				cloneObject(projectile, transform.position, dir, Quaternion.identity);
			}
		}
	}

	public static GameObject cloneObject (GameObject bulletToClone, Vector3 placetoCreate, Vector3 velocity, Quaternion orientation)
	{		
		GameObject clonedesu = (GameObject)ScriptableObject.Instantiate (bulletToClone, placetoCreate, orientation);
		//Debug.Log("poops: " + clonedesu);

		if (clonedesu.rigidbody2D) {
			clonedesu.rigidbody2D.velocity = velocity;
			//Debug.Log ("poop da doops");
		}
		if(clonedesu.audio)
		{
			clonedesu.audio.Play();
		}
		return clonedesu;
	}
}
