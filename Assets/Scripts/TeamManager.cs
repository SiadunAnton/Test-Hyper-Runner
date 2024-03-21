using UnityEngine;
using System;
using Dreamteck.Splines;

public class TeamManager : MonoBehaviour
{
    public Action OnTeamDead;
    public Action<Vector3> OnCollectResource;
    public int Members => _members;
    public int Resouces => _resourcesAmount;

    [SerializeField] private Transform _teamHolder;
    [SerializeField] private GameObject _humanPrefab;
    [SerializeField] private ObjectController _controller;

    [SerializeField] private int _members = 0;
    [SerializeField] private int _resourcesAmount = 0;

    private void Start()
    {
        _members = _teamHolder.childCount;
    }

    public void Collect(Vector3 resourcePosition)
    {
        _resourcesAmount++;
        OnCollectResource?.Invoke(resourcePosition);
    }

    public void AddHuman(Vector3 position)
    {
        _controller.spawnCount++;
        _members++;
    }

    public void DeleteHuman(GameObject human)
    {
        Destroy(human);
        _members--;
        if (_members == 0)
            OnTeamDead?.Invoke();
    }
}

