using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{
    public ParticleSystem scrashFX;
    //public EffectSelector effectSelector;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Item")
        {
            Destroy(other.gameObject);
            var item = other.gameObject.GetComponent<ItemBuilder>();
            var effectSelector = gameObject.GetComponent<EffectSelector>();
            effectSelector.OnItemPickup(item.shootItem);
            Debug.Log("item moi ne");
        }
        else
        {
            StarCrashSequence();
        }
    }


    private void StarCrashSequence()
    {
        scrashFX.Play();
        //GetComponent<PlayerControls>().enabled= false;
        GetComponent<BoxCollider>().enabled= false;
        GetComponent<Rigidbody>().useGravity = true;
        Invoke("ReloadLevel", 1.7f);
    }

    void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
