using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeSliderBehavior : MonoBehaviour
{
    public GameObject home;
    public Slider slider;
    private int health;

    void Start()
    {
        health = home.GetComponent<HomeTrigger>().homeHealth;
    }

    void Update()
    {
        health = home.GetComponent<HomeTrigger>().homeHealth;
        SlideSlider();
    }

    private void SlideSlider()
    {
        slider.value = health;
    }
}
