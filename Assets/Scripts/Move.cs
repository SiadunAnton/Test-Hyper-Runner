using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;

    private bool _enabled = true;

    public void Stop()
    {
        _enabled = false;
    }

    private void Update()
    {
        if(_enabled)
            transform.position += _offset;
    }
}
