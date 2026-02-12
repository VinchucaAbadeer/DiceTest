using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DiceEffectData : ScriptableObject {

    public string effectName;
    public abstract void ApplyEffect (BattleContext context, RollResult result);
}
