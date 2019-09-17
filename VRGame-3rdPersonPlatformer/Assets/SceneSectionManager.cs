using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSectionManager : MonoBehaviour
{
    public static SceneSectionManager instance = null;

    public GameObject cam;
    public Transform[] camPositions;
    int index = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        index = 0;
        SetCamPosandRot();
    }

    private void Update()
    {
        Debug.Log("Position: " + cam.transform.position);
        Debug.Log("Rotation: " + cam.transform.rotation);
    }

    private void SetCamPosandRot()
    {
        cam.transform.position = camPositions[index].transform.position;
        cam.transform.rotation = camPositions[index].transform.rotation;
    }

    public void ForwardSection()
    {
        index++;
        SetCamPosandRot();
    }

    public void BackSection()
    {
        index--;
        SetCamPosandRot();
    }
}
