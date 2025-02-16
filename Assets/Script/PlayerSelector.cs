using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerSelector : MonoBehaviour
{
    public List<GameObject> playerPrefabs; // Danh sách các prefab của nhân vật
    public List<GameObject> playerUltimate; //Danh sach cac ulti cua nhan vat
    private GameObject currentPlayer;
    [SerializeField] private GameObject playTimeline;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject guiManager;
    public List<PlayerDataSO> playerData;
    public PlayerIndicator playerIndicator;
    public EffectSelector ultiItem;
    private int playerIndex = 0;

    [SerializeField] private PlayerControls playerControls;

    public TMP_Text playerName;
    public TMP_Text health;
    public TMP_Text attackPower;
    // Start is called before the first frame update

    public void SelecUltimate(int ultiIndex)
    {
        ultiItem = currentPlayer.GetComponent<EffectSelector>();
        ultiItem.ultimateLaser = playerUltimate[ultiIndex];
        Debug.Log("op" + ultiIndex);
    }

    public void NextPlayer()
    {
        Destroy(currentPlayer);
        playerIndex++;
        if(playerIndex == playerPrefabs.Count)
        {
            playerIndex = 0;
        }
        SpawnPlayer();
    }

    public void PreviousPlayer()
    {
        Destroy(currentPlayer);
        playerIndex--;
        if(playerIndex < 0)
        {
            playerIndex = (playerPrefabs.Count -1);
        }
        SpawnPlayer();
    }

    public void DisplayPlayerData()
    {
        playerName.text = playerData[playerIndex].characterName;
        playerIndicator.UpdateSpeedIndicator((playerData[playerIndex].speed) / 100);
        playerIndicator.UpdateAttackIndicator((playerData[playerIndex].attack) / 100);
        playerIndicator.UpdateDefenseIndicator((playerData[playerIndex].defense) / 100);
        playerIndicator.UpdateEnergyIndicator((playerData[playerIndex].defense) / 100);
    }

    public void SpawnPlayer()
    {
        currentPlayer = Instantiate(playerPrefabs[playerIndex], playerTransform);
        currentPlayer.transform.localPosition = Vector3.zero;
        //currentPlayer.transform.SetParent(null);
        playerControls.SetModelConfig(currentPlayer);
        DisplayPlayerData();
    }

    public void PlayGame()
    {
        playTimeline.SetActive(true);
        guiManager.SetActive(false);
        UIManager.Instance.ShowPauseButton(true);
    }

    
    void Start()
    {
        SpawnPlayer();
        UIManager.Instance.ShowPauseButton(false);
    }

    // Update is called once per frame
    void Update()
    {
        DisplayPlayerData();
    }
}
