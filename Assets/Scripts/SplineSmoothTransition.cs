using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class SplineSmoothTransition : MonoBehaviour
{

    [SerializeField] private ObjectController _controller;

    [SerializeField] private float _transitionDeltaTime = 1f;
    [SerializeField] private int _smoothness = 3;

    [SerializeField] private SplineComputer _spline;

    public void Transform(SplinePoint[] points)
    {
        StopAllCoroutines();
        StartCoroutine(AdaptNewPointsToSpline(points));
    }

    IEnumerator AdaptNewPointsToSpline(SplinePoint[] newPoints)
    {
        SplinePoint[] oldPoints = _spline.GetPoints();
        _controller.autoUpdate = true;
        for (int i = 0; i < _smoothness; i++)
        {

            SetPoints(LerpSplinePoints(oldPoints,newPoints, (float)i/_smoothness));
            yield return new WaitForSeconds(_transitionDeltaTime);
        }
        _controller.autoUpdate = false;
    }

    private SplinePoint[] LerpSplinePoints(SplinePoint[] points1, SplinePoint[] points2, float t)
    {
        int differenceInLength = points1.Length - points2.Length;
        if (differenceInLength > 0)
        {
            points2 = AddIntermediateSplinePoints(points2, Mathf.Abs(differenceInLength));
        }
        else if(differenceInLength < 0)
        {
            points1 = AddIntermediateSplinePoints(points1, Mathf.Abs(differenceInLength));
        }

        SplinePoint[] result = new SplinePoint[points1.Length];

        for(int i = 0; i < result.Length; i ++)
        {
            result[i].position = Vector3.Lerp(points1[i].position, points2[i].position,t);
        }
        return result;
    }

    private void SetPoints(SplinePoint[] points)
    {
        _spline.SetPoints(points);
    }

    private SplinePoint[] AddIntermediateSplinePoints(SplinePoint[] points,int count)
    {
        List<SplinePoint> splineList = new List<SplinePoint>(points);

        if(points.Length == 1)
        {
            for (int i = 0; i < count; i++)
            {
                SplinePoint point = new SplinePoint();
                point.position = points[0].position;
                point.normal = Vector3.up;
                point.size = 1f;
                point.color = Color.white;

                splineList.Add(point);
            }
            return splineList.ToArray();
        }
        else
        {
            int indexOfCenter = points.Length / 2;

            Vector3 positionOfCreatedPoint = Vector3.Lerp(points[indexOfCenter].position,
                                                          points[indexOfCenter - 1].position,
                                                          0.5f);

            for (int i = 0; i < count; i++)
            {
                SplinePoint point = new SplinePoint();
                point.position = positionOfCreatedPoint;
                point.normal = Vector3.up;
                point.size = 1f;
                point.color = Color.white;

                splineList.Insert(indexOfCenter + 1, point);
            }

            return splineList.ToArray();
        }

    }
}
