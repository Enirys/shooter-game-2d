using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float timeBtwProj = 40;
    public float startTimeBtwProj;

    [SerializeField]
    private float rotOffset;
    [SerializeField]
    private GameObject[] projectile;
    private int projIndex;
    [SerializeField]
    private Transform shotPos;
 
    // Update is called once per frame
    void Update()
    {
        if(timeBtwProj <= 0 && projIndex < projectile.Length)
        {
            projIndex++;

            timeBtwProj = startTimeBtwProj;
        }
        else
        {
            timeBtwProj -= Time.deltaTime;
        }

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg + rotOffset;

        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(projectile[projIndex], shotPos.position, transform.rotation);
        }
    }
}
