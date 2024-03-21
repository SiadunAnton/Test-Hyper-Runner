using UnityEngine;
using System;

public class LinePainter : MonoBehaviour
{
    public Action<Vector3[]> OnDrawLine;

    [SerializeField] private float _minDistance;

    private LineRenderer _line;
    private Vector3 _previousPosition;
    private bool _paint = false;

    private void Awake()
    {
        _line = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (_paint)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane + 1f;
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            if(Vector3.Distance(currentPosition, _previousPosition) > _minDistance)
            {
                _line.positionCount++;
                _line.SetPosition(_line.positionCount - 1, currentPosition);
                _previousPosition = currentPosition;
            }
        }
    }

    public void Draw()
    {
        _paint = true;
    }

    public void Stop()
    {
        _paint = false;
        Vector3[] positions = new Vector3[_line.positionCount];
        _line.GetPositions(positions);
        Debug.Log(positions[0]);
        OnDrawLine?.Invoke(positions);
        _previousPosition = Vector3.zero;
    }

    public void ClearCanvas()
    {
        _line.positionCount = 0;
    }

}
