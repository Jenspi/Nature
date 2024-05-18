using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// https://www.youtube.com/watch?v=BLfNP4Sc_iA -> How to make a health bar in unity
public class WaterBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setMaxWater(int max)
    {
        slider.maxValue = max;
    }

    public void SetWater(int water)
    {
        slider.value = water;
    }
}
