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
		bool isFlying = Input.GetAxis("Vertical") > 0;

		if(isFlying)
        {
			_jetpack.FlyUp();

            if (horizontal < 0)
            {
                _jetpack.FlyHorizontal(Jetpack.Direction.Left);
                _player.SetDirect(Player.FacingDirection.Left);
            }
            else if (horizontal > 0)
            {
                _jetpack.FlyHorizontal(Jetpack.Direction.Right);
                _player.SetDirect(Player.FacingDirection.Right);
            }
        }
        else
        {
            _jetpack.StopFlying();

            if(Mathf.Abs(horizontal) > 0.1f)
            {
                if (horizontal < 0)
                    _player.Walk(Player.FacingDirection.Left);
                else
                _player.Walk(Player.FacingDirection.Right);
            }
            else
                _player.StopWalking();
            
        }
    }
	#endregion

	

}
