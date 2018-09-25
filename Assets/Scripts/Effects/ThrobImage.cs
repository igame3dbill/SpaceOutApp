using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrobImage : MonoBehaviour {

    Transform transform;
    [SerializeField] float minSize;
    [SerializeField] float maxSize;
    float currentSize;
    [SerializeField] float frequency;
    // Use this for initialization
    void Start()
    {
        transform = GetComponent<Transform>();
        minSize = transform.localScale.x;
        currentSize = minSize;

        if (maxSize <=0)
        maxSize = transform.localScale.x + 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        currentSize = currentSize + frequency;
        if (currentSize >= maxSize || currentSize <= minSize)
            frequency = frequency * -1;
   ;

        transform.localScale = new Vector3( currentSize,  currentSize);
    }
}
