using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHumanTrigger : MonoBehaviour
{
    [SerializeField] private TeamManager _teamManager;

    private bool _activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("human") && !_activated)
        {
            _activated = true;
            _teamManager.AddHuman(transform.position);
            Destroy(gameObject);
        }
    }
}
