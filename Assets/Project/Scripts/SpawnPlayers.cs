using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    public GameObject player;
    public Transform spawnPoint;

    private void Start()
    {
        GameObject _localPlayer = PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);
    }
}