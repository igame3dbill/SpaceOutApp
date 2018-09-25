using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RingClicks : MonoBehaviour {
  
    public void OnClick()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(name);
    }
}
