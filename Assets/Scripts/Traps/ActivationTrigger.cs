using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class ActivationTrigger : MonoBehaviour
{
    [SerializeField] private SplineFollower _follower;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("human"))
        {
            GetComponent<Collider>().enabled = false;
            _follower.follow = true;
        }
    }
}
