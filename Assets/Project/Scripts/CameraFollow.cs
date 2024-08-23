using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private float lerpTime;

    private void Update()
    {
        if (!playerPos)
            playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        Vector3 _newPosa = new Vector3(playerPos.position.x, playerPos.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, _newPosa, lerpTime);
    }
}