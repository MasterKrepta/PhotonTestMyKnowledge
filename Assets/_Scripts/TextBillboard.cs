using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBillboard : MonoBehaviourPunCallbacks
{
    Camera targetCam, myCamera;
    
    Camera[] cams;
    // Start is called before the first frame update
    void Start()
    {
        cams = FindObjectsOfType<Camera>();
        if (base.photonView.IsMine)
        {
            myCamera = transform.parent.parent.GetComponentInChildren<Camera>();
            targetCam = myCamera;
        }
        else
        {
            targetCam = FindObjectOfType<Camera>();
            foreach (Camera c in cams)
            {
                if (!c == myCamera)
                {
                    targetCam = c;
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        this.transform.LookAt(targetCam.transform);
        transform.rotation = targetCam.transform.rotation;
    }
}
