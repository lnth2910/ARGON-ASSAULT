using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class EffectSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject effectLaser;
    public GameObject laserRight;
    public GameObject laserLeft;
    public GameObject ultimateLaser;
    public Transform LaserRightPos;
    public Transform LaserLeftPos;

    public void OnItemPickup(GameObject getItem)
    {
        if (laserRight != null && laserLeft !=null )
        {
            Destroy(laserRight);
            Destroy(laserLeft);
        }
        effectLaser = getItem;
        SpawnLaserSkill();
    }

    void SpawnLaserSkill()
    {
        if (effectLaser != null)
        {
            laserRight = Instantiate(effectLaser, LaserRightPos);
            laserLeft = Instantiate(effectLaser, LaserLeftPos);
        }
    }

    

    // Update is called once per frame
    void Start()
    {
        SpawnLaserSkill();
    }
}
