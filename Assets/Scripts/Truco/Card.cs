using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {
    public GameObject front;
    public GameObject back;
    private Transform highlight;

    // original state is to show the back without revealing the card
    public bool flipped = false;
    bool mouseEntered = false;

    // Start is called before the first frame update
    void Start() {
        // assing a specific card (e.g. random)
        if (flipped) {
            Flip();
        }

        highlight = transform.Find("HighLight");
        if (highlight != null) {
            highlight.gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (flipped) {
            Flip();
        }

        if (mouseEntered && !highlight.gameObject.activeInHierarchy) {
            highlight.gameObject.SetActive(true);
        } else if (!mouseEntered && highlight.gameObject.activeInHierarchy) {
            highlight.gameObject.SetActive(false);
        }
    }

    void Flip() {
        // show front on flip
        front.SetActive(flipped);
        back.SetActive(!flipped);
        flipped = !flipped;
    }

    void OnMouseEnter() {
        mouseEntered = true;
        Debug.Log($"mouseEntered on card {gameObject.name}");
    }

    void OnMouseExit() {
        mouseEntered = false;
        Debug.Log($"mouseExit on card {gameObject.name}");
    }
}
