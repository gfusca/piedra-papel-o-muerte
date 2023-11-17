using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {
    public GameObject front;
    public GameObject back;
    // original state is to show the back without revealing the card
    private bool flipped = false;
    // Start is called before the first frame update
    void Start() {
        // assing a specific card (e.g. random)
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Flipping");
            Flip();
        }
    }

    void Flip() {
        // show front on flip
        front.SetActive(!flipped);
        back.SetActive(flipped);
        flipped = !flipped;
    }
}
