using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpreading : MonoBehaviour
{
    public Virus virus;
    public AirplaneNetwork airplaneNetwork;

    void Start()
    {
        airplaneNetwork.airplanes[Random.Range(0,airplaneNetwork.airplanes.Count-1)].hasVirus = true;
    }

    void Update()
    {
        foreach(Airplane airplane in airplaneNetwork.airplanes)
        {
            if(airplane.currentAirport!=null)
                    if(airplane.currentAirport.hasVirusCases)
                        infect(airplane);

        
        }
    }



    public void infect(Airplane airplane)
    {
        if(airplane.checkInfection && !(airplane.hasVirus))
        {
            float randomness = Random.Range(1, 100);
            if(randomness <= virus.contaminationRate)
            {
                airplane.hasVirus = true;
            }
            else
            {
                airplane.hasVirus = false;
            }
            airplane.checkInfection = false;
        }
    }
}
