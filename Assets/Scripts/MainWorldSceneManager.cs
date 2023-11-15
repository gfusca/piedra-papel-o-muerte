using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// class to manage world and scene transitions
public class MainWorldSceneManager {
    public GameObject player;
    // TODO: define world state (info needed to share)
    public WorldState worldState;
    private static readonly MainWorldSceneManager instance = new MainWorldSceneManager();

    static MainWorldSceneManager() {}

    private MainWorldSceneManager() {
        worldState = new WorldState();
    }

    public static MainWorldSceneManager GetInstance() {
            return instance;
    }

    public void LoadScene(string sceneName) {
        Debug.Log("loading Scene");
        Debug.Log(sceneName);
        // TODO: add coroutine to set a delay before loading the scene and let the animation plays
        SceneManager.LoadScene(sceneName);
    }

    public WorldState GetWorldState() {
        return worldState;
    }

}
