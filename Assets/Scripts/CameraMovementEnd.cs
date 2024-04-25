using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementEnd : MonoBehaviour
{
    private Transform EndScenePoint;
    public Vector3 Offset = new Vector3(0, 0, -10);
    void Start()
    {
        EndScenePoint = GameObject.FindWithTag("EndScene").transform;
        transform.position = new Vector3(EndScenePoint.position.x + Offset.x, Offset.y, Offset.z);
    }

}
