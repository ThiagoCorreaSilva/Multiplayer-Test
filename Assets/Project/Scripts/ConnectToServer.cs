using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        PhotonNetwork.ConnectToRegion(PhotonNetwork.CloudRegion);
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        PhotonNetwork.JoinLobby();
        Debug.Log("Conectado ao Master Server");
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();

        SceneManager.LoadScene("Lobby");
    }
}