using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollResult {

    public DiceInstance diceInstance;
    public int baseValue;
    public int finalValue;

    public BattleTurn roller;

    public List<string> triggerEffects = new();

    public RollResult (DiceInstance dice, int rolledValue, BattleTurn turn) {
        diceInstance = dice;
        baseValue = rolledValue;
        finalValue = rolledValue;
        roller = turn;
    }
}
