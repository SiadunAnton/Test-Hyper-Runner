using UnityEngine;
using System;

public class TeamManager : MonoBehaviour
{
    public Action OnTeamDead;
    public int Members => _members;

    [SerializeField] private Transform _teamHolder;
    [SerializeField] private GameObject _humanPrefab;

    private int _members = 0;

    private void Start()
    {
        _members = _teamHolder.childCount;
    }


    public void AddHuman(Vector3 position)
    {
        Instantiate(_humanPrefab, position, Quaternion.identity, _teamHolder);
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
