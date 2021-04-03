using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

using System.IO;
using TMPro;

public class PlayerController : MonoBehaviourPunCallacks
{ 
    [SerializeField] GameObject[] Models;
    string[] modelNames;
    [SerializeField] float speed = 5;
    [SerializeField] float turnSpeed = 40f;
    [SerializeField] string[] names;
    Vector3 MoveDir;
    

    CharacterController cc;
    Camera playerCam;
    TMP_Text nameLbl;
    Animator Anim;


    // Start is called before the first frame update
    void Start()
    {
        playerCam = GetComponentInChildren<Camera>();
        nameLbl = GetComponentInChildren<TMP_Text>();
        cc = GetComponent<CharacterController>();
 

        if (PhotonNetwork.IsConnected)
        {
            if (base.photonView.IsMine)
            {
                PhotonNetwork.NickName = GetRandomName();
                nameLbl.text = PhotonNetwork.NickName;
                this.gameObject.name = nameLbl.text;
                Anim = GetComponent<Animator>();
                photonView.ObservedComponents.Add(GetComponent<PhotonAnimatorView>());
            }
            else
            {
                nameLbl.text = base.photonView.Owner.NickName;
                this.gameObject.name = nameLbl.text;
                playerCam.enabled = false;
            }
        }
        else
        {
            //!Testing
            nameLbl.text = "Test Player";
            this.gameObject.name = nameLbl.text;
            Anim = GetComponent<Animator>();
        }
    }


    private string GetRandomName()
    {
        
        int rndName = Random.Range(0, names.Length);
        return names[rndName];
    }

    private void Update()
    {
        if (PhotonNetwork.IsConnected == false) //! FOR TESTING
        {
            MoveMementCode();
        }


        if (base.photonView.IsMine)
        {
            MoveMementCode();
        }
    }

    private void MoveMementCode()
    {
        GetInput();

        cc.Move(MoveDir * speed * Time.deltaTime);


        ToggleAnimation(MoveDir);

        Rotate(MoveDir);
    }

    private void Rotate(Vector3 moveInput)
    {
        if (moveInput != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveInput), Time.deltaTime * turnSpeed);
        }
    }

    private void GetInput()
    {
        MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        MoveDir = transform.TransformDirection(MoveDir);
        
    }

    private void ToggleAnimation(Vector3 moveAmount)
    {
        if (MoveDir != Vector3.zero)
        {
            Anim.SetBool("Moving", true);
        }
        else
        {
            Anim.SetBool("Moving", false);
        }
    }

}
