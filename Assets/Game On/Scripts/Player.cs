using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
	public enum FacingDirection { Left, Right }

	#region Properties
	public FacingDirection CurrentDirect { get; set; } = FacingDirection.Left;
	public bool isWalking { get; set; }
	#endregion

	#region Fields
	[SerializeField] private Jetpack _jetpack;
	[SerializeField] private float _walkSpeed = 5f;
	[SerializeField] private float _groundCheckD = 0.1f;
	[SerializeField] private LayerMask _gLayerMask = -1;
	[SerializeField] private float _walkStopDelay = 0.1f;

	private Animator _anim;
	private Rigidbody2D _rb;
	private bool _isGrounded;
	private float _lastWalkTime;
	#endregion

	#region Unity Callbacks
	private void Awake()
	{
		_anim = GetComponent<Animator>();
		_rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		CheckGrounded();
		if (isWalking && Time.time - _lastWalkTime > _walkStopDelay)
		{
			isWalking = false;
		}
		UpdateAnimations();
	}

    void FixedUpdate()
    {
		if (_isGrounded && isWalking && !_jetpack.Flying)
		{
			float moveDirect = CurrentDirect == FacingDirection.Left ? -1f : 1f;
			_rb.velocity = new Vector2(moveDirect * _walkSpeed, _rb.velocity.y);
		}
		else if (!_jetpack.Flying && _isGrounded)
			_rb.velocity = new Vector2(0, _rb.velocity.y);
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
	}

	public void Walk(FacingDirection direction)
    {
		SetDirect(direction);
		isWalking = true;
		_lastWalkTime = Time.time;
    }

	public void StopWalking()
    {
		if (Time.time - _lastWalkTime > _walkStopDelay)
		{
			isWalking = false;
		}
	}
	#endregion

	#region Private Methods
	private void CheckGrounded()
	{
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _groundCheckD, _gLayerMask);
		_isGrounded = hit.collider != null;
	}

	private void UpdateAnimations()
    {
		if (_anim != null)
        {
			_anim.SetBool("Flying", _jetpack.Flying);
			_anim.SetBool("Walking", isWalking && _isGrounded && !_jetpack.Flying);
			_anim.SetBool("Grounded", _isGrounded);
		}
    }
	#endregion

}
