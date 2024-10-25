using System;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SphereScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Sphere;
    float DistanceTravelled = 0.0f;
    int Hits = 0;
    double Record = 0.0f;
    Vector3 LastPosition;
    TextMeshProUGUI DistanceText;
    void Start()
    {
        Sphere = GameObject.Find("Sphere");
        LastPosition = Sphere.transform.position;
        var obj = GameObject.Find("DistanceTravelled");
        DistanceText = obj.GetComponent<TextMeshProUGUI>();
        var xrGrabObject = Sphere.GetComponent<XRGrabInteractable>();
        xrGrabObject.selectEntered.AddListener((args) =>
        {
            DistanceTravelled = 0;
        });
        xrGrabObject.selectExited.AddListener((args) =>
        {
            Hits++;
        });
    }

    // Update is called once per frame
    void Update()
    {
        DistanceTravelled += Vector3.Distance(Sphere.transform.position, LastPosition);
        if (DistanceTravelled > Record)
            Record = Math.Round(DistanceTravelled, 2);
        LastPosition = Sphere.transform.position;

        DistanceText.text = "Distance travelled: " + Math.Round(DistanceTravelled, 2) + "m" + Environment.NewLine + "Number of hits: " + Hits + Environment.NewLine + "Record: " + Record + "m";
    }
}
