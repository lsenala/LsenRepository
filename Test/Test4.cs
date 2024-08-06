using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test4 : MonoBehaviour
{
    PlayerInput playerInput;
    Renderer r;
    private void Awake()
    {
        playerInput = new PlayerInput();
        r = GetComponent<MeshRenderer>();
    }
    private void OnMouseMove(InputAction.CallbackContext context)
    {

    }
    private void OnKeyPress(InputAction.CallbackContext context)
    {
        if (context.started)
            r.material.color = Color.yellow;
        else if (context.performed)
            r.material.color = Color.green;
        else if (context.canceled)
            r.material.color = Color.red;
    }
    private void OnMouseButtonPress(InputAction.CallbackContext context)
    {

    }
    private void OnEnable()
    {
        playerInput.PlayerBattleInput.SelectItem.Enable();
        playerInput.PlayerBattleInput.SelectItem.started += OnKeyPress;
        playerInput.PlayerBattleInput.SelectItem.canceled += OnKeyPress;
        playerInput.PlayerBattleInput.SelectItem.performed += OnKeyPress;
        playerInput.PlayerBattleInput.TargetPosition.Enable();
        playerInput.PlayerBattleInput.TargetPosition.performed += OnMouseMove;
        playerInput.PlayerBattleInput.YesOrNot.Enable();
        playerInput.PlayerBattleInput.YesOrNot.performed += OnMouseButtonPress;
    }
    private void OnDisable()
    {
        playerInput.PlayerBattleInput.SelectItem.Disable();
        playerInput.PlayerBattleInput.SelectItem.started -= OnKeyPress;
        playerInput.PlayerBattleInput.SelectItem.canceled -= OnKeyPress;
        playerInput.PlayerBattleInput.SelectItem.performed -= OnKeyPress;
        playerInput.PlayerBattleInput.TargetPosition.Disable();
        playerInput.PlayerBattleInput.TargetPosition.performed -= OnMouseMove;
        playerInput.PlayerBattleInput.YesOrNot.Disable();
        playerInput.PlayerBattleInput.YesOrNot.performed -= OnMouseButtonPress;
    }
}
