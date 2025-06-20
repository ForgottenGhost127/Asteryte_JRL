using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
	#region Fields
	[SerializeField] private Jetpack _jetpack;
	[SerializeField] private Slider _energySlider;
	[SerializeField] private TextMeshProUGUI _textAltitude;
	#endregion

	#region Unity Callbacks
    void Update()
    {
		_energySlider.value = _jetpack.Energy;
		_textAltitude.text = ((int)_jetpack.transform.position.y).ToString();
	}
	#endregion

	#region Public Methods
	#endregion

	#region Private Methods
	#endregion
   
}
