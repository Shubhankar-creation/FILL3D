using UnityEngine;

public class DestroyGOs : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mesh3D"))
        {

        }
        else if (other.gameObject.CompareTag("AllyShape") || other.gameObject.CompareTag("EnemyShape"))
        {

        }
        else
        {
            Destroy(other.gameObject.transform.parent.gameObject);
        }
    }
}
