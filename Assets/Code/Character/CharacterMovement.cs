using Code.CameraLogic;
using Code.Data;
using Code.Services.Input;
using Code.Services.PersistentProgress.SaveLoad;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Character
{
    public class CharacterMovement : MonoBehaviour, ISavedProgress
    {
        public CharacterController CharacterController;
        [SerializeField] private float CharacterSpeed;
        public float Velocity;
        private IInputService _inputService;
        private Camera _camera;
        private float _turnSmoothVelocity;
        private const float TURN_SMOOTH_TIME = 0.1f;

        public void Construct(IInputService inputService) =>
            _inputService = inputService;

        private void Start()
        {
            _camera = Camera.main;
            CameraFollow();
        }

        private void Update() =>
            Move();

        private void CameraFollow() =>
            _camera.GetComponent<CameraFollow>().Follow(gameObject);

        private void Move()
        {
            float horizontalAxis = _inputService.LeftAxis.X;
            float verticalAxis = _inputService.LeftAxis.Z;

            Vector3 direction = new Vector3(-horizontalAxis, 0.0f, -verticalAxis).normalized;
            Velocity = direction.magnitude;
            Debug.Log("magnitude " + direction.magnitude);
            if (!(direction.magnitude >= 0.1f)) return;

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity,
                TURN_SMOOTH_TIME);
            transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);

            CharacterController.Move(direction * CharacterSpeed * Time.deltaTime);
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.WorldData.PositionOnLevel =
                new PositionOnLevel(CurrentScene(), transform.position.ConvertToVector3Data());
        }

        public void LoadProgress(PlayerProgress progress)
        {
            if (CurrentScene() == progress.WorldData.PositionOnLevel.Level
                && progress.WorldData.PositionOnLevel.Position != null)
            {
                Vector3Data savedPosition = progress.WorldData.PositionOnLevel.Position;
                Reposition(savedPosition);
            }
        }

        private void Reposition(Vector3Data savedPosition)
        {
            CharacterController.enabled = false;
            transform.position = savedPosition.ConvertToUnityVector();
            CharacterController.enabled = true;
        }

        private static string CurrentScene() =>
            SceneManager.GetActiveScene().name;
    }
}