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

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        createButton.onClick.AddListener(CreateRoom);
        joinButton.onClick.AddListener(JoinRoom);
    }

    public override void OnRoomListUpdate(List<RoomInfo> _roomList)
    {
        base.OnRoomListUpdate(_roomList);

        roomsCount = _roomList.Count;
        availableRooms.text = "Rooms: " + roomsCount.ToString();

        if (_roomList.Count > 0)
            haveRoom = true;
        else haveRoom = false;
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom()
    {
        if (!haveRoom)
        {
            Debug.Log("Sala criada devido a falta de salas");
            PhotonNetwork.CreateRoom(null, new RoomOptions());
        }

        else if (string.IsNullOrWhiteSpace(joinInput.text))
        {
            Debug.Log("Achando uma sala aleatoria");
            PhotonNetwork.JoinRandomRoom();
        }

        else
            PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        PhotonNetwork.LoadLevel("Game");
    }
}