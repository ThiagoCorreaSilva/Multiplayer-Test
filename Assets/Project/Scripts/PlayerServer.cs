using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class PlayerServer : MonoBehaviour
{
    [Header("Decorations")]
    [SerializeField] private Color[] colors;
    [SerializeField] private string[] names;

    private CreateAndJoinRooms roomsController;
    private Transform canvas;
    private PhotonView view;

    private void Awake()
    {
        roomsController = GameObject.FindGameObjectWithTag("RoomsController").GetComponent<CreateAndJoinRooms>();
    }

    private void Start()
    {
        view = GetComponent<PhotonView>();
        canvas = transform.Find("Canvas");

        int _rng = Random.Range(0, names.Length);

        if (roomsController.nickname == "Random")
            view.RPC(nameof(RandomName), RpcTarget.All, names[_rng]);
        else
            view.RPC(nameof(PlayerName), RpcTarget.All, roomsController.nickname);
    }

    [PunRPC]
    public void PlayerName(string _name)
    {
        canvas.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = _name;
        canvas.gameObject.GetComponentInChildren<TextMeshProUGUI>().color = colors[0];
    }

    [PunRPC]
    public void RandomName(string _name)
    {
        canvas.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = _name;
        canvas.gameObject.GetComponentInChildren<TextMeshProUGUI>().color = colors[0];
    }
}