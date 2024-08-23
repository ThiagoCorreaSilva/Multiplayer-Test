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

    private Transform canvas;
    private PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        canvas = transform.Find("Canvas");

        int _rng = Random.Range(0, names.Length);

        view.RPC(nameof(ActiveCanvas), RpcTarget.All, names[_rng]);
    }

    [PunRPC]
    public void ActiveCanvas(string _name)
    {
        canvas.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = _name;
        canvas.gameObject.GetComponentInChildren<TextMeshProUGUI>().color = colors[0];
    }
}