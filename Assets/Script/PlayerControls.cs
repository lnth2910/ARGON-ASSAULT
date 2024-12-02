using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("General Setup Setting")]
    [Tooltip("How fast ship moves up and down upon player input")]
    [SerializeField] float controlSpeed = 5.0f;
    [SerializeField] float xRange = 4.0f;
    [SerializeField] float yRange = 2.5f;

    [Header("Screen position based tuning")]
    [SerializeField] float positionPitchFactor = -0.2f;
    [SerializeField] float positionYawFactor = -0.2f;

    [Header("Player input based tuning")]
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -20f;

    [Header("Laser gun array")]
    [Tooltip("Add all player lasers here")]
    //[SerializeField] GameObject[] lasers;

    public Transform modelTransform;
    private EffectSelector effectSelector;
    private bool isPlay = false;

    float xThrow, yThrow;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranlation();
        ProcessRotation();
        ProcessFiring();
    }

    private void ProcessRotation()
    {
        float pitch=modelTransform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = modelTransform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        modelTransform.localRotation = Quaternion.Euler(pitch, yaw, roll);
       
        //Debug.Log(yaw);
    }

    private void ProcessTranlation()
    {
        xThrow = Input.GetAxis("Horizontal");
        //Debug.Log(xThrow);
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float newXPos = modelTransform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(newXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float newYPos = modelTransform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(newYPos, -yRange, yRange);

        modelTransform.localPosition = new Vector3(clampedXPos, clampedYPos, modelTransform.localPosition.z);
    }

    private void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            if (isPlay == false) 
            {
                SetLaserActive(true);
            }            
        }
        else
        {
            if(isPlay == true) 
            {
                SetLaserActive(false);
            }
            
        }
    }

    private void SetLaserActive(bool isActive)
    {
        //foreach(GameObject laser in lasers)
        //{
        //     var emissionModule = laser.GetComponent<ParticleSystem>().emission;
        //     emissionModule.enabled = isActive;
        //}
        if (isActive == true)
        {
            
            PlayVfx(effectSelector.effectLaser1);
            PlayVfx(effectSelector.effectLaser2);
            Debug.Log(effectSelector.effectLaser1.GetType());
        }
        else
        {
            StopVfx(effectSelector.effectLaser1);
            StopVfx(effectSelector.effectLaser2);   
        }
        
        
    }

    public void PlayVfx(GameObject obj)
    {
        
        //GameObject obj = GameObject.Find(name); // Look up the object in the scene
        if (obj != null)
        {
            var allParticle = obj.GetComponentsInChildren<ParticleSystem>();
            isPlay=true;
            foreach (var par in allParticle)
            {
                par.Play();
                Debug.Log(par.name + par.GetType());
            }
        }
    }

    public void StopVfx(GameObject obj)
    {
        //GameObject obj = GameObject.Find(name); // Look up the object in the scene
        if (obj != null)
        {
            var allParticle = obj.GetComponentsInChildren<ParticleSystem>();
            isPlay=false;   
            foreach (var par in allParticle)
            {
                par.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            }
        }

    }

    public void SetModelConfig(GameObject obj)
    {
        effectSelector = obj.GetComponent<EffectSelector>();
    }

}
