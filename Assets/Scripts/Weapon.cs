using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public Transform firePoint;
	public GameObject bulletPrefab;

    private void Start()
    {
		GameManager.instance.controls.Player.Shoot.performed += ctx => Shoot();
	}
	

	void Shoot()
	{
		Instantiate(bulletPrefab, firePoint.position, GameManager.instance.player.GetComponent<PlayerControler>().firePoint.rotation);
	}
}
