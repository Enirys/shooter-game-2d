using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    [SerializeField]
    private float maxX;
    [SerializeField]
    private float maxY;
    [SerializeField]
    private float minY;
    [SerializeField]
    private float minX;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, minX, maxX), Mathf.Clamp(player.transform.position.y, minY, maxY), transform.position.z);
        }
        
    }
}
