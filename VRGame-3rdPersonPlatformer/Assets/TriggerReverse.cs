using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerReverse : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneSectionManager.instance.BackSection();
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponentInParent<BoxCollider>().enabled = true;
        }
    }
}
