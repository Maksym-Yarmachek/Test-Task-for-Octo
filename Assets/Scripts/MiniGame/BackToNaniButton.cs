using Naninovel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToNaniButton : MonoBehaviour
{
    [Tooltip("Nani scripn name which will be opened after minigame")]
    public string naniScript;
    [Tooltip("Label from which <b>naniScript</b> will start")]
    public string naniLable;

    public void BackToNani()
    {
        var switchCommand = new SwitchToNovelMode { ScriptName = naniScript, Label = naniLable };
        switchCommand.Execute(new AsyncToken()).Forget();
    }
}
