using System.Drawing;
using UnityEngine;

namespace Assets
{
    internal class PaddleInitializationSettings
    {
        public PaddleInitializationSettings(string paddleInputController, Vector3 initialPosition, Vector3 offset, RectangleF worldBoundariesRectangle)
        {
            this.PaddleInputController = paddleInputController;
            this.InitialPosition = initialPosition;
            this.Offset = offset;
            this.WorldBoundariesRectangle = worldBoundariesRectangle;
        }

        public string PaddleInputController { get; }
        public Vector3 InitialPosition { get;}
        public Vector3 Offset { get; }
        public RectangleF WorldBoundariesRectangle { get; }
    }
}