using UnityEngine;

public class GatherResourceTrigger : MonoBehaviour
{
    [SerializeField] private TeamManager _teamManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("human"))
        {
            _teamManager.Collect(transform.position);
            Destroy(gameObject);
        }
    }
}
