using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Respawn : MonoBehaviour {

    public GameObject script;

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }

    public void ResetAll() {
        RestartGame();
        script.GetComponent<ItemSpawn>().ResetAll();
    }

}