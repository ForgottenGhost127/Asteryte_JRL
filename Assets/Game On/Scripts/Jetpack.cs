using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Jetpack : MonoBehaviour
{
	public enum Direction
	{
		Left,
		Right
	}

	#region Properties
	public float Energy
	{
		get
		{
			return _energy;
		}
		set
		{
			_energy = Mathf.Clamp(value, 0, _maxEnergy);
		}
	}
	public bool Flying { get; set; }
	#endregion

	#region Fields
	private Rigidbody2D _targetRB;
	[SerializeField] private float _energy;
	[SerializeField] private float _maxEnergy = 100f;
	[SerializeField] private float _energyFlyingRatio = 1f;
	[SerializeField] private float _energyRegenerationRatio = 0.5f;
	[SerializeField] private float _horizontalForce = 5f;
	[SerializeField] private float _flyForce = 10f;
	#endregion

	#region Unity Callbacks
	private void Awake()
	{
		_targetRB = GetComponent<Rigidbody2D>();
	}
	void Start()
	{
		Energy = _maxEnergy;
	}

	void FixedUpdate()
	{
		if (Flying)
			DoFly();

		//Le quitamos el signo a la velocidad si es negativa.
		//Luego si es menor de 0.1, consideramos que estamos parados y cargamos
		if (Mathf.Abs(_targetRB.velocity.y) < 0.1f)
			Regenerate();
	}
	#endregion

	#region Public Methods
	public void FlyUp()
	{
		Flying = true;
	}
	public void StopFlying()
	{
		Flying = false;
	}

	public void Regenerate()
	{
		Energy += _energyRegenerationRatio;
	}

	public void AddEnergy(float energy)
	{
		Energy += energy;
	}

	public void FlyHorizontal(Direction flyDirection)
	{
		if (!Flying)
			return;

		float horizontalVelocity = flyDirection == Direction.Left ? -_horizontalForce : _horizontalForce;
		_targetRB.velocity = new Vector2(horizontalVelocity, _targetRB.velocity.y);

		//if (flyDirection == Direction.Left)
		//	_targetRB.AddForce(Vector2.left * _horizontalForce);
		//else
		//	_targetRB.AddForce(Vector2.right * _horizontalForce);

	}
	#endregion

	#region Private Methods
	private void DoFly()
	{
		if (Energy > 0)
		{
			_targetRB.velocity = new Vector2(_targetRB.velocity.x, _flyForce);
			//_targetRB.AddForce(Vector2.up * _flyForce);
			Energy -= _energyFlyingRatio;

			Debug.Log($"Aplicando fuerza: {_flyForce}, Energía restante: {Energy}");
		}
		else
			Flying = false;
	}
	#endregion

}
