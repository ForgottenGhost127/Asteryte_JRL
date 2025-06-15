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
	private bool _facingLeft = false;
    private bool _isGrounded;
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
        if (!_jetpack.Flying)
        {
            _rb.velocity = new Vector2(horizontalInput * _walkSpeed, _rb.velocity.y);
            //bool isWalking = Mathf.Abs(horizontalInput) > 0.1f;
            //_anim.SetBool("Walking", isWalking);

            if (_rb.velocity.x >= 0.01f || _rb.velocity.x <= -0.01f && _isGrounded)
                _anim.SetBool("Walking", true);

            if (_rb.velocity.x == 0 && !_isGrounded)
                _anim.SetBool("Walking", false);

            if (horizontalInput > 0 && !_facingLeft)
                Flip();
            else if (horizontalInput < 0 && _facingLeft)
                Flip();
        }
    }
    #endregion

    #region Private Methods
    private void Flip()
    {
        if (!_facingLeft)
        {
            _spriteRender.flipX = true;
            _facingLeft = !_facingLeft;
            return;
        }
        else
        {
            _spriteRender.flipX = false;
            _facingLeft = false;
        }
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            _isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //if (collision.gameObject.tag != "Ground")
        //    _isGrounded = false;
        if (collision.gameObject.tag == "Ground")
              _isGrounded = false;
    }
    #endregion

}
