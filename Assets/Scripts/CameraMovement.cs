using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Player;
    public Vector3 Offset = new Vector3(0, 1 , -10);

    private void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        transform.position = new Vector3(Player.position.x + Offset.x, Player.position.y + Offset.y, Offset.z);
    }
}
