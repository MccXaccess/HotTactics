using UnityEngine;

public class IdleState : BaseCharacterStateAbstract
{
    private BaseCharacterControllerConfiguration characterConfigs;

    public IdleState (BaseCharacterControllerConfiguration configs)
    {
        this.characterConfigs = configs;
    }

    public override void EnterState(CharacterStateManager character)
    {
        characterConfigs.SetBoolean("IsStaminaIncreaseAllowed", true);
        characterConfigs.CurrentMovementSpeed = 0.0f;
    }

    public override void UpdateState(CharacterStateManager character)
    {        
        if (characterConfigs.IsMoving)
        {
            character.SwitchState(character.WalkState);
        }

        if (characterConfigs.IsSprinting)
        {
            character.SwitchState(character.SprintState);
        }

        if (characterConfigs.IsCombatStance)
        {
            character.SwitchState(character.CombatStanceState);
        }

        if (characterConfigs.IsDashing)
        {
            character.SwitchState(character.DashState);
        }
    }

    public override void FixedUpdateState(CharacterStateManager character) 
    { 
        if (!characterConfigs.IsMoving && characterConfigs.IsCombatStance)
        {
            characterConfigs.RecoilSystem("RecoilIdleMaximumClamp", characterConfigs.RecoilIdleMultiplier);
        }
        else
        {
            characterConfigs.RecoilSystem("RecoilIdleMaximumClamp", characterConfigs.RecoilIdleMultiplier);
        }
    }

    public override void ExitState(CharacterStateManager character)
    {
        characterConfigs.SetBoolean("IsStaminaIncreaseAllowed", false);
        // NOTE : make this reference to Movement Scriptable Object so it wouldn't be static?
        characterConfigs.CurrentMovementSpeed = 0.0f;
    }
}