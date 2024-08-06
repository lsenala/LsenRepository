using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Cysharp.Threading.Tasks;


public class BattleOption : MonoBehaviour
{
    public static Func<IEnumerable<UnitAbility>,UniTaskVoid> updateUnitAbilitiesList;
    string optionName;
    int currentPage=1;
    PlayerInput playerInput;
    TextMeshProUGUI[] textMeshProUGUIs;
    [SerializeField] Unit unit;
    private void Awake()
    {
        playerInput = new PlayerInput();
        textMeshProUGUIs = GetComponentsInChildren<TextMeshProUGUI>();        
    }
    private void OnDisable()
    {
        playerInput.PlayerBattleInput.ShiftItemMenu.Disable();
        playerInput.PlayerBattleInput.ShiftItemMenu.performed -= ShiftOptionMenu;
        BulletElements.optionChangeEvent -= OnOptionChange;
    }
    private void OnEnable()
    {
        playerInput.PlayerBattleInput.ShiftItemMenu.Enable();
        playerInput.PlayerBattleInput.ShiftItemMenu.performed += ShiftOptionMenu;
        BulletElements.optionChangeEvent += OnOptionChange;//Awakeʱ��ս��Ԫ�أ�ս��ѡ���תʱ�����øú���
    }
    private void OnOptionChange(string buttonName)
    {
        optionName = buttonName;
        currentPage = 0;
        if (AbilityType.Craft.ToString() == optionName)
            DisplayAbilitiesList(unit.UnitCrafts, 0);
        else if (AbilityType.Spell.ToString() == optionName)
            DisplayAbilitiesList(unit.UnitSpells, 0);
        else if (AbilityType.SpecialSkill.ToString() == optionName)
            DisplayAbilitiesList(unit.UnitSpecialSkills, 0);
        else {
            textMeshProUGUIs.ToList().ForEach(t => t.SetText(" "));
            DisplayAbilitiesList(default(List<UnitAbility>), 0);//��ѡ���ѡ�����������ʱ�����Ϳ��б�
        }
    }
    /// <summary>
    /// ��RF���л���ѡ���µĲ˵���Ŀ
    /// </summary>
    /// <param name="context"></param>
    private void ShiftOptionMenu(InputAction.CallbackContext context) 
    {
        float shiftCount = context.ReadValue<float>();
        Debug.Log("Shift " + shiftCount);
        if (AbilityType.Craft.ToString() == optionName)
            DisplayAbilitiesList(unit.UnitCrafts, shiftCount);
        else if (AbilityType.Spell.ToString() == optionName)
            DisplayAbilitiesList(unit.UnitSpells, shiftCount);
        else if (AbilityType.SpecialSkill.ToString() == optionName)
            DisplayAbilitiesList(unit.UnitSpecialSkills, shiftCount);                                                  
    }
    private void DisplayAbilitiesList<T>(List<T> unitAbilities,float shiftCount) where T : UnitAbility
    {
        if (unitAbilities == null) {
            updateUnitAbilitiesList?.Invoke(unitAbilities);
            return;
        }
        //��û��ȫ����ShiftOptionMenu
        int sc =(int)shiftCount;
        int numberOfPages=unitAbilities.Count % 5 == 0 ? unitAbilities.Count / 5 : unitAbilities.Count / 5 + 1;    
        currentPage += sc;
        if (currentPage == 0) {
            currentPage = numberOfPages;
        }
        else if (currentPage / numberOfPages >1 )
            currentPage = 1;
        
        int temp;
        List<T> listToDisplay=unitAbilities.Where((unitAbility, index) => index <= currentPage * 5
                                           &&(temp=(currentPage - 1!=0?(currentPage-1)*5:-5))< index).ToList();
        
        updateUnitAbilitiesList?.Invoke(listToDisplay);
        int listCout =listToDisplay.Count();//Ҫ�Ż�
        if (textMeshProUGUIs.Length == listCout) {
            for (int i = 0; i <= textMeshProUGUIs.Length; i++) {
                textMeshProUGUIs[i].text = listToDisplay[i].AbilityName; 
            }
        }
        else if(textMeshProUGUIs.Length > listCout) {
            for (int i = 0; i < listCout; i++) {
                textMeshProUGUIs[i].text = listToDisplay[i].AbilityName;
            }
        }
        if(listCout==0) {
            textMeshProUGUIs.ToList().ForEach(t => t.SetText(" "));
        }
    }
}