using UnityEngine;

namespace Inputs.Abstract
{
    public interface IInputReader
    {
        Vector3 Direction { get; }
        Vector2 MousePosition { get; }
        
        bool IsPressedLeftClick { get; }
    }
}