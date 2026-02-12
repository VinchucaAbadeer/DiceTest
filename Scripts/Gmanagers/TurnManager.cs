using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

    public static TurnManager instance;
    public BattleTurn CurrentTurn {get; private set;}
    public event Action<BattleTurn> OnTurnStarted;

    private void Awake () {
        if (instance == null) {
            instance = this;
        } else {
            Destroy (gameObject);
        }
    }

    public void StartTurn (BattleTurn turn) {
        CurrentTurn = turn;
        Debug.Log ("Empieza turno de: " + turn);
        OnTurnStarted?.Invoke (turn);
    }

    public void EndTurn () {
        BattleTurn nextTurn = CurrentTurn == BattleTurn.Player ? BattleTurn.Waifu : BattleTurn.Player;
        StartTurn (nextTurn);
    }

    public bool isPlayerTurn () {
        return CurrentTurn == BattleTurn.Player;
    }
}
