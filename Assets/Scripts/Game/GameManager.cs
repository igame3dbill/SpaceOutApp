﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {

    public static GameManager INSTANCE { get; private set; }

    public event Action OnUpdateEvent;

    public TimeSpan time;

    public GuiManager guiManager;
    public Players player;
    public int currentPlayer;
    public int playerCount;

    public int currentRing;

    // Use this for initialization
    void Awake () {
        Time.timeScale = 1;
        if (INSTANCE == null)
            INSTANCE = this;
        else
            Destroy(this.gameObject);
	}
    private void Start()
    {
        currentPlayer = 1;
    }
    // Update is called once per frame
    void Update () {
        time += TimeSpan.FromSeconds(Time.deltaTime);
        if (currentPlayer > playerCount)
            currentPlayer = 1;

        if(OnUpdateEvent != null)
            OnUpdateEvent();
    }

    private void OnDestroy()
    {
        if (INSTANCE == this)
            INSTANCE = null;
    }

   

}
