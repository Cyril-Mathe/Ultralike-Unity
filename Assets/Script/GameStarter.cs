using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public MonoBehaviour[] scriptsToDisable;

    void Start()
    {
        foreach(var script in scriptsToDisable)
        {
            script.enabled = false;
        }
    }

    public void EnableGameScripts()
    {
        foreach(var script in scriptsToDisable)
        {
            script.enabled = true;
        }
    }
}