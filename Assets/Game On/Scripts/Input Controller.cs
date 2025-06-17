using UnityEngine;
using System;

public class InputController : MonoBehaviour
{
	#region Fields
	[SerializeField] private Jetpack _jetpack;
	[SerializeField] private Player _player;
	#endregion

	#region Unity Callbacks
	void Update()
	{
		float horizontal = Input.GetAxis("Horizontal");
		if(horizontal < 0)
        {
			_jetpack.FlyHorizontal(Jetpack.Direction.Left);
			_player.SetDirect(Player.FacingDirection.Left);
		} 
		else if(horizontal > 0)
		{
            _jetpack.FlyHorizontal(Jetpack.Direction.Right);
            _player.SetDirect(Player.FacingDirection.Right);
        }

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
