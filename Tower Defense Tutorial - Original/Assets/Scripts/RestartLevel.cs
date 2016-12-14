using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour {

	public void reLoadLevel()
    {
        //int scene = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(scene, LoadSceneMode.Single);
        //Time.timeScale = 1;

        // Empties the list of enemies in game. 
        EnemiesInGame.allEnemiesInGame.Clear();

        SceneManager.LoadScene("TerrainTest");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
