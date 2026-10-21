using UnityEngine;

public class Red : Actor
{
    protected override void Start()
    {
        base.Start();
        speed = 7; // Set Grunt's speed
        GetComponent<Renderer>().material.color = Color.red;
    }
    
}
