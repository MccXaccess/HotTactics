using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private BaseEventHandler EventHandler;
    private BaseCharacterControllerConfiguration characterConfigs;

    private GunController gunController;

    private void Awake()
    {
        characterConfigs = EventHandler.CurrentCharacterConfigs;
        EventHandler.onCharacterSwitchedEvent.AddListener(OnCharacterValueChanged);
    }

    [Header("Fillable Images:")]
    [SerializeField] private Image _statsHealth;
    [SerializeField] private Image _statsStamina;
    [SerializeField] private Image _statsShield;

    [Header("Text Fields:")]
    [SerializeField] private TextMeshProUGUI _ammoTotal;
    [SerializeField] private TextMeshProUGUI _ammoMag;

    public void UpdateCharcterGun(characterGun)
    {
        gunController = characterGun;
    }
    
    public void Update()
    {
        _statsHealth.fillAmount = characterConfigs.HealthCurrentAmount / characterConfigs.HealthMaximumAmount;
        _statsStamina.fillAmount = characterConfigs.StaminaCurrentAmount / characterConfigs.StaminaMaximumAmount;
        _statsShield.fillAmount = characterConfigs.ShieldCurrentAmount / characterConfigs.ShieldMaximumAmount;

        _ammoTotal.text = "value";
        _ammoMag.text = "value";
    }

    private void OnCharacterValueChanged(BaseCharacterControllerConfiguration value)
    {
        characterConfigs = value;
    }
}