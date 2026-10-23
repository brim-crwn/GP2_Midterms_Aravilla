using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Targeting")]
    private Transform target; 
    public float range = 30f;
    public Transform partToRotate;
    public float turnSpeed = 10f;

    public string enemyTag = "Enemy";
    
    [Header("Shooting")]
    public float fireRate = 1f;
    public float fireCountdown = 0f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("Bullet Colors")]
    [SerializeField] public List<Color> colors = new List<Color>()
    {
        Color.red,
        Color.blue,
        Color.green,
        Color.yellow
    };
    [Header("Barrel Color")]
    [SerializeField] private GameObject barrel;
    private Renderer barrelRenderer;


    private ISwitchable switchable;
    private int colorIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        
        if (barrel != null)
        {
            barrelRenderer = barrel.GetComponent<Renderer>();
        }
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchObjectColor();
        }

        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        Vector3 rotation = Quaternion.Lerp(
            partToRotate.rotation,
            lookRotation,
            Time.deltaTime * turnSpeed
        ).eulerAngles;

        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGO = Instantiate(
            bulletPrefab,
            firePoint.position,
            firePoint.rotation
        );

        ISwitchable switchable = bulletGO.GetComponent<ISwitchable>();

        if (switchable != null && colors.Count > 0)
        {
            switchable.SwitchColor(colors[colorIndex]);
        }

        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }


    private void SwitchObjectColor()
    {
        if (colors.Count == 0)
            return;

        colorIndex = (colorIndex + 1) % colors.Count;

        Color selectedColor = colors[colorIndex];

        if (barrelRenderer != null)
        {
            barrelRenderer.material.color = selectedColor;
        }
    }


}
