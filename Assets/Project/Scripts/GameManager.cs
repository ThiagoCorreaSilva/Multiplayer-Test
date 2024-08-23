using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text roomId;
    [SerializeField] private TMP_Text ping;
    
    private void Start()
    {
        roomId.text = "RoomID: " + PhotonNetwork.CurrentRoom.Name;
    }

    private void LateUpdate()
    {
        ping.text = "Ping: " + PhotonNetwork.GetPing();
    }
}