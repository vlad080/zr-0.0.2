using Code.Infrastructure.Factory;

namespace Code.Infrastructure
{
    public class Game
    {
        // public static IInputService InputService;
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), new GameFactory(), curtain);
        }

       
    }
}