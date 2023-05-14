using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DashState : BaseCharacterStateAbstract
{
    private BaseCharacterControllerConfiguration characterConfigs;

    float currentTimer;
    float currentCooldownTimer;

    private Coroutine _dodging;

    public DashState (BaseCharacterControllerConfiguration configs)
    {
        this.characterConfigs = configs;
    }

    public override void EnterState(CharacterStateManager character)
    {

    }

    public override void UpdateState(CharacterStateManager character)
    {
        
    }

    public override void FixedUpdateState(CharacterStateManager character)
    {
        characterConfigs.RecoilSystem("RecoilDashMaximumClamp", characterConfigs.RecoilDashMultiplier);

        if (currentCooldownTimer <= 0f)
        {
            _dodging = character.StartCoroutine(DodgeCoroutine(character));
        }
        else { currentCooldownTimer -= Time.fixedDeltaTime; }
    }

    public override void ExitState(CharacterStateManager character)
    {

    }

    private IEnumerator DodgeCoroutine(CharacterStateManager character)
    {
        // NOTE : REWORK THIS PIECE OF SHIT ... SAUL...
        var endOfFrame = new WaitForEndOfFrame();
        var direction = new Vector3(characterConfigs.MovementDirection.x, characterConfigs.MovementDirection.y, 0);

        for (currentTimer = 0; currentTimer < characterConfigs.DashCooldownTime; currentTimer += Time.fixedDeltaTime)
        {
            characterConfigs.RB2D.AddForce(character.transform.position + direction * (characterConfigs.DashForce * characterConfigs.DashMultiplier * Time.fixedDeltaTime), ForceMode2D.Force);
            
            yield return endOfFrame;
        }
        currentCooldownTimer = characterConfigs.DashCooldownTime;

        character.SwitchState(character.WalkState);
        
        _dodging = null;
    }
}