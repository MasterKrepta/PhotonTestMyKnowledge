using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InstantiatePlayer : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject[] Models;

    // Start is called before the first frame update
    void Start()
    {
        if (!PhotonNetwork.IsConnected)  //FOR TESTING
        {
            int index = Random.Range(0, Models.Length);

            Instantiate(Models[index], transform.position, Quaternion.identity);
        }



        if (base.photonView.IsMine)
        {
            int index = Random.Range(0, Models.Length);

            PhotonNetwork.Instantiate(Path.Combine("Characters", $"{Models[index].name}"), transform.position, Quaternion.identity);
        }
    }

    
}
