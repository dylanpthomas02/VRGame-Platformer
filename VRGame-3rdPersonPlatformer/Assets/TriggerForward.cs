using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForward : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("exit");
        if (other.gameObject.CompareTag("Player"))
        {
            SceneSectionManager.instance.ForwardSection();
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponentInChildren<BoxCollider>().enabled = true;
        }
    }
}
