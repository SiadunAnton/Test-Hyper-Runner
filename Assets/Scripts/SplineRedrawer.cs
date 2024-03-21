using UnityEngine;
using Dreamteck.Splines;

public class SplineRedrawer : MonoBehaviour
{
    [SerializeField] private SplineSmoothTransition _transition;
    [SerializeField] private LinePainter _painter;
    [SerializeField] private Vector3 _offset;

    void Start()
    {
        _painter.OnDrawLine += RecalculateSpline;
    }

    private void RecalculateSpline(Vector3[] positions)
    {

        SplinePoint[] points = new SplinePoint[positions.Length];
        
        
        RaycastHit hit;
        
        for (int i = 0; i < points.Length; i++)
        {
            Vector3 hitPosition = Vector3.zero;
            Ray ray = new Ray(Camera.main.transform.position, positions[i] - Camera.main.transform.position);
            if (Physics.Raycast(ray, out hit))
            {
                hitPosition = hit.point;
            }

            points[i] = new SplinePoint();
            points[i].position = hitPosition + _offset;
            points[i].normal = Vector3.up;
            points[i].size = 1f;
            points[i].color = Color.white;
        }

        _transition.Transform(points);
    }
    
}
