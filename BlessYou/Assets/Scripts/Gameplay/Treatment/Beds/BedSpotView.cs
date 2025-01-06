using System;
using Gameplay;
using UnityEngine;

public class BedSpotView : MonoBehaviour
{

    private Collider2D _collider2D;

    [SerializeField]
    private SpriteRenderer _unlockedBedSprite;

    [SerializeField]
    private SpriteRenderer _lockedBedSprite;

    [SerializeField]
    private SpriteRenderer _patientSprite;


    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    public void TurnOnInteract()
    {
        _collider2D.enabled = true;
    }

    public void TurnOffInteract()
    {
        _collider2D.enabled = false;
    }

    public void OnMouseDown()
    {
        Interract();
    }

    private void Interract()
    {
        Debug.Log("ты кликнул на кровать");
    }

    public void Unlock()
    {
        _unlockedBedSprite.gameObject.SetActive(true);
        _lockedBedSprite.gameObject.SetActive(false);
        _patientSprite.gameObject.SetActive(false);
        TurnOffInteract();
    }

    public void Lock()
    {
        _unlockedBedSprite.gameObject.SetActive(false);
        _lockedBedSprite.gameObject.SetActive(true);
        _patientSprite.gameObject.SetActive(false);
        TurnOffInteract();
    }

    public void SetPatient(Patient patient)
    {
        _patientSprite.gameObject.SetActive(true);
    }
}