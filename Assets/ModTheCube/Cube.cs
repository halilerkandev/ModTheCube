using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    [SerializeField] private Color[] _colors;
    [SerializeField] private int _colorIndex;
    [SerializeField] private float _colorTogglePeriod;
    [SerializeField][Range(0.0f, 1.0f)] private float _lerpTime;

    [SerializeField] private float _speed;
    [SerializeField] private float _speedRange;
    private bool _isSpeedUp = true;

    void Update()
    {
        HandleColor();
        HandleRotation();
    }

    void HandleColor()
    {
        Renderer.material.color = Color.Lerp(Renderer.material.color, _colors[_colorIndex], _lerpTime * Time.deltaTime);
        _colorTogglePeriod = Mathf.Lerp(_colorTogglePeriod, 1.0f, _lerpTime * Time.deltaTime);
        if (_colorTogglePeriod > 0.9f)
        {
            _colorTogglePeriod = 0.0f;
            _colorIndex++;
            if (_colorIndex == _colors.Length)
            {
                _colorIndex = 0;
            }
        }
    }

    void HandleRotation()
    {
        if (_isSpeedUp)
            _speed = Mathf.Lerp(_speed, _speedRange, _lerpTime * Time.deltaTime);
        else
            _speed = Mathf.Lerp(_speed, -_speedRange, _lerpTime * Time.deltaTime);
        if (_speed > _speedRange - 1)
            _isSpeedUp = false;
        if (_speed < -_speedRange + 1)
            _isSpeedUp = true;
        transform.Rotate(_speed * Time.deltaTime * Vector3.up);
    }
}
