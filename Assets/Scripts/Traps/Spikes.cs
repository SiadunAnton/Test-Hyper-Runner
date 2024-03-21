using UnityEngine;
using DG.Tweening;

public class Spikes : MonoBehaviour
{
    [SerializeField] private Transform _spike;
    [SerializeField] private float _offset;

    private void Start()
    {
        PingPongMovement();
    }

    private void PingPongMovement()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.AppendInterval(1f);
        sequence.Append(_spike.DOLocalMoveY(0, 1f)).SetEase(Ease.Linear);
        sequence.AppendInterval(1f);

        sequence.SetLoops(-1, LoopType.Yoyo);
    }
}
