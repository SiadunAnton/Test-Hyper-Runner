using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Press : MonoBehaviour
{
    [SerializeField] private Transform _press;
    [SerializeField] private float _offset;

    private void Start()
    {
        PingPongMovement();
    }

    private void PingPongMovement()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.AppendInterval(1f);
        sequence.Append(_press.DOLocalMoveX(transform.localPosition.x + _offset, 1f)).SetEase(Ease.Linear);

        sequence.SetLoops(-1, LoopType.Yoyo);
    }
}
