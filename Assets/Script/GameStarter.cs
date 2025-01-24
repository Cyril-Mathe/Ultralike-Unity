using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public MonoBehaviour[] scriptsToDisable;

    void Start()
    {
        Time.timeScale = 0f; // Pause le jeu au démarrage
        foreach (var script in scriptsToDisable)
        {
            script.enabled = false;
        }
    }

    public void EnableGameScripts()
    {
        Time.timeScale = 1f; // Reprend le jeu
        foreach (var script in scriptsToDisable)
        {
            script.enabled = true;
        }
    }
}