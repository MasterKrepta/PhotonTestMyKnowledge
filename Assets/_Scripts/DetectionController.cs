using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionController : MonoBehaviour
{
    [SerializeField] float DetectionRange = 10;
    [SerializeField] float coneRadius = 0.5f;
    [SerializeField] float DetectTime = 1.5f;
    [SerializeField] GameObject detectionSphere;
    [SerializeField] Vector3 detectionLoc;

    SphereCollider childSphere;
    // Start is called before the first frame update
    void Start()
    {
        detectionSphere.transform.position = detectionLoc;
        childSphere = detectionSphere.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(transform.position + Vector3.up, transform.forward * DetectionRange, Color.green);
        //Debug.DrawRay(transform.position + Vector3.up, (transform.forward + transform.right * coneRadius).normalized * DetectionRange, Color.green);
        //Debug.DrawRay(transform.position + Vector3.up, (transform.forward - transform.right * coneRadius).normalized * DetectionRange, Color.green);

        //Ray fwd = new Ray(transform.position + Vector3.up, transform.forward * DetectionRange);
        //Ray rgt = new Ray(transform.position + Vector3.up, (transform.forward + transform.right * coneRadius).normalized * DetectionRange);
        //Ray lft = new Ray(transform.position + Vector3.up, (transform.forward - transform.right * coneRadius).normalized * DetectionRange);

        //CheckForHit(fwd);
        //CheckForHit(rgt);
        //CheckForHit(lft);

    }

    private void OnTriggerEnter(Collider other)
    {
        var target = other.GetComponent<DetectionTarget>();
        if (target != null)
        {
            DebugConsole.Instance.Log(other.name + " seen by " + this.gameObject.name);
            //Debug.Log(hit.collider.name);
        }
    }

    //private void CheckForHit(Ray incomingRay)
    //{
    //    RaycastHit hit;
    //    if (Physics.Raycast(incomingRay, out hit, DetectionRange))
    //    {
    //        var target = hit.collider.GetComponent<DetectionTarget>();
    //        if (target != null)
    //        {
    //            DebugConsole.Instance.Log(hit.collider.name + " seen by " + this.gameObject.name);
    //            //Debug.Log(hit.collider.name);
    //        }
            
    //    }
    //}
}
