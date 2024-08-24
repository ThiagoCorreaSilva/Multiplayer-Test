using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class PlayerServer : MonoBehaviourPunCallbacks
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
        view = GetComponent<PhotonView>();
    }

    private void Start()
    {
        canvas = transform.Find("Canvas");

        int _rng = Random.Range(0, names.Length);
        if (roomsController.nickname == "Random")
        {
            PhotonNetwork.NickName = names[_rng];

            canvas.GetComponentInChildren<TextMeshProUGUI>().text = photonView.Owner.NickName;
            canvas.GetComponentInChildren<TextMeshProUGUI>().color = colors[0];
        }
        else if (roomsController.nickname == "NotRandom")
        {
            canvas.GetComponentInChildren<TextMeshProUGUI>().text = photonView.Owner.NickName;
            canvas.GetComponentInChildren<TextMeshProUGUI>().color = colors[0];
        }
    }
}