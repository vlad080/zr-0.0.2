using System;
using Code.Infrastructure;
using Code.Services.Input;
using UnityEngine;

namespace Code.Player
{
    public class MouseLook : MonoBehaviour
    {
    
        public float MouseSensitivity = 100f;
        public Transform PlayerBody;
        private float _xRotation = 0f;
        private IInputService _inputService;

        private void Awake()
        {
          //  _inputService = Game.InputService;
        }

        private void Start()
        {
           // Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
          //  float mouseX = _inputService.RightAxis.X * MouseSensitivity * Time.deltaTime;
          //  float mouseY = _inputService.RightAxis.Y * MouseSensitivity * Time.deltaTime;
//
          //  _xRotation -= mouseY;
          //  _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
//
          //  transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
//
          //  PlayerBody.Rotate(Vector3.up * mouseX);
        }
    }
}