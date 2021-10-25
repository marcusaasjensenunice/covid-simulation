using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirportRendererController : MonoBehaviour
{
    private Material airportVirusStateMat;
    public Material contagiousAirportMat;
    public Material potentiallyContagiousAirportMat;
    public Material safeAirportMat; 
    public Material blockedAirportMat;
    public AirportNetwork airportNetwork;

    void Start()
    {
        airportVirusStateMat = safeAirportMat;
    }

    void Update()
    {
        foreach(Airport airport in airportNetwork.airports)
        {
            if(!airport.isBlocked)
            {
                if(!airport.hasVirusCases)
                {
                    if(airport.airportVirusState == 1)
                    {
                        airportVirusStateMat = potentiallyContagiousAirportMat;
                    }
                    else if(airport.airportVirusState == 0)
                    {
                        airportVirusStateMat = safeAirportMat;
                    }
                }
                else
                {
                    airportVirusStateMat = contagiousAirportMat;
                }
            }
            else
            {
                airportVirusStateMat = blockedAirportMat;
            }

            airport.GetComponent<Renderer>().material = airportVirusStateMat;
        }
    }
}
