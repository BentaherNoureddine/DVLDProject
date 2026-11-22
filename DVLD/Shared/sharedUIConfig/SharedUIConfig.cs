using System;

namespace Shared.sharedUIConfig
{
    public enum UIMode
    {
        ViewMode,
        EditMode,
        CreateMode
    }

    public class SharedUIConfig
    {
        public static UIMode Mode { get; }
    }
}