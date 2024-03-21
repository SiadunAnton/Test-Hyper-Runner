using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHumanTrigger : MonoBehaviour
{
    [SerializeField] private TeamManager _teamManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("human"))
        {
            _teamManager.AddHuman(transform.position);
            Destroy(gameObject);
        }
    }
}
