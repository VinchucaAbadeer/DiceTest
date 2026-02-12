using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceInstance {

    public string uniqueID;
    public DiceData data;

    public DiceInstance (string id, DiceData diceData) {
        uniqueID = id;
        data = diceData;
    }
}
