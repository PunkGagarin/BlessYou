using System;
using Gameplay;
using Gameplay.Base;
using Gameplay.Patients;
using UnityEngine;

public class BedSpotView : ClickableView
{

    [SerializeField]
    private SpriteRenderer _unlockedBedSprite;

    [SerializeField]
    private SpriteRenderer _lockedBedSprite;

    [SerializeField]
    private SpriteRenderer _patientSprite;

    [SerializeField]
    private PatientTimerUI _timerUI;

    public void TurnOnInteract()
    {
        _collider2D.enabled = true;
    }

    public void TurnOffInteract()
    {
        _collider2D.enabled = false;
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
        _timerUI.Show();
        SetTimer(patient.Disease.HealInfo.HealTime);
        TurnOnInteract();
    }

    private void SetTimer(float time)
    {
        _timerUI.SetTimer(time);
    }

    public void CleanFromPatient()
    {
        _patientSprite.gameObject.SetActive(false);
        _timerUI.Hide();
    }
}