using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviourSingleton
{
    [SerializeField] float bgScrollSpeed = 0.4f;
    Material material;
    Vector2 offset;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
        offset = new Vector2(0, bgScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
