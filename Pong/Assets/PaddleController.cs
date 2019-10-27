using System;
using UnityEngine;

namespace Assets
{
    public class PaddleController : MonoBehaviour
    {
        private Vector3 _offset;

        [SerializeField]
        float Speed = 5f;
        private PaddleInitializationSettings _settings;

        // Start is called before the first frame update
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
            this.HandlePaddleMovement();
        }

        private void HandlePaddleMovement()
        {
            var move = Input.GetAxis(this._settings.PaddleInputController) * Time.deltaTime * this.Speed;

            if (Math.Abs(move) > 0.0005 && this.IsWithinWorldBoundaries(move))
            {
                this.transform.Translate(move * Vector3.up);
            }
        }

        private bool IsWithinWorldBoundaries(float move)
        {
            return this.IsWithinBoundsBottom(move) &&
                   this.IsWithinBoundTop(move);
        }

        private bool IsWithinBoundTop(float move)
        {
            return this.transform.position.y + move + this.PaddleHeight / 2 <=
                   this._settings.WorldBoundariesRectangle.Height;
        }

        private bool IsWithinBoundsBottom(float move)
        {
            return this.transform.position.y - move - this.PaddleHeight / 2 >=
                   this._settings.WorldBoundariesRectangle.Y;
        }

        internal void InitializePaddle(PaddleInitializationSettings settings)
        {
            this._settings = settings;
            this.transform.name = settings.PaddleInputController;
            this.SetPosition(settings.InitialPosition);
        }

        private void SetPosition(Vector3 position)
        {
            this.transform.position = new Vector3(position.x, position.y, 0) + this.GetOffset();
        }

        private Vector3 GetOffset()
        {
            return this._offset;
        }

        private float PaddleHeight
        {
            get { return this.transform.localScale.y; }
        }
    }
}