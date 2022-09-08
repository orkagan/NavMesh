using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] protected Vector3 _startPosition;
    [SerializeField] protected Vector3 _endPosition;

    [Range(0f,1f)]
    [SerializeField] protected float _t;
    [SerializeField] protected float _speed;
    protected bool _forward = true;
    [SerializeField] protected float _pauseTime = 1f;
    [SerializeField] protected float _startPauseTime = 0.5f;

    void Update()
    {
        if (Time.time < _startPauseTime + _pauseTime)
        {
            return;
        }
        
        if (_forward)
        {
            _t += _speed * Time.deltaTime;
            _t = Mathf.Min(1, _t);
            if (_t >= 1)
            {
                _forward = false;
                _startPauseTime = Time.time;
            }
        }
        else
        {
            _t -= _speed * Time.deltaTime;
            _t = Mathf.Max(0, _t);
            if (_t <= 0)
            {
                _forward = true;
                _startPauseTime = Time.time;
            }
        }
        transform.position = NextMove(_t);
    }

    protected virtual Vector3 NextMove(float t)
    {
        return Vector3.Lerp(_startPosition, _endPosition, t);
    }
}
