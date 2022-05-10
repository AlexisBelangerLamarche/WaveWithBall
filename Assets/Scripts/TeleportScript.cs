using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{

    public GameObject teleportEnd;

    private void OnTriggerEnter(Collider other)
    {

        other.gameObject.transform.position = teleportEnd.transform.position;

    }

}
