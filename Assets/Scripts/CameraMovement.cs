using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector3 Offset = new Vector3(0, 0 , -10);

    private Transform Player;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        if (Player == null)
            return;

        transform.position = new Vector3(Player.position.x + Offset.x, Offset.y, Offset.z);
    }
}
