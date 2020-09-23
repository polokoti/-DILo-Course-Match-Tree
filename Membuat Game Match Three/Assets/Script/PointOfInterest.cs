using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfInterest : Subject
{
    // nama dari POI
    [SerializeField]
    private string _poiName;

    //jika gameobject disable akan menotify observer
    private void OnDisable()
    {
        Notify(_poiName);
    }
}
