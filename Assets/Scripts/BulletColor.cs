using UnityEngine;

public class BulletColor : MonoBehaviour, ISwitchable
{
    private Renderer objectRenderer;

    public Color CurrentColor => objectRenderer.material.color;

    private void Awake()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    public void SwitchColor(Color color)
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = color;
        }
    }
}
