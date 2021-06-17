using UnityEngine;

public class DetectShapes : MonoBehaviour
{
    private float iniScaleX;

    private void Start()
    {
        iniScaleX = transform.localScale.x;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("AllyShape"))
        {
            IncShapeVol(other);
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("EnemyShape"))
        {
            DecShapeVol(other);
            Destroy(other.gameObject);
        }
    }

    // Increase the volume of the Player after collision with Ally Shape
    void IncShapeVol(Collider incShape)
    {
        transform.localScale = transform.localScale + 
            new Vector3(incShape.transform.localScale.x, 0f, incShape.transform.localScale.z);
    }

    // Decreases the volume of the Player after collision with Enemy Shape
    void DecShapeVol(Collider decShape)
    {
        if(iniScaleX != transform.localScale.x)
        {
            transform.localScale = transform.localScale -
                    new Vector3(decShape.transform.localScale.x, 0f, decShape.transform.localScale.z);
        }
        else
        {
            //Game Over OR Life Deduction
        }

    }
}
