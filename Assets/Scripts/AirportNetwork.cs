using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirportNetwork : MonoBehaviour
{
    public AirportNetworkBuilder airportNetworkBuilder;
    public List<Airport> airports;
    public List<Airport> airportsWithVirusCases;
    public List<Airport> blockedAirports;
    void Start()
    {
        airports = new List<Airport>();
        airportsWithVirusCases = new List<Airport>();
        blockedAirports = new List<Airport>();
        for(int i = 0 ; i < airportNetworkBuilder.nbNodes ; i++)
        {
            airports.Add(airportNetworkBuilder.nodes[i].GetComponent<Airport>());
        }
    }

    void Update()
    {
        foreach(Airport airport in airports)
        {
            if(airport.hasVirusCases && !airportsWithVirusCases.Contains(airport))
            {
                airportsWithVirusCases.Add(airport);
            }

            if(airport.isBlocked && !blockedAirports.Contains(airport))
            {
                blockedAirports.Add(airport);
            }

        }
    }
}
