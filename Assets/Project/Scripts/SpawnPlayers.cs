using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    public GameObject player;
    public Transform spawnPoint;

    private void Start()
    {
        PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);
    }

    public override void OnDisconnected(DisconnectCause _cause)
    {
        base.OnDisconnected(_cause);

        Debug.LogWarningFormat("O jogador saiu devido: " + _cause);
    }
}