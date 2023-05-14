using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uimanager;
    public CharacterController character;

    // gun switched
    // call the update the ui managers stuff
    

    // event happened!

    public void Update()
    {
        uimanager.UpdateValues(this);
    }
}