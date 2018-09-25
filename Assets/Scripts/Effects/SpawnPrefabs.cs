using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabs : MonoBehaviour {
    [SerializeField] GameObject ParentGameObject;
    [SerializeField] int copies;
    [SerializeField] GameObject[] prefabs;
    [SerializeField]  float delay;
    int counter = 0;
   
    void Start()
    {
        if (ParentGameObject == null)
            ParentGameObject = this.gameObject;
        //StartCoroutine(SpawnFunction());

    }
    void OnEnable()
    {
        StartCoroutine(SpawnFunction());
    }
    void OnDisable()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }


    private IEnumerator SpawnFunction ()
        {

            for (int i = 0; i <= copies; i++)
            {
            counter = i;
            StartCoroutine(SpawnDelay());
            yield return i;
             }
	    }

    private IEnumerator SpawnDelay()
    {
        StartCoroutine(SpawnThings());
        yield return new WaitForSeconds(delay);
    }
        private IEnumerator SpawnThings()
    {
            foreach (GameObject g in prefabs)
            {
                GameObject obj = Instantiate(g) as GameObject;

                //Parent a UI element to another UI element, whooo!
                obj.gameObject.GetComponent<RectTransform>().SetParent(ParentGameObject.GetComponent<RectTransform>(), false);
            yield return new WaitForSeconds(delay*counter);
        }
       
        }
    
    

}
