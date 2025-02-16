using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterData", menuName = "Character Data")]
public class PlayerDataSO : ScriptableObject
{
    public string characterName;
    public float speed;
    public float attack;
    public float defense;
    public float energy;
}
