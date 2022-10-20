using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 20f;
	public int damage = 50;
	public Rigidbody2D rb;
	public GameObject impactEffect;

	// Use this for initialization
	void Start()
	{
		rb.velocity = transform.right * speed;
	}
	
	void OnTriggerEnter2D(Collider2D hitInfo)
	{
		if(hitInfo.tag != "player")
        {
			Enemy enemy = hitInfo.GetComponent<Enemy>();
			Debug.Log(hitInfo.name);
			if (enemy != null)
			{
				enemy.TakeDamage(damage);
			}

			Instantiate(impactEffect, transform.position, transform.rotation);

			Destroy(gameObject);
		}
		
	}
}
