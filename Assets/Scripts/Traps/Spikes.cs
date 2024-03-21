using UnityEngine;
using DG.Tweening;

public class Spikes : MonoBehaviour
{
    [SerializeField] private Transform _spike;
    [SerializeField] private float _offset;

    private Vector3 _start;
    private Vector3 _end;

    private void Start()
    {
        PingPongMovement();
    }

    private void PingPongMovement()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.AppendInterval(1f);
        sequence.Append(_spike.DOLocalMoveY(-_offset, 1f)).SetEase(Ease.Linear);
        sequence.Append(_spike.DOLocalMoveY(-_offset, 1f)).SetEase(Ease.Linear);

        sequence.SetLoops(-1, LoopType.Yoyo);
    }
}
