using Naninovel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Naninovel.Command;

[CommandAlias("minigame")]
public class SwitchToAdventureMode : Command
{
    public async override UniTask Execute(AsyncToken asyncToken)
    {
        // 1. Disable Naninovel input.
        var inputManager = Engine.GetService<IInputManager>();
        inputManager.ProcessInput = false;

        // 2. Stop script player.
        var scriptPlayer = Engine.GetService<IScriptPlayer>();
        scriptPlayer.Stop();

        // 3. Load minigame
        await SceneManager.LoadSceneAsync("Demo", LoadSceneMode.Single);


        // 4. Switch cameras.
        var advCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        advCamera.enabled = true;
        var naniCamera = Engine.GetService<ICameraManager>().Camera;
        naniCamera.enabled = false;

    }
}
