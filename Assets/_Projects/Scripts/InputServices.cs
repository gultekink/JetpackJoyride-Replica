using System;
using JetpackJoyrideReplica.Core;
using UnityEngine;

namespace JetpackJoyrideReplica.Services
{
    public class InputService : IInputServices, IDisposable
    {
        private readonly GameInput _gameInput;
        public bool isFlying => _gameInput.Player.Fly.IsPressed();

        public InputService()
        {
            _gameInput = new GameInput();
            _gameInput.Player.Enable();
        }


        public void Dispose()
        {
            _gameInput?.Dispose();
            _gameInput.Player.Disable();
        }

    }

}