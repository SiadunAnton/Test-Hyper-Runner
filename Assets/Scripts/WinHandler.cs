using UnityEngine;
using System;

public class WinHandler : MonoBehaviour
{
    public Action OnCompleteLevel;

    [SerializeField] private Move _environment;
    [SerializeField] private TeamManager _manager;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;

    [SerializeField] private Transform _teamHolder;

    private void Start()
    {
        OnCompleteLevel += () => _winPanel.SetActive(true);
        _manager.OnTeamDead += Lose;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("human"))
        {
            OnCompleteLevel?.Invoke();
            _environment.Stop();

            Animator[] animators = _teamHolder.GetComponentsInChildren<Animator>();

            foreach (var animator in animators)
                animator.SetTrigger("Victory");

            enabled = false;
        }
    }

    private void Lose()
    {
        _environment.Stop();
        _losePanel.SetActive(true);
    }
}
