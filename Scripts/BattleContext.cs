using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleContext {

    public const int TargetScore = 17;

    public int playerCurrentHP;
    public int waifuCurrentHP;

    public int playerRoundScore;
    public int waifuRoundScore;

    public BattleTurn currentTurn;

    public List<DiceInstance> playerDiceOnTable = new ();
    public List<DiceInstance> waifuDiceOnTable = new ();

    public List<DiceInstance> playerInventory = new();
    public List<DiceInstance> waifuInventory = new();

    public WaifuDefinition waifuDefinition;

    public BattleContext (WaifuDefinition waifuDef, int playerMaxHP) {
        waifuDefinition = waifuDef;

        playerCurrentHP = playerMaxHP;
        waifuCurrentHP = waifuDef.maxHP;

        playerRoundScore = 0;
        waifuRoundScore = 0;

        currentTurn = BattleTurn.Player;
    }

    public void ResetRound() {
        playerRoundScore = 0;
        waifuRoundScore = 0;

        playerDiceOnTable.Clear ();
        waifuDiceOnTable.Clear ();

        currentTurn = BattleTurn.Player;
    }
}
