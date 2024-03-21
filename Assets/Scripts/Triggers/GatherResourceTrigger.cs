using UnityEngine;

public class GatherResourceTrigger : MonoBehaviour
{
    [SerializeField] private TeamManager _teamManager;

    private bool _activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("human") && !_activated)
        {
            _activated = true;
            _teamManager.Collect(transform.position);
            Destroy(gameObject);
        }
    }
}
