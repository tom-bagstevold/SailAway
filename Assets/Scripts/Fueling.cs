using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fueling : MonoBehaviour
{
    public PrimeManager manager;
    public float fuelPerSecond;
    public float happinessPerSecond;
    public bool isDocked;
    public bool canDock;

    public Transform parkingSpot;

    private GameObject collidingObj;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<PrimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canDock)
        {
            if (Input.GetKeyDown(KeyCode.E) && !isDocked)
            {
                isDocked = true;
                collidingObj.transform.position = parkingSpot.position;
                collidingObj.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                isDocked = true;
                manager.isSailing = false;
                manager.isFueling = true;
            }
            else if (Input.GetKeyDown(KeyCode.E) && isDocked)
            {
                manager.isSailing = true;
                isDocked = false;
                manager.isFueling = false;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        manager.popupToFuel.SetActive(true);

        canDock = true;

        collidingObj = collision.gameObject;

        Debug.Log(collision.name);

       

        if (collision.name == "Player")
        {
            
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        manager.popupToFuel.SetActive(false);
        canDock = false;

    }
}
