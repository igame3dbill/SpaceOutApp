using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GuiManager : MonoBehaviour {

    
    [SerializeField] GameObject gameOverPanel;
    bool gameOver;
    float deltaTime = 0.0f;
    GameObject gui;
    public bool HasOpenGui { get; private set; }
    [SerializeField]
    GameObject mainMenu;
    [SerializeField]
    GameObject activeGameplay;
    [SerializeField]
    GameObject numberOfPlayers;
    [SerializeField]
    GameObject ringButtons;
    [SerializeField]
    GameObject gameButtons;
    [SerializeField]
    GameObject scoreBig;
    [SerializeField]
    GameObject PlanetButtonResults;
    [SerializeField]
    GameObject VoidButtonResults;
    [SerializeField]
    GameObject ShipButtonResults;
    [SerializeField]
    GameObject[] planetResults;
    [SerializeField]
    GameObject[] voidResults;
    [SerializeField]
    GameObject[] shipResults;

    GameManager gameManager;
    void Start () {
        mainMenu.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        HasOpenGui = gui != null;
        if (!gameOver && HasOpenGui && Input.GetButtonDown("Cancel"))
            CloseGui();
    }

    public void OpenGui(GameObject ui)
    { 
      if (ui.gameObject.tag == "ScoreBig"){
            activeGameplay.SetActive(false);
        }

        gui = ui;
        gui.SetActive(true);
        Time.timeScale = 0;
    }
    public void PlayerCountPicked(int playerCount)
    {
        GetComponent<GameManager>().playerCount = playerCount;
        numberOfPlayers.SetActive(false);
        OpenGui(ringButtons);
        
    }

   
    public void RingPicked(int ringNumber)
    {
        GetComponent<GameManager>().currentRing = ringNumber;
        ringButtons.SetActive(false);
        OpenGui(gameButtons);   
    }


    public void NumberOfPlayers()
    {
        mainMenu.SetActive(false);
        OpenGui(activeGameplay);  
        OpenGui(numberOfPlayers);
    }
    void clearResults()
    {
        planetResults[this.GetComponent<GameManager>().currentRing - 1].SetActive(false);
        voidResults[this.GetComponent<GameManager>().currentRing - 1].SetActive(false);
        shipResults[this.GetComponent<GameManager>().currentRing - 1].SetActive(false);
    }
    public void ScoreBig()
    {
        mainMenu.SetActive(false);
        activeGameplay.SetActive(false);
        gameButtons.SetActive(false);
        clearResults();
        scoreBig.SetActive(true);    
    }

    public void PlanetResults()
    {
        gameButtons.SetActive(false);
       
        planetResults[this.GetComponent<GameManager>().currentRing - 1].SetActive(true);
        //PlanetButtonResults.SetActive(true);
        GetComponent<GameManager>().currentPlayer++;
    }

    public void VoidResults()
    {
        gameButtons.SetActive(false);
        voidResults[this.GetComponent<GameManager>().currentRing - 1].SetActive(true);
        GetComponent<GameManager>().currentPlayer++;
    }

    public void ShipResults()
    {
        gameButtons.SetActive(false);
     
        shipResults[this.GetComponent<GameManager>().currentRing - 1].SetActive(true);
        GetComponent<GameManager>().currentPlayer++;
    }

    public void BackToGame()
    {
        scoreBig.SetActive(false);
        activeGameplay.SetActive(true);
        clearResults();
        OpenGui(ringButtons);
    }

    public void GameOver()
    {
        
        gameOver = true;
        OpenGui(gameOverPanel);
    }
    void CloseGui()
    {
        activeGameplay.SetActive(true);
        gui.SetActive(false);
        Time.timeScale = 1;
        gui = null;
    }

    
}
