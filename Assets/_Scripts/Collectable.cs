using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] float value = 5;



    private void OnTriggerEnter(Collider other)
    {
        var playerObj = other.GetComponent<PlayerController>();
        if (playerObj != null)
        {
            DebugConsole.Instance.Log(  ($"{this.gameObject.name} has been picked up by {other.name}"));
            Destroy(this.gameObject);
        }
    }
}
