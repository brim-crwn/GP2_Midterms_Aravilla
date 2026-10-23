using UnityEngine;

public class Yellow : Actor
{
    protected override void Start()
    {
        base.Start();
        speed = 7; // Set Grunt's speed
        GetComponent<Renderer>().material.color = Color.yellow;
    }

}
        