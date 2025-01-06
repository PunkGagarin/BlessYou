using System;
using UnityEngine;

public class BedSpotView : MonoBehaviour
{
    
    private Collider2D _collider2D;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    public void TurnOnInterract()
    {
        _collider2D.enabled = true;
            //colliderTurnOn
    }

    public void OnMouseDown()
    {
        Interract();
    }
    
    private void Interract()
    {
        Debug.Log("ты кликнул на кровать");
    }
}
