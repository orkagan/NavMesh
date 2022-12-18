using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockingDoor : MonoBehaviour
{
    [SerializeField] protected Vector3 _startPosition;
    [SerializeField] protected Vector3 _endPosition;
    [SerializeField]
    protected bool _locked = true;
    [Range(0f, 1f)]
    [SerializeField] protected float _t;
    [SerializeField] protected float _speed = 5f;

    void Update()
    {
        //if door is locked and in start pos, or unlocked and in end pos
        if ((_locked&transform.position==_startPosition)||(!_locked&transform.position==_endPosition))
        {
            return;
        }

        if (!_locked)
        {
            _t += _speed * Time.deltaTime;
            _t = Mathf.Min(1, _t);
        }
        else
        {
            _t -= _speed * Time.deltaTime;
            _t = Mathf.Max(0, _t);
        }
        transform.position = NextMove(_t);
    }

    protected virtual Vector3 NextMove(float t)
    {
        return Vector3.Lerp(_startPosition, _endPosition, t);
    }
    public void DoorToggle()
    {
        _locked = !_locked;
    }
    public void SetLocked(bool locked)
    {
        _locked = locked;
    }
}
