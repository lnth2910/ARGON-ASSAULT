using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerIndicator : MonoBehaviour
{
    public Image speedSprite;
    public Image attackSprite;
    public Image defenseSprite;
    public Image energySprite;
    private float target = 1;
    [SerializeField] private float changeSpeed;
    // Start is called before the first frame update
    public void UpdateSpeedIndicator(float speedIndex)
    {
        speedSprite.fillAmount = Mathf.MoveTowards(speedSprite.fillAmount, speedIndex, changeSpeed*Time.deltaTime);
    }

    public void UpdateAttackIndicator(float attackIndex)
    {
        attackSprite.fillAmount = Mathf.MoveTowards(attackSprite.fillAmount, attackIndex, changeSpeed * Time.deltaTime);
    }

    public void UpdateDefenseIndicator(float defenseIndex)
    {
        defenseSprite.fillAmount = Mathf.MoveTowards(defenseSprite.fillAmount, defenseIndex, changeSpeed * Time.deltaTime);
    }

    public void UpdateEnergyIndicator(float energyIndex)
    {
        energySprite.fillAmount = Mathf.MoveTowards(energySprite.fillAmount, energyIndex, changeSpeed * Time.deltaTime);
    }
}
