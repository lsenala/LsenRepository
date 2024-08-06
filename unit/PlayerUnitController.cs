using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using R3;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerUnitController : MonoBehaviour
{
    float lrMouseButton;
    Vector2 mousePosiiton;
    PlayerInput playerInput;
    IEnumerable<UnitAbility> unitAbilities;
    [SerializeField] PlayerUnit playerUnit;//playerUnit->
    public PlayerUnit PlayerUnit { get { return playerUnit; } private set { playerUnit = value; } }
    private void Awake()
    { 
        playerInput = new PlayerInput();
    }
    void Start()
    {       
    }

    /// <summary>
    /// 列表总是最新的
    /// </summary>
    /// <param name="newItemList"></param>
    async UniTaskVoid ActOnInput(IEnumerable<UnitAbility> newItemList)
    {
        unitAbilities = newItemList;
        await UniTask.Yield();
    }
    /// <summary>
    /// 按一次检测条件，启动碰撞器
    /// </summary>
    /// <param name="context"></param>
    private void OnKeyPress(InputAction.CallbackContext context)
    {
        int itemSerialNum= Convert.ToInt32(context.control.name);
        if(unitAbilities==null) {
            Debug.Log("Not Have");
            return;
        }
        else if(unitAbilities.Count()<itemSerialNum) {
            Debug.Log("Out of range");
        }
        else if(unitAbilities.ToArray()[itemSerialNum-1]!=null ) {
            UnitAbility ability = unitAbilities.ToArray()[itemSerialNum - 1];
            string abilityName=ability.GetType().Name;
            Type abilityBaseType=ability.GetType().BaseType;
            Debug.Log(abilityName);
            if (abilityBaseType == typeof(Craft))
                InstantiaIndicatorGO(playerUnit.UnitCrafts, abilityName);
            else if (abilityBaseType == typeof(Spell))
                InstantiaIndicatorGO(playerUnit.UnitSpells, abilityName);
            else if (abilityBaseType == typeof(SpecialSkill)) 
                InstantiaIndicatorGO(playerUnit.UnitSpecialSkills, abilityName);
        }
    }
    private void InstantiaIndicatorGO<T>(IEnumerable<T> abilityList,string abilityName) where T :UnitAbility 
    {
        abilityList.ToUniTaskAsyncEnumerable()
            .WhereAwait(ability => {return new UniTask<bool>(ability.AbilityName == abilityName);})
            .SelectAwait(async (ability) => {
                var asyncsp = UniTask.Create(async () => {
                    //ability.Cast(transform.position, ability.IndicatorGO,);
                    await UniTask.Yield();
                    
                });
                await UniTask.Yield();
                return ability;
            }).ToListAsync();
    }
    private void OnMouseMove(InputAction.CallbackContext context)
    {
        mousePosiiton = context.ReadValue<Vector2>();
        Debug.Log("sys " + mousePosiiton);
        Debug.Log("manager "+Input.mousePosition);
    }
    /// <summary>
    /// 按左键使用能力 按右键返回上级菜单？
    /// </summary>
    /// <param name="context"></param>
    private void OnMouseButtonPress(InputAction.CallbackContext context)
    {
        lrMouseButton = context.ReadValue<float>();

    }
    private void OnEnable()
    {
        playerInput.PlayerBattleInput.SelectItem.Enable();
        playerInput.PlayerBattleInput.SelectItem.performed += OnKeyPress;
        playerInput.PlayerBattleInput.TargetPosition.Enable();
        playerInput.PlayerBattleInput.TargetPosition.performed += OnMouseMove;
        playerInput.PlayerBattleInput.YesOrNot.Enable();
        playerInput.PlayerBattleInput.YesOrNot.performed += OnMouseButtonPress;
        BattleOption.updateUnitAbilitiesList += ActOnInput;
    }
    private void OnDisable()
    {
        playerInput.PlayerBattleInput.SelectItem.Disable();
        playerInput.PlayerBattleInput.SelectItem.performed -= OnKeyPress;
        playerInput.PlayerBattleInput.TargetPosition.Disable();
        playerInput.PlayerBattleInput.TargetPosition.performed -= OnMouseMove;
        playerInput.PlayerBattleInput.YesOrNot.Disable();
        playerInput.PlayerBattleInput.YesOrNot.performed -= OnMouseButtonPress;
        BattleOption.updateUnitAbilitiesList -= ActOnInput;
    }
}
