using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarWorldSpaceController : MonoBehaviour
{
    public Transform playerCamera;
   
    // Update is called once per frame
    void LateUpdate()
    {
        // billboard the healthbar
        transform.LookAt(transform.position + playerCamera.forward);
    }
}
