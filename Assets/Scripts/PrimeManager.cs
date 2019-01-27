﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrimeManager : MonoBehaviour
{
    [Header("References")]
    public Slider happinessSlider;
    public Slider fuelSlider;
    public Slider homeSlider;
    public GameObject popupHappiness;
    public GameObject popupFuel;

    [Header("Values")]
    public float happinessScore;
    public float fuelScore;
    public float homeScore;

    public bool isSailing;
    public bool isFueling;

    public float sailingTimer;
    public float refuelingTimer;
    private float time;
    private float animationLength;
    

    // Start is called before the first frame update
    void Start()
    {
        happinessScore = 10f;
        fuelScore = 500f;
        homeScore = 0f;

        happinessSlider.value = happinessScore;
        fuelSlider.value = fuelScore;
        homeSlider.value = homeScore;

        isSailing = true;
        sailingTimer = 5f;
        refuelingTimer = 2f;

        animationLength = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if(isSailing)
        {
            time += Time.deltaTime;

            if(time >= sailingTimer && happinessScore < 70f)
            {
                AdjustHappiness(5f);
                time = 0f;

            }
        }

        else if(!isSailing)
        {
            time += Time.deltaTime;

            if(time >= refuelingTimer)
            {
                if(happinessScore > 0)
                {
                    AdjustHappiness(-2f);
                }
                if(fuelScore < 500)
                {
                    AdjustFuel(20f);
                }
                
                time = 0f;
            }
        }
        
    }

    public void AdjustFuel(float fuelAdjustment)
    {
        fuelScore += fuelAdjustment;
        fuelSlider.value = fuelScore;
        popupFuel.SetActive(true);
        popupFuel.GetComponentInChildren<Text>().text = Mathf.RoundToInt(fuelAdjustment) + " Fuel";
        Invoke("DeactivatePopupFuel", animationLength);
    }

    public void AdjustHappiness(float happinessAdjustment)
    {
        happinessScore += happinessAdjustment;
        happinessSlider.value = happinessScore;
        popupHappiness.SetActive(true);
        popupHappiness.GetComponentInChildren<Text>().text = happinessAdjustment + " Happiness";
        Invoke("DeactivatePopupHappiness", animationLength);
    }

    public void AdjustHome(float homeAdjustment)
    {
        homeScore += homeAdjustment;
        homeSlider.value = homeScore;
    }

    void DeactivatePopupHappiness()
    {
        popupHappiness.SetActive(false);
    }

    void DeactivatePopupFuel()
    {
        
        popupFuel.SetActive(false);
    }
}
