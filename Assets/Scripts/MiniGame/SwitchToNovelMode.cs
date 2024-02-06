using Naninovel;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Naninovel.Command;

[CommandAlias("novel")]
public class SwitchToNovelMode : Command
{
    public StringParameter ScriptName;
    public StringParameter Label;

    private AsyncOperation asyncLoad;


    public override async UniTask Execute(AsyncToken asyncToken)
    {
        // 1. Switch cameras.
        var advCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        advCamera.enabled = false;
        var naniCamera = Engine.GetService<ICameraManager>().Camera;
        naniCamera.enabled = true;

        // 2. Load Main scene back.
        asyncLoad = SceneManager.LoadSceneAsync("Main",LoadSceneMode.Single);

        // 3. Load and play specified script (if assigned).
        if (Assigned(ScriptName))
        {
            var scriptPlayer = Engine.GetService<IScriptPlayer>();
            await scriptPlayer.PreloadAndPlayAsync(ScriptName,0,0,Label);
        }

        // 4. Enable Naninovel input.
        var inputManager = Engine.GetService<IInputManager>();
        inputManager.ProcessInput = true;
    }


}
