using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager {

    public RollResult RollDice (DiceInstance dice, BattleTurn turn) {

        int randomIndex = Random.Range (0, dice.data.faces.Length);
        int rolledValue = dice.data.faces[randomIndex];

        RollResult result = new RollResult (dice, rolledValue, turn);
        // Aca van los posibles efectos
        return result;
    }
}
