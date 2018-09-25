using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollHorizontal : MonoBehaviour {

	Transform transform;
    float startx;
    [SerializeField]  float minDistance;
    [SerializeField] float maxDistance;
    [SerializeField] float currentDistance;
    [SerializeField] float scrollSpeed = .001f;
    [SerializeField] GameObject source;
    // Use this for initialization
    void Start()
    {
        transform = source.GetComponent<Transform>();
        startx = transform.position.x;
        if (maxDistance <= 0)
            minDistance = transform.localScale.x /4;
        if (maxDistance <= 0)
            maxDistance = transform.localScale.x / 2;
        currentDistance = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentDistance = transform.position.x - startx; 
        
        if (currentDistance >= maxDistance || currentDistance <= minDistance)
            scrollSpeed = scrollSpeed * -1;
        
        //thisTransform.position += scrollSpeed * Time.deltaTime;//
        transform.Translate(Vector3.right * scrollSpeed, Space.Self);
    }
}
