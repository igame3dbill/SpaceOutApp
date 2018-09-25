using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode]
public class ResultTexts : MonoBehaviour {
    [SerializeField] GameObject gameManager;
     string message;
    public AudioClip clickSound;
    AudioSource audioSource;
    [SerializeField] GameObject textBlack;
    [SerializeField] GameObject textWhite;
    [Multiline]
    [SerializeField]  string[] messages;
   
   
    // Use this for initialization
    void OnEnable () {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clickSound;
        if (messages.Length > 0) {
            int n = Random.Range(0, messages.Length-1);
                 
            message = messages[n];
            Debug.Log(n + "," + message);
            textBlack.GetComponent<Text>().text = message;
            textWhite.GetComponent<Text>().text = message;
            audioSource.Play();
            if (message == "SpaceOut")
            {
                gameManager.GetComponent<GuiManager>().ScoreBig();
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
