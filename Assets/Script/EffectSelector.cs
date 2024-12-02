using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class EffectSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject effectLaser1;
    public GameObject effectLaser2;
    public Transform LaserRightPos;
    public Transform LaserLeftPos;

    public void OnItemPickup(GameObject[] getItem)
    {
        effectLaser1 = getItem[0];
        effectLaser2 = getItem[1];
    }

    void SpawnLaserSkill()
    {
        if (effectLaser1 != null && effectLaser2 !=null)
        {
            Instantiate(effectLaser1, LaserRightPos);
            Instantiate(effectLaser2, LaserLeftPos);
        }
    }
    

    // Update is called once per frame
    void Start()
    {
        SpawnLaserSkill();
    }
}
