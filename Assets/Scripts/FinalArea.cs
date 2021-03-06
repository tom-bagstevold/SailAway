﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalArea : MonoBehaviour
{
    public PrimeManager manager;
    public GameObject front;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<PrimeManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        manager.inFinalArea = true;
        front.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        manager.inFinalArea = false;
    }
}
