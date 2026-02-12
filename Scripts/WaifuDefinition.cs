using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "NewWaifu", menuName = "Dice & Waifus/Waifu Definition")]
public class WaifuDefinition : ScriptableObject {

    [Header ("Basic Info")]
    public string id;
    public string displayName;
    [TextArea] public string description;
    [Space (10)]
    [Header ("Stats")]
    public int maxHP;
    [Header ("Starting Dice")]
    public List <DiceData> startingDice;
    [Header ("AI Settings")]
    public WaifuStrategyData strategyData;
    [Header ("Dialogue")]
    [TextArea] public string preBattleDialogue;
    [TextArea] public string victoryDialogue;
    [TextArea] public string defeatDialogue;
}
