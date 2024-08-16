using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    public Action<ObstacleType> CollisionWithObstacleEvent;

    public Action GameOver;
    public Action<int> ChangeCoinCount;

    private int coinCount = 0;
    void Start()
    {
        CollisionWithObstacleEvent += CollisionWithObstacle;
    }


    private void CollisionWithObstacle(ObstacleType type)
    {
        switch (type)
        {
            case ObstacleType.Block:
                GameOver?.Invoke();
                break;
            case ObstacleType.Coin:
                ChangeCoinCount?.Invoke(++coinCount);
                break;
            default:
                break;
        }
    }
}
