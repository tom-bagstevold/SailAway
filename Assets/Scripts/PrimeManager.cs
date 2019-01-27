using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrimeManager : MonoBehaviour
{
    [Header("References")]
    public GameObject player;
    public Transform endTarget;
    public GameObject endScreen;
    public GameObject restartPanel;
    public Slider happinessSlider;
    public Slider fuelSlider;
    public Slider homeSlider;
    public GameObject popupHappiness;
    public GameObject popupFuel;
    public GameObject popupHome;
    public GameObject popupToFuel;
    public GameObject popupToHome;
    public GameObject FinalArea;
    public GameObject colliderTop;
    public GameObject colliderRight;

    [Header("Values")]
    public float happinessScore;
    public float fuelScore;
    public float homeScore;
    public float homesVisited;

    public bool isSailing;
    public bool isFueling;
    public bool isHoming;
    public bool inFinalArea;

    public float sailingTimer;
    public float refuelingTimer;
    public float homeTimer;
    public float finalAreaTimer;
    public float homeLeaveTime;
    private float leaveCounter;
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
        homeTimer = 3f;
        homeLeaveTime =3f;
        finalAreaTimer = 3f;
        

        animationLength = 2f;
        popupToFuelText = popupToFuel.GetComponentInChildren<Text>();
        popupToHomeText = popupToHome.GetComponentInChildren<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(fuelScore <= 0)
        {
            isSailing = false;
            restartPanel.SetActive(true);
            player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(0);
            }
        }


        if(isSailing)
        {
            leaveCounter = 0f;
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

            if (leaveCounter < homeLeaveTime)
            {
                popupToHome.SetActive(false);
                
            }
            else if (leaveCounter >= homeLeaveTime)
            {
                popupToHome.SetActive(true);
                //leaveCounter = 0;

            }

            if (time >= homeTimer)
            {
                if (happinessScore > 0)
                {
                    AdjustHappiness(-2f);
                }

                time = 0f;
                leaveCounter += 1;
            }
        }

        //Final Endgame Code

        if(homesVisited == 3)
        {
            Debug.Log("Visited All Homes!");
            FinalArea.SetActive(true);
        }

        if(inFinalArea)
        {
            SetFuel(500f);
            colliderRight.SetActive(false);
            colliderTop.SetActive(false);
            player.GetComponent<Rigidbody2D>().AddForce((transform.up * 1f));

            time += Time.deltaTime;

            if(time >= finalAreaTimer)
            {
                AdjustHappiness(10);
                AdjustHome(10);
                time = 0f;
            }

            if(homeScore >= 60)
            {
                isSailing = false;

                endScreen.SetActive(true);
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

    void SetFuel(float fuelAdjustment)
    {
        fuelScore = fuelAdjustment;
        fuelSlider.value = fuelScore;
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
        popupHome.SetActive(true);
        popupHome.GetComponentInChildren<Text>().text = homeAdjustment + " Home";
        Invoke("DeactivatePopupHome", animationLength);
    }

    void DeactivatePopupHappiness()
    {
        popupHappiness.SetActive(false);
    }

    void DeactivatePopupFuel()
    {
        
        popupFuel.SetActive(false);
    }

    void DeactivatePopupHome()
    {

        popupHome.SetActive(false);
    }
}
