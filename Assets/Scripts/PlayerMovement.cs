using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [SerializeField] private Transform player;
    [SerializeField] private float speed = 5f;
    private Vector2 previousPosition = Vector2.zero;
    private Vector2 currentTouchPosition = Vector2.zero;
    private Vector2 swipeDelta = Vector2.zero;

    private float maxPosition = 7;
    private float minPosition =- 7;
    
    private float moveVector = 0f;
    void Update()
    {

        if(player.position.x <= minPosition&& moveVector < 0)
        {
            return;
        }

        if (player.position.x >= maxPosition && moveVector > 0)
        {
            return;
        }

        player.Translate(moveVector * speed * Time.deltaTime, 0f, 0f);

    }

    public void OnDrag(PointerEventData eventData)
    {
        currentTouchPosition = eventData.position;

        swipeDelta = currentTouchPosition - previousPosition;
        moveVector = swipeDelta.x;
        


        previousPosition = currentTouchPosition;


    }

    public void OnEndDrag(PointerEventData eventData)
    {
        previousPosition = Vector2.zero;
        swipeDelta = Vector2.zero;
        moveVector = 0f;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        previousPosition = eventData.position;
    }

}
