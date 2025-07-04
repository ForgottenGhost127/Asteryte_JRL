using UnityEngine;
using System;

public class INose : Item
{
	#region Constants
	const float NOSE_DAMAGE = -20;
	#endregion

	#region Unity Callbacks
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground")
			Recolected();

		if (collision.gameObject.tag == "Player")
		{
			Jetpack jetpack = collision.gameObject.GetComponent<Jetpack>();
			jetpack.AddEnergy(NOSE_DAMAGE);
			Recolected();
		}
	}
	#endregion
}
