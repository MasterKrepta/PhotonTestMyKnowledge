using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkMonitor : MonoBehaviourPunCallbacks
{
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        
        PhotonNetwork.DestroyPlayerObjects(otherPlayer);
  
    }

}
