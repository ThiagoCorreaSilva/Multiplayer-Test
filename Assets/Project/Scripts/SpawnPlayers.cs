using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject player;
    public Transform spawnPoint;

    private void Start()
    {
        PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);
    }
}