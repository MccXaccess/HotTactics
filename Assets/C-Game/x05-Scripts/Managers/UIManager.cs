using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private BaseEventHandler EventHandler;
    private BaseCharacterControllerConfiguration characterConfigs;

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

    public void UpdateValues(GameManager gameManager)
    {
        _statsHealth.fillAmount = characterConfigs.HealthCurrentAmount / characterConfigs.HealthMaximumAmount;
        _statsStamina.fillAmount = characterConfigs.StaminaCurrentAmount / characterConfigs.StaminaMaximumAmount;
        _statsShield.fillAmount = characterConfigs.ShieldCurrentAmount / characterConfigs.ShieldMaximumAmount;

        var weapon = gameManager.character.gameObject.GetComponent<WeaponController>();

        _ammoTotal.text = weapon?.Gun?.GunMagCurrentAmmo.ToString();
        _ammoMag.text = weapon?.Gun?.GunMagCurrentAmmo.ToString();
    }

    public void Update()
    {

    }

    private void OnCharacterValueChanged(BaseCharacterControllerConfiguration value)
    {
        characterConfigs = value;
    }
}