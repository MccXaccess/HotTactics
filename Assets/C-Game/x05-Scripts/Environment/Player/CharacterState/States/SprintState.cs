using UnityEngine;

public class SprintState : BaseCharacterStateAbstract
{
    private BaseCharacterControllerConfiguration characterConfigs;

    public SprintState (BaseCharacterControllerConfiguration configs)
    {
        this.characterConfigs = configs;
    }

    public override void EnterState(CharacterStateManager character)
    {

    }

    public override void UpdateState(CharacterStateManager character)
    {
        characterConfigs.CurrentMovementSpeed = characterConfigs.StaminaCurrentAmount <= 0.0f ? characterConfigs.CurrentMovementSpeed = characterConfigs.WalkSpeed : characterConfigs.CurrentMovementSpeed = characterConfigs.SprintSpeed; 

        if (!characterConfigs.IsSprinting && characterConfigs.IsCombatStance)
        {
            // NOTE : Decrease stamina while this is active state.
            character.SwitchState(character.CombatStanceState);
        }

        if (!characterConfigs.IsSprinting && !characterConfigs.IsCombatStance)
        {
            character.SwitchState(character.WalkState);
        }

        if (!characterConfigs.IsMoving && !characterConfigs.IsCombatStance && !characterConfigs.IsSprinting)
        {
            character.SwitchState(character.IdleState);
        }

        if (characterConfigs.IsDashing)
        {
            character.SwitchState(character.DashState);
        }
    }

    public override void FixedUpdateState(CharacterStateManager character) 
    {
        if (!characterConfigs.IsMoving && characterConfigs.IsSprinting)
        {
            characterConfigs.SetBoolean("IsStaminaIncreaseAllowed", true);
            characterConfigs.SetBoolean("IsStaminaDecreaseAllowed", false);
            characterConfigs.RecoilSystem("RecoilIdleMaximumClamp", characterConfigs.RecoilIdleMultiplier);
        }

        if (characterConfigs.IsMoving && characterConfigs.IsSprinting)
        {
            characterConfigs.SetBoolean("IsStaminaIncreaseAllowed", false);
            characterConfigs.SetBoolean("IsStaminaDecreaseAllowed", true);
            characterConfigs.RecoilSystem("RecoilSprintMaximumClamp", characterConfigs.RecoilSprintMultiplier);
        }
    }

    public override void ExitState(CharacterStateManager character)
    {
        characterConfigs.CurrentMovementSpeed = 0.0f;
    }
}