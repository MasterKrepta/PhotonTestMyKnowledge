using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    
    [SerializeField] GameObject PlayerPrefab;
    public float minX, minZ, maxX, maxZ;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 randPos = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));

        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Instantiate(PlayerPrefab.name, randPos, Quaternion.identity);
        }
        
    }
}
