// Copyright 2022 ReWaffle LLC. All rights reserved.


namespace Naninovel.Commands
{
    /// <summary>
    /// Removes all the messages from [printer backlog](/guide/text-printers.md#printer-backlog).
    /// </summary>
    public class ClearBacklog : Command
    {
        public override UniTask Execute (AsyncToken asyncToken = default)
        {
            Engine.GetService<IUIManager>()?.GetUI<UI.IBacklogUI>()?.Clear();
            return UniTask.CompletedTask;
        }
    }
}
