using UnityEngine;

public class WalkState : BaseCharacterStateAbstract
{
    private BaseCharacterControllerConfiguration characterConfigs;

    public WalkState (BaseCharacterControllerConfiguration configs)
    {
        this.characterConfigs = configs;
    }

    public override void EnterState(CharacterStateManager character)
    {
        characterConfigs.SetBoolean("IsStaminaIncreaseAllowed", true);
        characterConfigs.SetBoolean("IsStaminaDecreaseAllowed", false);
        characterConfigs.CurrentMovementSpeed = characterConfigs.WalkSpeed;
    }

    public override void UpdateState(CharacterStateManager character)
    {
        if (characterConfigs.IsSprinting && !characterConfigs.IsCombatStance)
        {
            character.SwitchState(character.SprintState);
        }

        if (!characterConfigs.IsSprinting && characterConfigs.IsCombatStance)
        {
            character.SwitchState(character.CombatStanceState);
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
        characterConfigs.RecoilSystem("RecoilWalkMaximumClamp", characterConfigs.RecoilWalkMultiplier);
    }

    public override void ExitState(CharacterStateManager character)
    {
        characterConfigs.CurrentMovementSpeed = 0.0f;
    }
}