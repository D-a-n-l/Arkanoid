namespace MiniIT.Enums
{
    public enum ScreenSide
    {
        /// <summary>Top screen side</summary>
        Top = 0,
        /// <summary>Bottom screen side</summary>
        Bottom = 1,
        /// <summary>Right screen side</summary>
        Right = 2,
        /// <summary>Left screen side</summary>
        Left = 3,
    }

    public enum TypeAudioSource
    {
        /// <summary>Source for Sound audio</summary>
        Sound = 0,
        /// <summary>Source for UI audio</summary>
        UI = 1,
    }

    public enum WorkingModeCamera
    {
        /// <summary>This mode keeps camera height</summary>
        ConstantHeight,
        /// <summary>This mode keeps camera width</summary>
        ConstantWidth,
        /// <summary>This mode requires you to set Match value</summary>
        MatchWidthOrHeight,
        /// <summary>This mode always keeps area within ReferenceResolution visible at the screen</summary>
        Expand,
        /// <summary>This mode never allows area outside ReferenceResolution visible at the screen</summary>
        Shrink,
    }
}