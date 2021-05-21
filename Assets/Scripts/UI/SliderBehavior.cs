using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBehavior : MonoBehaviour
{
    public GameObject wraith;
    public Slider slider;
    private int health;

    void Start()
    {
        health = wraith.GetComponent<WraithHealth>().health;
    }

    void Update()
    {
        health = wraith.GetComponent<WraithHealth>().health;
        SlideSlider();
    }

    private void SlideSlider()
    {
        slider.value = health;
    }
    
}
