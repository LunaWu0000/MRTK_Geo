using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Devices.Geolocation;

public class MyLocation : MonoBehaviour
{
    // Proides access to location data
    public Geolocator _geolocator = null;
    public async void StartTracking()
    {
        // Request permission to access location
        var accessStatus = await Geolocator.RequestAccessAsync();

        switch (accessStatus)
        {
            case GeolocationAccessStatus.Allowed:
                // You should set MovementThreshold for distance-based tracking
                // or ReportInterval for periodic-based tracking before adding event
                // handlers. If none is set, a ReportInterval of 1 second is used
                // as a default and a position will be returned every 1 second.
                //
                // Value of 2000 milliseconds (2 seconds)
                // isn't a requirement, it is just an example.
                _geolocator = new Geolocator { ReportInterval = 1000 };

                // Subscribe to PositionChanged event to get updated tracking positions
                //_geolocator.PositionChanged += OnPositionChanged;

                // Subscribe to StatusChanged event to get updates of location status changes
                //_geolocator.StatusChanged += OnStatusChanged;

                print("Waiting for update...");
                break;

            case GeolocationAccessStatus.Denied:
                print("Access to location is denied.");
                break;

            case GeolocationAccessStatus.Unspecified:
                print("Unspecificed error!");
                break;
        }
    }
}
