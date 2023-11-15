using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcInteraction : MonoBehaviour {
    public GameObject label; 
    private bool playerEntered = false;
    public GameObject dialogueBox;
    public string[] dialogueLines;

    void Start() {
        label.GetComponent<Renderer>().enabled = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.E) && playerEntered) {
            dialogueBox.GetComponent<Dialogue>().StartDialogue(dialogueLines);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("OnCollisionEnter2D");
        playerEntered = collision.gameObject.name.Equals("Player");
        label.GetComponent<Renderer>().enabled = playerEntered;
    }

    void OnCollisionExit2D(Collision2D collision) {
        playerEntered = !collision.gameObject.name.Equals("Player");
        label.GetComponent<Renderer>().enabled = playerEntered;
    }
}
