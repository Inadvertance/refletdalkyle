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
    public class PauseMenuScreen : BaseGameState
    {

        SpriteBatch spriteBatch;

        #region XNA Field Region
        int sexyviolon = 800; //Many things
        int sexysaxo = 600;

        public Rectangle container; //?

        Bouton ReprendreJeu; //Boutons
        Bouton OptionsPause;
        Bouton QuitterJeu;
        Texture2D ReprendreJeut;
        Texture2D OptionsPauset;
        Texture2D QuitterJeut;

        float timerRP = 0f; //Animation
        float interval = 100f;
        int frameRP = 0;
        float timerOP = 0f;
        float interval2 = 100f;
        int frameOP = 0;
        float timerQJ = 0f;
        float interval3 = 100f;
        int frameQJ = 0;

        bool RPsurvol = false; //Booléens
        bool RPselect = false;
        bool OPsurvol = false;
        bool OPselect = false;
        bool QJsurvol = false;
        bool QJselect = false;
        
        #endregion

        #region Constructor Region

        public PauseMenuScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {

        }

        #endregion

        #region XNA Method Region

        public override void Initialize()
        {
            ReprendreJeu = new Bouton(); //Useless bidule
            OptionsPause = new Bouton();
            QuitterJeu = new Bouton();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice); //Bourdel
            ContentManager Content = GameRef.Content;

            ReprendreJeut = Content.Load<Texture2D>(@"reprendre\0rj"); //Reprendre jeu
            ReprendreJeu.Position = new Vector2(sexyviolon / 2, 2 * sexysaxo / 5);

            OptionsPauset = Content.Load<Texture2D>(@"options\0op"); //Options
            OptionsPause.Position = new Vector2(sexyviolon / 2, 3 * sexysaxo / 5);

            QuitterJeut = Content.Load<Texture2D>(@"quitter\0qt"); //Quitter le jeu
            QuitterJeu.Position = new Vector2(sexyviolon / 2, 4 * sexysaxo / 5);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            #region Première partie
            KeyboardState keyboard = Keyboard.GetState(); //Bourdel \o/
            MouseState mouse = Mouse.GetState();
            ControlManager.Update(gameTime, PlayerIndex.One);
            ContentManager Content = GameRef.Content;

            if ((mouse.X >= ReprendreJeu.Position.X && mouse.X <= ReprendreJeu.Position.X + 400)
                && (mouse.Y >= ReprendreJeu.Position.Y && mouse.Y <= ReprendreJeu.Position.Y + 100))
            {
                RPsurvol = true;
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    RPselect = true;
                    RPsurvol = false;
                    StateManager.PopState();
                }
                else
                    RPselect = false;
            }
            else
                RPsurvol = false;

            if ((mouse.X >= OptionsPause.Position.X && mouse.X <= OptionsPause.Position.X + 400)
                && (mouse.Y >= OptionsPause.Position.Y && mouse.Y <= OptionsPause.Position.Y + 100))
            {
                OPsurvol = true;
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    OPsurvol = false;
                    OPselect = true;
                }
                else
                    OPselect = false;   
            }
            else
                OPsurvol = false;

            if ((mouse.X >= QuitterJeu.Position.X && mouse.X <= QuitterJeu.Position.X + 400)
                && (mouse.Y >= QuitterJeu.Position.Y && mouse.Y <= QuitterJeu.Position.Y + 100))
            {
                QJsurvol = true;
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    QJsurvol = false;
                    QJselect = true;
                    Game.Exit();
                }
                else
                    QJselect = false;
            }
            else
                QJsurvol = false;
            #endregion

            #region Animation
            #region Reprendre Jeu

            if (RPsurvol)
            {
                timerRP += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (timerRP > interval)
                {
                    frameRP++;
                    timerRP = 0f;
                }

                #region BORDELOMFFFGGG
                if (frameRP == 0)
                    ReprendreJeut = Content.Load<Texture2D>(@"reprendre\0rj");
                else if (frameRP == 1)
                    ReprendreJeut = Content.Load<Texture2D>(@"reprendre\1rj");
                else if (frameRP == 2)
                    ReprendreJeut = Content.Load<Texture2D>(@"reprendre\2rj");
                else if (frameRP == 3)
                    ReprendreJeut = Content.Load<Texture2D>(@"reprendre\3rj");
                else if (frameRP == 4)
                    ReprendreJeut = Content.Load<Texture2D>(@"reprendre\4rj");
                else if (frameRP == 5)
                    ReprendreJeut = Content.Load<Texture2D>(@"reprendre\5rj");
                else if (frameRP == 6)
                    ReprendreJeut = Content.Load<Texture2D>(@"reprendre\6rj");
                else if (frameRP == 7)
                    ReprendreJeut = Content.Load<Texture2D>(@"reprendre\7rj");
                else if (frameRP == 8)
                    ReprendreJeut = Content.Load<Texture2D>(@"reprendre\8rj");
                else if (frameRP == 9)
                    ReprendreJeut = Content.Load<Texture2D>(@"reprendre\9rj");
                else if (frameRP == 10)
                    ReprendreJeut = Content.Load<Texture2D>(@"reprendre\10rj");
                else if (frameRP == 11)
                    ReprendreJeut = Content.Load<Texture2D>(@"reprendre\11rj");

                #endregion
            }
            else if (!RPsurvol)
            {
                ReprendreJeut = Content.Load<Texture2D>(@"reprendre\0rj");
                frameRP = 0;
            }
            #endregion
            #region Options
            if(OPsurvol)
            {
                timerOP += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if(timerOP > interval2)
                {
                    frameOP++;
                    timerOP = 0f;
                }

             #region OMFG
                if (frameOP == 0)
                    OptionsPauset = Content.Load<Texture2D>(@"options\0op");
                else if (frameRP == 1)
                    OptionsPauset = Content.Load<Texture2D>(@"options\1op");
                else if (frameRP == 2)
                    OptionsPauset = Content.Load<Texture2D>(@"options\2op");
                else if (frameRP == 3)
                    OptionsPauset = Content.Load<Texture2D>(@"options\3op");
                else if (frameRP == 4)
                    OptionsPauset = Content.Load<Texture2D>(@"options\4op");
                else if (frameRP == 5)
                    OptionsPauset = Content.Load<Texture2D>(@"options\5op");
                else if (frameRP == 6)
                    OptionsPauset = Content.Load<Texture2D>(@"options\6op");
                else if (frameRP == 7)
                    OptionsPauset = Content.Load<Texture2D>(@"options\7op");
                else if (frameRP == 8)
                    OptionsPauset = Content.Load<Texture2D>(@"options\8op");
                else if (frameRP == 9)
                    OptionsPauset = Content.Load<Texture2D>(@"options\9op");
                else if (frameRP == 10)
                    OptionsPauset = Content.Load<Texture2D>(@"options\10op");
                else if (frameRP == 11)
                    OptionsPauset = Content.Load<Texture2D>(@"options\11op");
             #endregion
            }
            else if(!OPsurvol)
            {
                OptionsPauset = Content.Load<Texture2D>(@"options\0op");
                frameOP = 0;
            }
            #endregion


            #endregion

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AliceBlue);

            spriteBatch.Begin();
            
                spriteBatch.Draw(ReprendreJeut, ReprendreJeu.Position, Color.White);
                spriteBatch.Draw(OptionsPauset, OptionsPause.Position, Color.White);
                spriteBatch.Draw(QuitterJeut, QuitterJeu.Position, Color.White);

            spriteBatch.End();
            ControlManager.Draw(GameRef.SpriteBatch);

            base.Draw(gameTime);
        }

        #endregion


    }
}
