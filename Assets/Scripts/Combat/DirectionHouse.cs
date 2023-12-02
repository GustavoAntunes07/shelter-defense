using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionHouse : MonoBehaviour
{
    public string houseTag = "House";
    public Vector2Event OnSendDirection;

    Transform house;
    Vector2 dir;


    // Start is called before the first frame update
    void Start()
    {
        house = GameObject.FindGameObjectWithTag(houseTag).transform;
    }

    // Update is called once per frame
    void Update()
    {
        dir = ((Vector2)(house.position - transform.position)).normalized;
        OnSendDirection?.Invoke(dir);
    }
}
