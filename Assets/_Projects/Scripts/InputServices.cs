using System;
using JetpackJoyrideReplica.Core;
using UnityEngine;

namespace JetpackJoyrideReplica.Services
{
    public class InputService : IInputService, IDisposable
    {
        private readonly GameInput _gameInput;
        public bool IsFlying => _gameInput.Player.Fly.IsPressed();

        public InputService()
        {
            _gameInput = new GameInput();
            _gameInput.Player.Enable();
        }


        public void Dispose()
        {
            _gameInput.Player.Disable();
            _gameInput.Dispose();         
        }

    }

}