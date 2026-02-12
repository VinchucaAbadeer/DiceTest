using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDice", menuName = "Dice & Waifus/Dice Data")]
public class DiceData : ScriptableObject {

    [Header ("Basic Info")]
    public string id;
    public string displayName;
    [TextArea] public string description;
    [Header ("Dice Faces")]
    public int[] faces = new int[6];
    [Header ("Tags")]
    public List<string> tags;
    [Header ("Effects")]
    public List<DiceEffectData> effects;
}
