using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using XRpgLibrary.Controls;
using XRpgLibrary;

namespace Reflet_d_Alkyle.GameScreens
{
    public class TitleScreen : BaseGameState
    {
        SpriteBatch spriteBatch;

        #region Field region

        Texture2D backgroundImage;
        Bouton bouton1;
        Bouton bouton1s;
        bool s1 = false;


        Song TitleSong;

        #endregion

        #region Constructor region

        public TitleScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {
        }

        #endregion

        #region XNA Method region

        protected override void LoadContent()
        {
            bouton1 = new Bouton();
            bouton1s = new Bouton();

            spriteBatch = new SpriteBatch(GraphicsDevice);
            ContentManager Content = GameRef.Content;

            backgroundImage = Content.Load<Texture2D>(@"backgrounds\banniere");

            #region BOUTONS RESOLUTION
            bouton1.LoadContent(Content, "1920x1080");
            bouton1s.LoadContent(Content, "1920x1080s");
            bouton1.Position = new Vector2(100, 100);
            bouton1s.Position = bouton1.Position;
            #endregion

            TitleSong = Content.Load<Song>("Compo");

            for (int i = 0; i < 5; i++)
            {
                MediaPlayer.Play(TitleSong);
            }

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            KeyboardState keyboard = Keyboard.GetState();
            ControlManager.Update(gameTime, PlayerIndex.One);

            #region 1920 x 1080
            if ((mouse.X >= bouton1.Position.X && mouse.X <= bouton1.Position.X + 200)
                    && (mouse.Y >= bouton1.Position.Y && mouse.Y <= bouton1.Position.Y + 35))
            {
                s1 = true;
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    StateManager.PushState(GameRef.StartMenuScreen);
                }
            }
            else
                s1 = false;
            #endregion


            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(backgroundImage, Vector2.Zero, Color.White);

            if (!s1)
            {
                bouton1.Draw(spriteBatch);
            }

            #region BOUTONS SURVOLES
            if (s1)
            {
                bouton1s.Draw(spriteBatch);
            }
            #endregion



            spriteBatch.End();

            ControlManager.Draw(GameRef.SpriteBatch);
            base.Draw(gameTime);
        }

        #endregion
    }
}
