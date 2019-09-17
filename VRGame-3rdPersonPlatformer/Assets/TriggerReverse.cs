using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerReverse : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneSectionManager.instance.BackSection();
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            gameObject.GetComponentInParent<BoxCollider>().enabled = true;
        }
    }
}
