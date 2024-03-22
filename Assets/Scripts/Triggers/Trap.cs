using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private TeamManager _teamManager;
    [SerializeField] private GameObject _vfx;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("human"))
        {
            _teamManager.DeleteHuman(other.gameObject);
            if (_vfx != null)
                Instantiate(_vfx, transform);
        }
    }
}
