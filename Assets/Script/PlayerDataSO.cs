using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterData", menuName = "Character Data")]
public class PlayerDataSO : ScriptableObject
{
    public string characterName;
    public int health;
    public int attackPower;
}
