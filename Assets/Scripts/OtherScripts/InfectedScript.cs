using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectedScript : EnemyBase
{
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Player"))
		{
			player.InfectedTakeDamage();
		}
	}
}