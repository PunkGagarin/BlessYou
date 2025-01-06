using UnityEngine;

public class BedSpotView : MonoBehaviour
{
    
    [SerializeField]
    private Collider2D _collider2D;
    
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
