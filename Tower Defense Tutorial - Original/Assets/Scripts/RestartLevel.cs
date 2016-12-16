using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Class used to handle the click of the reset button
/// </summary>
public class RestartLevel : MonoBehaviour {

    /// <summary>
    /// Re loads the level 
    /// </summary>
	public void reLoadLevel()
    {
        // Empties the list of enemies in game. 
        EnemiesInGame.allEnemiesInGame.Clear();

        // Reloads the TerrainTest scene
        SceneManager.LoadScene("TerrainTest");
        
    }
}
