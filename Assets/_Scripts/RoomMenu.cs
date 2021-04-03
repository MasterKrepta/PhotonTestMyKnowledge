using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class RoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField roomName;
    [SerializeField] Button roomBtn;
    [SerializeField] GameObject RoomListings, waitingText;
    [SerializeField] RoomListing roomListingPrefab;
    [SerializeField] Button StartButton;

    private void Update()
    {
        
        roomBtn.interactable = ToggleCreateBtn();
        StartButton.interactable = ToggleStartButton();

        if (PhotonNetwork.IsMasterClient)
        {
            waitingText.GetComponent<TMP_Text>().text = "Waiting For Second Player";
            waitingText.SetActive(!ToggleStartButton());
        }
        else
        {
            waitingText.GetComponent<TMP_Text>().text = "Waiting for Host to start game.";
            waitingText.SetActive(true);
        }

        
    }

    private bool ToggleCreateBtn()
    {
        return !String.IsNullOrEmpty(roomName.text) && !PhotonNetwork.IsMasterClient;
    }

    bool ToggleStartButton()
    {
        return PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount == 2; //TODO change back after testing
    }

    public void OnClick_CreateRoom()
    {

        RoomOptions opt = new RoomOptions();
        opt.MaxPlayers = 4;
        
        PhotonNetwork.CreateRoom(roomName.text, opt, TypedLobby.Default);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (Transform transform in RoomListings.transform)
        {
            Destroy(transform.gameObject);
        }

        for (int i = 0; i < roomList.Count; i++)
        {
            Instantiate(roomListingPrefab, RoomListings.transform).GetComponent<RoomListing>()/*.Setup(roomList[i])*/;
        }
    }

    public override void OnCreatedRoom()
    {
        roomName.text = "";
        GameObject obj = PhotonNetwork.Instantiate(roomListingPrefab.name, RoomListings.transform.position, Quaternion.identity);
        obj.transform.parent = RoomListings.transform;
        obj.GetComponent<RoomListing>().ConfigureRoomListing(PhotonNetwork.CurrentRoom.Name);
    }
    

    public void OnClick_StartGame()
    {
            PhotonNetwork.LoadLevel("Room1");
    }
}
