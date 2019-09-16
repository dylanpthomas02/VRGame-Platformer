using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleCameraMove : MonoBehaviour
{
    public Transform[] camPositions;

    int index = 0;

    void Awake()
    {
        SetCamPositionAndRotation(0);
    }

    private void SetCamPositionAndRotation(int index)
    {
        transform.position = camPositions[index].position;
        transform.rotation = camPositions[index].rotation;
    }

    void Update()
    {
        if (index < camPositions.Length - 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                index++;
                SetCamPositionAndRotation(index);
            }
        }
        //else
        //{
        //    index = 0;
        //    SetCamPositionAndRotation(index);
        //}
    }
}
