using UnityEngine;

namespace Player.Abstract
{
    public interface IMover
    {
        void MoveAction(Vector3 Direction, float moveSpeed);
        void RotateAction(Vector2 Direction);
    }
}
