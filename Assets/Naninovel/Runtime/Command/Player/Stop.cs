// Copyright 2022 ReWaffle LLC. All rights reserved.


namespace Naninovel.Commands
{
    /// <summary>
    /// Stops the naninovel script execution.
    /// </summary>
    public class Stop : Command
    {
        public override UniTask Execute (AsyncToken asyncToken = default)
        {
            Engine.GetService<IScriptPlayer>().Stop();

            return UniTask.CompletedTask;
        }
    } 
}
