using UnityEngine;
using System;

public class End : MonoBehaviour
{
	#region Fields
	[Header("Referencia de objetos")]
	[SerializeField] private GameObject _endPlatform;
	[SerializeField] private GameObject _winnerCanvas;
	[SerializeField] private GameObject _player;
	#endregion

	#region Unity Callbacks
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			ActivateEndSequence();
		}
	}
    #endregion

    #region Public Methods
    public void ActivateEndSequence()
    {
        if (_endPlatform != null)
        {
            _endPlatform.SetActive(true);
            Debug.Log("EndPlatform activado");
        }

        if (_winnerCanvas != null)
        {
            _winnerCanvas.SetActive(true);
            Debug.Log("Winner Canvas activado");
        }

        if (_player != null)
        {
            DisablePlayerScripts();
            Debug.Log("Scripts del Player desactivados");
        }
    }
    #endregion

    #region Private Methods
    private void DisablePlayerScripts()
    {
        MonoBehaviour[] playerScripts = _player.GetComponents<MonoBehaviour>();

        foreach (MonoBehaviour script in playerScripts)
        {
            if (script != this)
            {
                script.enabled = false;
            }
        }
    }
    #endregion

}
