using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Move))]
public class EnemyShooterAI : MonoBehaviour
{
    public string houseTag = "House";
    public float distanceToStop = 7.5f;
    public float distanceToStopVariation = 3;
    public BoolEvent OnStop;

    Move move;
    GameObject house;
    bool isCloseToHouse;
    float dirToHouse;
    float distance;
    float _distanceToStop;

    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Move>();
        house = GameObject.FindGameObjectWithTag(houseTag);
        _distanceToStop = Random.Range(
            distanceToStop - distanceToStopVariation,
            distanceToStop + distanceToStopVariation
        );
    }

    // Update is called once per frame
    void Update()
    {
        var wasCloseToHouse = isCloseToHouse;
        dirToHouse = Mathf.Sign(house.transform.position.x - transform.position.x);
        distance = Mathf.Abs(house.transform.position.x - transform.position.x);

        if (distance <= _distanceToStop)
        {
            isCloseToHouse = true;
            move.SetDirection(0);
        }
        else
        {
            isCloseToHouse = false;
            move.SetDirection(dirToHouse);
        }

        if (isCloseToHouse != wasCloseToHouse)
            OnStop?.Invoke(isCloseToHouse);
    }
}
