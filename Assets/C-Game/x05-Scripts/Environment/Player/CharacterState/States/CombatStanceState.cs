using UnityEngine;

public class CombatStanceState : BaseCharacterStateAbstract
{
    private BaseCharacterControllerConfiguration characterConfigs;

    public CombatStanceState (BaseCharacterControllerConfiguration configs)
    {
        this.characterConfigs = configs;
    }

    public override void EnterState(CharacterStateManager character)
    {
        characterConfigs.SetBoolean("IsStaminaIncreaseAllowed", true);
        characterConfigs.SetBoolean("IsStaminaDecreaseAllowed", false);
        characterConfigs.CurrentMovementSpeed = characterConfigs.CombatStanceSpeed;
    }

    public override void UpdateState(CharacterStateManager character)
    {
        if (characterConfigs.IsSprinting && !characterConfigs.IsCombatStance)
        {
            character.SwitchState(character.SprintState);
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
        if (characterConfigs.IsMoving)
        {
            characterConfigs.RecoilSystem("RecoilCombatStanceMaximumClamp", characterConfigs.RecoilCombatStanceMultiplier);           
        }
        else
        {
            characterConfigs.RecoilSystem("RecoilIdleMaximumClamp", characterConfigs.RecoilIdleMultiplier);
        }
    }

    public override void ExitState(CharacterStateManager character)
    {
        characterConfigs.CurrentMovementSpeed = 0.0f;
    }
}