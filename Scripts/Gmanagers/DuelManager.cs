using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuelManager : MonoBehaviour {

    public static DuelManager instance;
    public BattleContext context;

    private void Awake () {
        instance = this;
    }

    private void Start () {
        StartBattle (testWaifu, 3);
    }

    // ------------------------------------------------
    public WaifuDefinition testWaifu;
    public DiceData testingDice;

    public void TestDuel () {
        DiceInstance testDice = new DiceInstance ("test_1", testingDice);
        context.playerInventory.Add (testDice);
        TryPlayDice (testDice);
    }
    // ------------------------------------------------


    public void StartBattle (WaifuDefinition waifuDef, int playerMaxHP) {
        context = new BattleContext (waifuDef, playerMaxHP);
        Debug.Log ("Battle Started VS " + waifuDef.displayName);
        Debug.Log ("Player HP: " + context.playerCurrentHP);
        Debug.Log ("Waifu HP: " + context.waifuCurrentHP);
    }

    public void TryPlayDice (DiceInstance dice) {
        if (context.currentTurn != BattleTurn.Player) {
            Debug.Log("Not Player turn!");
            return;
        }

        if (!context.playerInventory.Contains (dice)) {
            Debug.Log ("No dice in inventory");
            return;
        }

        context.playerInventory.Remove (dice);
        context.playerDiceOnTable.Add (dice);
        StartCoroutine (RollDiceWithAnimation(dice, BattleTurn.Player));
    }

    private IEnumerator RollDiceWithAnimation (DiceInstance dice, BattleTurn turn) {
        Debug.Log ("Rolling dice... Wait for it!");
        yield return new WaitForSeconds (1.5f);
        RollResult result = RollDice (dice, turn);
        ApplyRollResult (result);
        if (!CheckRoundState()) {
            SwitchTurn();
        }
    }

    private RollResult RollDice (DiceInstance dice, BattleTurn turn) {
        int randomIndex = Random.Range (0, dice.data.faces.Length);
        int rolledValue = dice.data.faces [randomIndex];

        RollResult result = new RollResult (dice, rolledValue, turn);
        return result;
    }

    private void ApplyRollResult (RollResult result) {
        if (result.roller == BattleTurn.Player) {
            context.playerRoundScore += result.finalValue;
            Debug.Log ("Player rolled: " + result.finalValue);
            Debug.Log ("Player total: " + context.playerRoundScore);
        } else {
            context.waifuRoundScore += result.finalValue;
            Debug.Log ("Waifu rolled: " + result.finalValue);
            Debug.Log ("Waifu total: " + context.waifuRoundScore);
        }
        
    }

    private void SwitchTurn () {
        context.currentTurn = context.currentTurn == BattleTurn.Player ? BattleTurn.Waifu : BattleTurn.Player;
        Debug.Log ("Turn switched to: " + context.currentTurn);
    }

    private bool CheckRoundState () {
        if (context.playerRoundScore > BattleContext.TargetScore) {
            ResolveRound (BattleTurn.Waifu);
            return true;
        }
        if (context.waifuRoundScore > BattleContext.TargetScore) {
            ResolveRound (BattleTurn.Player);
            return true;
        }
        return false;
    }

    private void ResolveRound (BattleTurn winner) {
        Debug.Log ("Round winner: " + winner);
        if (winner == BattleTurn.Player) {
            context.waifuCurrentHP--;
        } else {
            context.playerCurrentHP--;
        }

        Debug.Log ("Player HP: " + context.playerCurrentHP);
        Debug.Log ("Waifu HP: " + context.waifuCurrentHP);

        context.ResetRound();
        CheckBattleEnd();
    }

    private void CheckBattleEnd () {
        if (context.playerCurrentHP <= 0) {
            Debug.Log ("Waifu Wins the Duel, you lost the dice");
        } else if (context.waifuCurrentHP <= 0) {
            Debug.Log ("Player wins the Duel & some Waifu dice");
        }
    }
}
