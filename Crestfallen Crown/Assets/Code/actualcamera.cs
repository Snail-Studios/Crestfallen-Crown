using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class actualcamera : MonoBehaviour
{
    public CinemachineVirtualCamera CVC;

    void Start()
    {
        CVC.Follow = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
