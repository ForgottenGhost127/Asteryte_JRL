using UnityEngine;
using System;

public class Player : MonoBehaviour
{
	public enum FacingDirection { Left, Right }

	#region Properties
	public FacingDirection CurrentDirect { get; set; } = FacingDirection.Left;
	#endregion

	#region Fields
	[SerializeField] private Jetpack _jetpack;
	private Animator _anim;
	#endregion

	#region Unity Callbacks
	private void Awake()
	{
		_anim = GetComponent<Animator>();
	}

	void Update()
	{
		_anim.SetBool("Flying", _jetpack.Flying);
	}
	#endregion

	#region Public Methods
	public void SetDirect(FacingDirection direction)
    {
		if (direction == CurrentDirect) return;
		CurrentDirect = direction;

		transform.localScale = new Vector3(direction == FacingDirection.Left ? 1 : -1,
			1,
			1
		);


		//float yRotation = direction == FacingDirection.Right ? 0f : 180f;
		//transform.rotation = Quaternion.Euler(0, yRotation, 0);
	}
	#endregion

	#region Private Methods
	#endregion

}
