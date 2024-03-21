using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrawArea : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    [SerializeField] private LinePainter _painter;

    private bool _isDrawingStarted = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        StartDrawing();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_isDrawingStarted)
            StopDrawing();
    }

    private void StartDrawing()
    {
        _isDrawingStarted = true;
        _painter.ClearCanvas();
        _painter.Draw();
        Debug.Log("Drawing started.");
    }

    private void StopDrawing()
    {
        _isDrawingStarted = false;
        _painter.Stop();
        Debug.Log("Drawing ended.");
    }
}
