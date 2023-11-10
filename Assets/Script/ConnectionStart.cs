using FishNet;
using FishNet.Transporting;
using FishNet.Transporting.Tugboat;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionStart : MonoBehaviour
{
    private Tugboat tugboat;

    private void OnEnable()
    {
        InstanceFinder.ClientManager.OnClientConnectionState += OnClientConnectionState;
    }

    private void OnDisable()
    {
        InstanceFinder.ClientManager.OnClientConnectionState -= OnClientConnectionState;

    }

    private void OnClientConnectionState(ClientConnectionStateArgs args)
    {
        if (args.ConnectionState == LocalConnectionState.Stopping)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }


    void Start()
    {
        if(TryGetComponent(out Tugboat _t))
        {
            tugboat = _t;
        }
        else
        {
            Debug.LogError("couldn't get tugboat", this);
            return;
        }

        tugboat.StartConnection(true);
        tugboat.StartConnection(false);
    }
}
