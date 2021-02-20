using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarWorldSpaceController : MonoBehaviour
{
    public Transform playerCamera;

    void Start()
    {
        playerCamera = GameObject.Find("Player").transform;
        playerCamera = GameObject.Find("PlayerCamera").transform;  
    }




    // Update is called once per frame
    void LateUpdate()
    {
        // billboard the healthbar
        transform.LookAt(transform.position + playerCamera.forward);
    }
}
