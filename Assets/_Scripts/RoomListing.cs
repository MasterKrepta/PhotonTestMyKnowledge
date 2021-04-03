using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class RoomListing : MonoBehaviour
{

    RoomInfo _roomInfo;


    string _roomName = "ASSIGN NAME";
    TMP_Text btnText;

    public void ConfigureRoomListing(string roomName)
    {
        _roomName = roomName;

        btnText = GetComponentInChildren<TMP_Text>();
        btnText.text = _roomName;
    }

    public void OnClick_JoinRoom()
    {
        PhotonNetwork.JoinRoom(_roomName);
    }


  
  
}
