using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// !!!ATTENTION. WAR OF GAME DEV!!! !!!ATTENTION. WAR OF GAME DEV!!! //
// The Purpose of this Script is nothing, just test for my own needs //
// !!!ATTENTION. WAR OF GAME DEV!!! !!!ATTENTION. WAR OF GAME DEV!!! //

public class DummyPinguin : MonoBehaviour
{
    public BaseEventHandler currentSelectedCharacter;
    public BaseCharacterControllerConfiguration cc;

    private void Start()
    {
        currentSelectedCharacter.onCharacterSwitchedEvent.AddListener(OnSelectionChanged);
    }

    private void Update()
    {
        OnSelectionChanged(cc);
    }

    private void OnSelectionChanged(BaseCharacterControllerConfiguration newCharacter)
    {
        Debug.Log($"Selected character: {newCharacter.name}");
        Debug.Log(currentSelectedCharacter.currentCharacterConfigs);
    }
}