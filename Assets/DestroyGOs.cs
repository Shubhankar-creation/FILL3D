using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGOs : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {

            Debug.Log("Ground should be destroyed");
            Destroy(other.gameObject);
        }
    }
}
