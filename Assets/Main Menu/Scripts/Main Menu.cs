using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    #region Fields
    [SerializeField] Button _startGameButton;
    [SerializeField] Button _exitGameButton;
    [SerializeField] private AudioSource _audioSource;
    #endregion

    #region Unity Callbacks
    void Start()
    {
        _startGameButton.onClick.AddListener(StartGame);
        _exitGameButton.onClick.AddListener(ExitGame);

        if(_audioSource != null)
        {
            _audioSource.loop = true;
            _audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No se asignó el AudioSource al Main Menu");
        }
    }

    #endregion

    #region Private Methods
    private void ExitGame()
    {
        Application.Quit();
    }

    private void StartGame()
    {
        if (_audioSource != null)
            _audioSource.Stop();

        SceneManager.LoadScene("GameOn");
    }
    #endregion


}
