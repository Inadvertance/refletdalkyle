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

using XRpgLibrary;
using Reflet_d_Alkyle.GameScreens;

namespace Reflet_d_Alkyle
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region XNA Field Region

        GraphicsDeviceManager graphics;
        public SpriteBatch SpriteBatch;

        int sexyviolon { get; set; }
        int sexysaxo { get; set; }

        #endregion

        #region Game State Region

        GameStateManager stateManager;

        public TitleScreen TitleScreen;
        public StartMenuScreen StartMenuScreen;
        public StartMenuScreen2 StartMenuScreen2;
        public StartMenuScreen3 StartMenuScreen3;
        public StartMenuScreen4 StartMenuScreen4;
        public PauseMenuScreen PauseMenuScreen;
        public GameScreen GameScreen;

        #endregion



        public Rectangle ScreenRectangle { get; set; }
        public Rectangle rect { get; set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            rect = new Rectangle(0, 0, 1280, 720);
            ScreenRectangle = new Rectangle(0, 0, 1920, 1080);

            Content.RootDirectory = "Content";

            Components.Add(new InputHandler(this));

            stateManager = new GameStateManager(this);
            Components.Add(stateManager);

            TitleScreen = new TitleScreen(this, stateManager);
            StartMenuScreen = new GameScreens.StartMenuScreen(this, stateManager);
            GameScreen = new GameScreens.GameScreen(this, stateManager);
            PauseMenuScreen = new GameScreens.PauseMenuScreen(this, stateManager);


            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            

            stateManager.ChangeState(TitleScreen);

            this.graphics.IsFullScreen = true;
            Window.Title = "Reflet d'Alkyle";
            this.IsMouseVisible = true;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void Initialize()
        {
            base.Initialize();

        }
        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            MouseState mouse = Mouse.GetState();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}
