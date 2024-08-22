using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    [Header("Buttons and InputField")]
    public TMP_InputField createInput;
    public Button createButton;
    public TMP_InputField joinInput;
    public Button joinButton;

    [Header("Lobby Variables")]
    [SerializeField] private TMP_Text availableRooms;
    [SerializeField] private int roomsCount;
    [SerializeField] private bool haveRoom;

    private void Start()
    {
        createButton.onClick.AddListener(CreateRoom);
        joinButton.onClick.AddListener(JoinRoom);

        UpdateRoomsText();
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
        UpdateRoomsText();
    }

    public void JoinRoom()
    {
        if (!haveRoom)
        {
            Debug.Log("Sala criada devido a falta de salas");
            PhotonNetwork.CreateRoom(null, new RoomOptions());

            UpdateRoomsText();
        }

        else if (string.IsNullOrWhiteSpace(joinInput.text))
        {
            Debug.Log("Achando uma sala aleatoria");
            PhotonNetwork.JoinRandomRoom();
        }

        else
            PhotonNetwork.JoinRoom(joinInput.text);
    }

    private void UpdateRoomsText()
    {
        availableRooms.text = "Rooms: " + roomsCount.ToString();
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnRoomListUpdate(List<RoomInfo> _roomList)
    {
        base.OnRoomListUpdate(_roomList);

        roomsCount = _roomList.Count;

        if (_roomList.Count > 0)
            haveRoom = true;
        else haveRoom = false;
    }
}