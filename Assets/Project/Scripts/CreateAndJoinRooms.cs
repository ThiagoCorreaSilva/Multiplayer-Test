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
    [SerializeField] private int gameVersion;
    [SerializeField] private TMP_InputField nicknameInput;
    [SerializeField] private Button confirmNickname;
    public string nickname;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        nickname = "Random";
    }

    private void Start()
    {
        createButton.onClick.AddListener(CreateRoom);
        joinButton.onClick.AddListener(JoinRoom);
        confirmNickname.onClick.AddListener(ConfirmNickname);

        availableRooms.text = "Available Rooms: " + roomsCount.ToString();
    }

    #region RoomsController
    public override void OnRoomListUpdate(List<RoomInfo> _roomList)
    {
        base.OnRoomListUpdate(_roomList);

        roomsCount = _roomList.Count;
        availableRooms.text = "Available Rooms: " + roomsCount.ToString();
    }

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(createInput.text))
        {
            Debug.Log("Sala criada devido a falta de um ID");
            PhotonNetwork.CreateRoom(Random.Range(0, 1000).ToString(), new RoomOptions());
        }

        else
            PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom()
    {
        if (roomsCount == 0)
        {
            Debug.Log("Sala criada devido a falta de salas");
            PhotonNetwork.CreateRoom(Random.Range(0, 1000).ToString(), new RoomOptions());
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
        Debug.Log(PhotonNetwork.CurrentRoom.Name);
    }

    #endregion

    private void ConfirmNickname()
    {
        nickname = nicknameInput.text;
    }
}