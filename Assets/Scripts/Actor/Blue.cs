using UnityEngine;

public class Blue : Actor
{
    protected override void Start()
    {
        base.Start();
        speed = 7; // Set Grunt's speed
        GetComponent<Renderer>().material.color = Color.blue;
    }
    
}
