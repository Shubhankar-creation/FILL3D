using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
    public GameObject prefabShape;
    public GameObject shapeParent;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Fshape"))
        {
            GameObject shapeInstance = Instantiate(prefabShape, new Vector3(shapeParent.transform.position.x, shapeParent.transform.position.y, shapeParent.transform.position.z + 40), Quaternion.identity) as GameObject;
            shapeInstance.transform.parent = shapeParent.transform;
        }
        else if (other.gameObject.CompareTag("Bshape"))
        {
            GameObject shapeInstance = Instantiate(prefabShape, new Vector3(shapeParent.transform.position.x, shapeParent.transform.position.y, shapeParent.transform.position.z - 40), Quaternion.identity) as GameObject;
            shapeInstance.transform.parent = shapeParent.transform;
        }
        else if (other.gameObject.CompareTag("Lshape"))
        {
            GameObject shapeInstance = Instantiate(prefabShape, new Vector3(shapeParent.transform.position.x - 20, shapeParent.transform.position.y, shapeParent.transform.position.z), Quaternion.identity) as GameObject;
            shapeInstance.transform.parent = shapeParent.transform;
        }
        else if (other.gameObject.CompareTag("Rshape"))
        {
            GameObject shapeInstance = Instantiate(prefabShape, new Vector3(shapeParent.transform.position.x + 20, shapeParent.transform.position.y, shapeParent.transform.position.z), Quaternion.identity) as GameObject;
            shapeInstance.transform.parent = shapeParent.transform;
        }
    }
}
