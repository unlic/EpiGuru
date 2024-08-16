using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    [SerializeField] private ObstacleType type;

    public GameLogic gameLogic;

    public static Action StopMovingAction;

    private bool move = true;

    private void Start()
    {
        StopMovingAction += StopMoving;
    }
    void Update()
    {
        if (move)
            transform.Translate(0f, 0f, -speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collider)
    {
        var player =  collider.GetComponent<Player>();
        if (player != null) 
        {
            gameLogic.CollisionWithObstacleEvent.Invoke(type);
        }

        Destroy(gameObject);
    }

    private void StopMoving()
    {
        move = false;   
    }
}
