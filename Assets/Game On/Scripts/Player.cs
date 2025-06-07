using UnityEngine;
using System;

public class Player : MonoBehaviour
{
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
	#endregion

	#region Private Methods
	#endregion

}
