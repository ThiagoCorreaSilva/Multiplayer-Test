using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    public GameObject player;
    public Transform spawnPoint;
    [SerializeField] private Color[] colors;
    [SerializeField] private string[] names;

    private void Start()
    {
        GameObject _localPlayer = PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);

        _localPlayer.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Length)];
        _localPlayer.GetComponentInChildren<Canvas>().GetComponentInChildren<TextMeshProUGUI>().text = names[Random.Range(0, names.Length)];
    }
}