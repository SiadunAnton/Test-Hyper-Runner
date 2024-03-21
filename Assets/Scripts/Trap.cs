using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private TeamManager _teamManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("human"))
        {
            _teamManager.DeleteHuman(other.gameObject);
        }
    }
}
