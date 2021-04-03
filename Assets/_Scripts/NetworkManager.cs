using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject loadingScreen, roomMenu;
    string _mainRoom = "";

    private void Start()
    {

        PhotonNetwork.AutomaticallySyncScene = true;
        loadingScreen.SetActive(true);
        roomMenu.SetActive(false);
        PhotonNetwork.ConnectUsingSettings();
        
    }
    public override void OnConnectedToMaster()
    {
        loadingScreen.SetActive(false);
        roomMenu.SetActive(true);
        print("connected");
        if (_mainRoom == "")
        {
            var opt = new RoomOptions();
            opt.MaxPlayers = 2;
            PhotonNetwork.JoinOrCreateRoom("mainRoom", opt, TypedLobby.Default);
        }
        else
        {
            PhotonNetwork.JoinRoom(_mainRoom);
            print("Join room");
        }

    }

}
