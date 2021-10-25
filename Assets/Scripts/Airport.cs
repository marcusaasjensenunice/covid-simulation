using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airport : MonoBehaviour
{
    public int airportVirusState;
    public bool hasVirusCases;
    public bool isBlocked;

    public List<Airplane> airplanes;

    void Start()
    {
        airportVirusState = 0; //safe airport
    }
    void Update()
    {
        foreach(Airplane airplane in airplanes)
        {
            if(airplane.hasVirus)
            {
                if(airplane.currentAirport == this)
                {
                    airportVirusState = 2; //contagious airport
                    hasVirusCases = true;
                } 
                else if(airportVirusState!=2)
                {
                    airportVirusState = 1; //potentially contagious airport  
                }
            }
        }
    }
}
