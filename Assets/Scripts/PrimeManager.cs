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
    public GameObject popupHappiness;
    public GameObject popupFuel;
    public GameObject popupToFuel;
    public GameObject popupToHome;

    [Header("Values")]
    public float happinessScore;
    public float fuelScore;
    public float homeScore;

    public bool isSailing;
    public bool isFueling;
    public bool isHoming;

    public float sailingTimer;
    public float refuelingTimer;
    public float homeTimer;
    private float time;
    private float animationLength;
    private Text popupToFuelText;
    private Text popupToHomeText;

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
        homeTimer = 4f;

        animationLength = 2f;
        popupToFuelText = popupToFuel.GetComponentInChildren<Text>();
        popupToHomeText = popupToHome.GetComponentInChildren<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if(isSailing)
        {
            popupToFuelText.text = "Press E to Fuel";
            popupToHomeText.text = "Press E To Find Home";
            time += Time.deltaTime;

            if(time >= sailingTimer && happinessScore < 70f)
            {
                AdjustHappiness(5f);
                time = 0f;

            }
        }

        else if(!isSailing && isFueling)
        {
            time += Time.deltaTime;
            popupToFuelText.text = "Press E to Leave";

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

        else if(!isSailing && isHoming)
        {
            time += Time.deltaTime;
            popupToHomeText.text = "Press E to Leave";

            if(time >= homeTimer)
            {
                if (happinessScore > 0)
                {
                    AdjustHappiness(-2f);
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
