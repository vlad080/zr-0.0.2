using UnityEngine;

namespace Code.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        public Animator Animator;
        public PlayerMovement PlayerMovement;
        
        private static readonly int MoveHash = Animator.StringToHash("Walking");

        private void Update() => 
            WalkingState();

        private void WalkingState() =>
            Animator.SetFloat(MoveHash, PlayerMovement.Velocity, 0.1f, Time.deltaTime);
    }
}