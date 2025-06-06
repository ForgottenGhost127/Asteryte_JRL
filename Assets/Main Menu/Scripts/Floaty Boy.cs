using UnityEngine;
using System;

public class FloatyBoy : MonoBehaviour
{
    #region Fields
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _rotationSpeed = 30f;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _canvasWidth = 989.75f;
    #endregion

    #region Unity Callbacks
    void Start()
    {
        float spriteWidth = GetComponent<RectTransform>().rect.width;
        _startPosition.x = _canvasWidth / 2 + spriteWidth;
    }

    void Update()
    {
        MoveHoriz();
        RotateSprite();
    }
    #endregion

    #region Private Methods
    private void MoveHoriz()
    {
        transform.localPosition += Vector3.left * _speed * Time.deltaTime;

        float spriteWidth = GetComponent<RectTransform>().rect.width;
        if (transform.localPosition.x < -_canvasWidth / 2 - spriteWidth)
        {
            Respawn();
        }

    }

    private void RotateSprite()
    {
        transform.Rotate(Vector3.forward * _rotationSpeed * Time.deltaTime);
    }

    private void Respawn()
    {
        transform.localPosition = _startPosition;
    }
    #endregion

}
