using UnityEngine;
using System;

public class Player : MonoBehaviour
{
	#region Fields
	[SerializeField] private Jetpack _jetpack;
	[SerializeField] private float _walkSpeed = 5f;

	private Animator _anim;
	private Rigidbody2D _rb;
	private SpriteRenderer _spriteRender;
	private bool _facingRight = true;
	#endregion

	#region Unity Callbacks
	private void Awake()
	{
		_anim = GetComponent<Animator>();
		_rb = GetComponent<Rigidbody2D>();
		_spriteRender = GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		_anim.SetBool("Flying", _jetpack.Flying);
	}
	#endregion

	#region Public Methods
	public void Move(float horizontalInput)
    {
		if(!_jetpack.Flying)
        {
			_rb.velocity = new Vector2(horizontalInput * _walkSpeed, _rb.velocity.y);
			bool isWalking = Mathf.Abs(horizontalInput) > 0.1f;
			_anim.SetBool("Walking", isWalking);

			if (horizontalInput > 0 && !_facingRight)
				Flip();
			else if (horizontalInput < 0 && _facingRight)
				Flip();
        }
    }
	#endregion

	#region Private Methods
	private void Flip()
    {
		_facingRight = !_facingRight;
		_spriteRender.flipX = !_facingRight;
    }
	#endregion

}
