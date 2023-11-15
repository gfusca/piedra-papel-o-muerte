using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour {
    public GameObject door;
    private bool doorOpened = false;

    // Start is called before the first frame update
    void Start() {
        door.GetComponent<Renderer>().enabled = false;
        door.GetComponent<Animator>().enabled = false;
    }

    // Called on every object colliding with object
    void OnCollisionEnter2D(Collision2D collision) {
        doorOpened = collision.gameObject.name.Equals("Player");
        door.GetComponent<Renderer>().enabled = doorOpened;
        door.GetComponent<Animator>().enabled = doorOpened;
        Debug.Log("door finished!");
        MainWorldSceneManager.GetInstance().LoadScene("MarketBuildingScene");
    }

    // Called on every object that leaves the collide area
    void OnCollisionExit2D(Collision2D collision) {
        doorOpened = !collision.gameObject.name.Equals("Player");
        door.GetComponent<Renderer>().enabled = doorOpened;
        door.GetComponent<Animator>().enabled = doorOpened;
    }
}
