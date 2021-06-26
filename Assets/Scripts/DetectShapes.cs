using UnityEngine;
using UnityEngine.UI;
public class DetectShapes : MonoBehaviour
{
    private float iniScaleX;
    public int sliderVal;
    public Slider slider;
    public float fillSpeed;
    private void Start()
    {
        iniScaleX = transform.localScale.x;
    }

    private void Update()
    {
        if (slider.value < sliderVal)
        {
            slider.value = sliderVal * fillSpeed * Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("AllyShape"))
        {
            IncShapeVol(other);
            Destroy(other.gameObject);
            sliderVal += 1;
        }
        else if(other.gameObject.CompareTag("EnemyShape"))
        {
            DecShapeVol(other);
            Destroy(other.gameObject);
            if(slider.value > 1) sliderVal = -1;
        }
    }

    // Increase the volume of the Player after collision with Ally Shape
    void IncShapeVol(Collider incShape)
    {
        transform.localScale = transform.localScale + 
            new Vector3(incShape.transform.localScale.x / 4, 0f, incShape.transform.localScale.z / 4);
    }

    // Decreases the volume of the Player after collision with Enemy Shape
    void DecShapeVol(Collider decShape)
    {
        if(iniScaleX != transform.localScale.x)
        {
            transform.localScale = transform.localScale -
                    new Vector3(decShape.transform.localScale.x / 4, 0f, decShape.transform.localScale.z / 4);
        }
        else
        {
            //Game Over OR Life Deduction
        }

    }
}
