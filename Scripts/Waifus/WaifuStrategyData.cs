using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStrategy", menuName = "Dice & Waifus/Waifu Strategy") ]
public class WaifuStrategyData : ScriptableObject {

    [Header ("Risk Behavior")]
    [Range (10, 17)]
    public int standThreshold; // Se planta en este valor
    [Range (0f, 1f)]
    public float aggression; // 0 = Conservadora, 1 = Agresiva
    [Range(0f, 1f)]
    public float preferenceForSpecialDice;

}
