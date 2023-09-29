using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollower : MonoBehaviour
{
    RectTransform panel;

    [SerializeField]
    RectTransform objetivo;

    [SerializeField]
    Vector3 offset;

    private void Start()
    {
        panel = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        panel.position = objetivo.position + offset;
    }
}
