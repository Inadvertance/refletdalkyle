using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text;

namespace Reflet_d_Alkyle
{
    public class Sprite
    {
        public Texture2D Texture
        {
            get { return _texture; }
            set { _texture = value; }
        }
        private Texture2D _texture;

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }
        private Vector2 _position;

        public Vector2 Direction
        {
            get { return _direction; }
            set { _direction = Vector2.Normalize(value); }
        }
        private Vector2 _direction;

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        private float _speed;

        public virtual void Initialize()
        {
            _position = Vector2.Zero;
            _direction = Vector2.Zero;
            _speed = 0;
        }

        protected Rectangle _rectangle;

        public Rectangle Rectangle
        {
            get { return _rectangle; }
            set { _rectangle = value; }
        }

        public virtual void LoadContent(ContentManager content, string assetName)
        {
            _texture = content.Load<Texture2D>(assetName);
            _rectangle = new Rectangle(
              (int)_position.X,
              (int)_position.Y,
              (int)_texture.Width,
              (int)_texture.Height);
        }

        public virtual void Update(GameTime gameTime)
        {
            _rectangle = new Rectangle(
        (int)_position.X,
        (int)_position.Y,
        (int)_texture.Width,
        (int)_texture.Height);
        }

        public virtual void HandleInput(KeyboardState keyboardState, MouseState mouseState)
        { }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(_texture, _position, Color.White);
        }
    }
}
