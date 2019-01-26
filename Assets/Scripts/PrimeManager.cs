using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrimeManager : MonoBehaviour
{
    [Header("References")]
    public Slider happinessSlider;
    public Slider fuelSlider;
    public Slider homeSlider;

    [Header("Values")]
    public float happinessScore;
    public float fuelScore;
    public float homeScore;

    public bool isSailing;

    // Start is called before the first frame update
    void Start()
    {
        happinessScore = 10f;
        fuelScore = 100f;
        homeScore = 0f;

        happinessSlider.value = happinessScore;
        fuelSlider.value = fuelScore;
        homeSlider.value = homeScore;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdjustFuel(float fuelAdjustment)
    {
        fuelScore += fuelAdjustment;
        fuelSlider.value = fuelScore;
    }

    public void AdjustHappiness(float happinessAdjustment)
    {
        happinessScore += happinessAdjustment;
        happinessSlider.value = happinessScore;
    }

    public void AdjustHome(float homeAdjustment)
    {
        homeScore += homeAdjustment;
        homeSlider.value = homeScore;
    }
}
