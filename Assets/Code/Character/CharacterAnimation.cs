using Code.Character;
using UnityEngine;

namespace Code.Player
{
    public class CharacterAnimation : MonoBehaviour
    {
        public Animator Animator;
        public CharacterMovement CharacterMovement;
        
        private static readonly int MoveHash = Animator.StringToHash("Walking");

        private void Update() => 
            WalkingState();

        private void WalkingState() =>
            Animator.SetFloat(MoveHash, CharacterMovement.Velocity, 0.1f, Time.deltaTime);
    }
}