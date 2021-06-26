using UnityEngine;
using UnityEngine.UI;
public class DetectShapes : MonoBehaviour
{
    private float iniScaleX;
    public float sliderVal;
    public Slider slider;
    public Text text;
    public float fillSpeed;
    private int score = 1;
    private void Start()
    {
        iniScaleX = transform.localScale.x;
        text.text = "Level " + score.ToString();
    }
    private void Update()
    {
        slider.value = sliderVal;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("AllyShape"))
        {
            IncShapeVol(other);
            Destroy(other.gameObject);
            sliderVal = slider.value + 1;
            if (slider.value == 20)
            {
                score++;
                sliderVal = 0;
                text.text = "Level " + score.ToString();
            }
        }
        else if(other.gameObject.CompareTag("EnemyShape"))
        {
            DecShapeVol(other);
            Destroy(other.gameObject);
            if(slider.value > 1) sliderVal = slider.value - 1;
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
