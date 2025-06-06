using UnityEngine;
using System;

public class InputController : MonoBehaviour
{
	#region Fields
	[SerializeField] private Jetpack _jetpack;
	#endregion

	#region Unity Callbacks
    void Update()
    {
		//Horizontal Fly
		if (Input.GetAxis("Horizontal") < 0)
			_jetpack.FlyHorizontal(Jetpack.Direction.Left);
		if (Input.GetAxis("Horizontal") > 0)
			_jetpack.FlyHorizontal(Jetpack.Direction.Right);

		//Vertical Fly
		if (Input.GetAxis("Vertical") > 0)
			_jetpack.FlyUp();
		else
			_jetpack.StopFlying();

	}
	#endregion

	#region Public Methods
	#endregion

	#region Private Methods
	#endregion

}
