using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class WinnerCanv : MonoBehaviour
{
	#region Fields
	[SerializeField] Button _backMenuButton;
	[SerializeField] private AudioSource _audioSource;
	#endregion

	#region Unity Callbacks
	void Start()
    {
		_backMenuButton.onClick.AddListener(BackMenu);
	}
	#endregion

	#region Private Methods
	private void BackMenu()
	{
		if (_audioSource != null)
			_audioSource.Stop();

		SceneManager.LoadScene("Main Menu");
	}
	#endregion

}
