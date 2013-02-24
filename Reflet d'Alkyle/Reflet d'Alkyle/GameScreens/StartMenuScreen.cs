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
    public class StartMenuScreen : BaseGameState
    {
        SpriteBatch spriteBatch;

        #region XNA Field region
        int sexyviolon = 1920;
        int sexysaxo = 1080;

        public Rectangle container;

        #region -Définition des boutons-
        Bouton bNouveau;
        Texture2D nouveau;
        Bouton bBonus;
        Texture2D bonus;
        Bouton bCharger;
        Texture2D charger;
        Bouton bOptions;
        Texture2D options;
        Bouton bQuitter;
        Texture2D quitter;
        Bouton bRetour;
        Texture2D retour;
        #endregion

        #region -TIMERS-
        //A Timer variable
        float timer = 0f;
        //The interval (100 milliseconds)
        float interval = 100f;
        //Current frame holder (start at 0)
        int currentFrame = 0;

        float timer2 = 0f;
        float interval2 = 100f;
        int currentFrame2 = 0;

        float timer3 = 0f;
        float interval3 = 100f;
        int currentFrame3 = 0;

        float timer4 = 0f;
        float interval4 = 100f;
        int currentFrame4 = 0;

        float timer5 = 0f;
        float interval5 = 100f;
        int currentFrame5 = 0;
        #endregion


        #region -Définition des booléens & fond du menu & musique-

        bool survolquitter = false;
        bool selectquitter = false;
        bool survoloptions = false;
        bool selectoptions = false;
        bool survolnouveau = false;
        bool selectnouveau = false;
        bool survolbonus = false;
        bool selectbonus = false;
        bool display = true;
        bool displayopts = false;
        bool survolretour = false;
        bool selectretour = false;

        Texture2D fondMenu;

        #endregion
        #endregion

        #region Constructor Region

        public StartMenuScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {

        }

        #endregion

        #region XNA Method Region

        public override void Initialize()
        {
            #region Init des boutons
            bNouveau = new Bouton();
            bBonus = new Bouton();
            bCharger = new Bouton();
            bOptions = new Bouton();
            bQuitter = new Bouton();
            bRetour = new Bouton();
            #endregion

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ContentManager Content = GameRef.Content;

            fondMenu = Content.Load<Texture2D>(@"backgrounds\fond");

            #region BOUTONS
            nouveau = Content.Load<Texture2D>(@"nouveaujeu\0");
            bNouveau.Position = new Vector2(3 * sexyviolon / 4, sexysaxo / 10);

            charger = Content.Load<Texture2D>(@"charger\10cp");
            bCharger.Position = new Vector2(3 * sexyviolon / 4, sexysaxo / 10 + 100);

            bonus = Content.Load<Texture2D>(@"bonus\0bs"); // BONUS
            bBonus.Position = new Vector2((3 * sexyviolon / 4), sexysaxo / 10 + 200);

            options = Content.Load<Texture2D>(@"options\0op"); //OPTIONS
            bOptions.Position = new Vector2(3 * sexyviolon / 4, sexysaxo / 10 + 300);

            quitter = Content.Load<Texture2D>(@"quitter\0qt"); // QUITTER
            bQuitter.Position = new Vector2(3 * sexyviolon / 4, sexysaxo / 10 + 400);

            retour = Content.Load<Texture2D>(@"retour\0rt"); // RETOUR
            bRetour.Position = new Vector2((3 * sexyviolon / 4) - 400, sexysaxo / 10 + 300);
            #endregion

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            ControlManager.Update(gameTime, PlayerIndex.One);
            ContentManager Content = GameRef.Content;

            #region -Surbrillance & sélection-

            // Bouton Nouveau Jeu
            if ((mouse.X >= bNouveau.Position.X && mouse.X <= bNouveau.Position.X + 400)
                && (mouse.Y >= bNouveau.Position.Y && mouse.Y <= bNouveau.Position.Y + 100) && display) // sous-entendu display == true
            // si la souris rencontre le bouton, les booleens changent
            {                                                                  // ce qui draw les boutons dans la méthode Draw
                survolnouveau = true;
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    selectnouveau = true;
                    survolnouveau = false;
                }
                else
                    selectnouveau = false;
            }
            else
                survolnouveau = false;

            // Bouton Bonus
            if ((mouse.X >= bBonus.Position.X && mouse.X <= bBonus.Position.X + 400)
                && (mouse.Y >= bBonus.Position.Y && mouse.Y <= bBonus.Position.Y + 100) && display)
            {
                survolbonus = true;
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    selectbonus = true;
                    survolbonus = false;
                }
                else
                    selectbonus = false;
            }
            else
                survolbonus = false;

            // Bouton Options
            if ((mouse.X >= bOptions.Position.X && mouse.X <= bOptions.Position.X + 400)
                && (mouse.Y >= bOptions.Position.Y && mouse.Y <= bOptions.Position.Y + 100) && display)
            {
                survoloptions = true;
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    selectoptions = true;
                    survoloptions = false;                 // On désactive tous les boutons
                    display = false;                       // et on affiche les nouveaux
                    displayopts = true;
                    selectnouveau = false;
                    survolnouveau = false;
                    selectbonus = false;
                    survolbonus = false;
                    selectquitter = false;
                    survolquitter = false;
                    selectretour = false;
                }
            }

            else
                survoloptions = false;


            // Bouton Quitter
            if ((mouse.X >= bQuitter.Position.X && mouse.X <= bQuitter.Position.X + 400)
                && (mouse.Y >= bQuitter.Position.Y && mouse.Y <= bQuitter.Position.Y + 100) && display)
            {
                survolquitter = true;
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    selectquitter = true;
                    survolquitter = false;
                }
                else
                    selectquitter = false;
                
            }
            else
                survolquitter = false;

            #endregion

            #region -Boutons des options-

            // Bouton Retour
            if ((mouse.X >= bRetour.Position.X && mouse.X <= bRetour.Position.X + 400)
                    && (mouse.Y >= bRetour.Position.Y && mouse.Y <= bRetour.Position.Y + 100) && displayopts)
            {
                survolretour = true;
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    selectoptions = false;
                    selectretour = true;
                    survolretour = false;
                    displayopts = false;
                    display = true;
                }
            }
            else
                survolretour = false;

            #endregion

            #region SURVOL
            #region NOUVEAU
            if (survolnouveau)
            {
                #region TIMER
                //Increase the timer by the number of milliseconds since update was last called
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                //Check if the timer is more than the chosen interval
                if (timer > interval)
                {
                    //Show the next frame
                    currentFrame++;
                    //Reset the timer
                    timer = 0f;
                }
                //If we are on the last frame, reset back to the one before the first frame (because currentFrame++ is called next so the next frame will be 1!)
                //if (currentFrame == 11)
                //{
                //    currentFrame = 0;
                //}
                #endregion
                #region NOUVEAU
                if (currentFrame == 0)
                    nouveau = Content.Load<Texture2D>(@"nouveaujeu\0");
                else if (currentFrame == 1)
                    nouveau = Content.Load<Texture2D>(@"nouveaujeu\1");
                else if (currentFrame == 2)
                    nouveau = Content.Load<Texture2D>(@"nouveaujeu\2");
                else if (currentFrame == 3)
                    nouveau = Content.Load<Texture2D>(@"nouveaujeu\3");
                else if (currentFrame == 4)
                    nouveau = Content.Load<Texture2D>(@"nouveaujeu\4");
                else if (currentFrame == 5)
                    nouveau = Content.Load<Texture2D>(@"nouveaujeu\5");
                else if (currentFrame == 6)
                    nouveau = Content.Load<Texture2D>(@"nouveaujeu\6");
                else if (currentFrame == 7)
                    nouveau = Content.Load<Texture2D>(@"nouveaujeu\7");
                else if (currentFrame == 8)
                    nouveau = Content.Load<Texture2D>(@"nouveaujeu\8");
                else if (currentFrame == 9)
                    nouveau = Content.Load<Texture2D>(@"nouveaujeu\9");
                else if (currentFrame == 10)
                    nouveau = Content.Load<Texture2D>(@"nouveaujeu\10");
                else if (currentFrame == 11)
                    nouveau = Content.Load<Texture2D>(@"nouveaujeu\11");
                #endregion

            }
            else if (!survolnouveau)
            {
                nouveau = Content.Load<Texture2D>(@"nouveaujeu\0");
                currentFrame = 0;
            }
            #endregion
            #region OPTIONS
            if (survoloptions)
            {
                #region TIMER

                //Increase the timer by the number of milliseconds since update was last called
                timer2 += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                //Check if the timer is more than the chosen interval
                if (timer2 > interval2)
                {
                    //Show the next frame
                    currentFrame2++;
                    //Reset the timer
                    timer2 = 0f;
                }
                //If we are on the last frame, reset back to the one before the first frame (because currentFrame++ is called next so the next frame will be 1!)
                //if (currentFrame == 11)
                //{
                //    currentFrame = 0;
                //}
                #endregion
                #region OPTIONS
                if (currentFrame2 == 0)
                    options = Content.Load<Texture2D>(@"options\0op");
                else if (currentFrame2 == 1)
                    options = Content.Load<Texture2D>(@"options\1op");
                else if (currentFrame2 == 2)
                    options = Content.Load<Texture2D>(@"options\2op");
                else if (currentFrame2 == 3)
                    options = Content.Load<Texture2D>(@"options\3op");
                else if (currentFrame2 == 4)
                    options = Content.Load<Texture2D>(@"options\4op");
                else if (currentFrame2 == 5)
                    options = Content.Load<Texture2D>(@"options\5op");
                else if (currentFrame2 == 6)
                    options = Content.Load<Texture2D>(@"options\6op");
                else if (currentFrame2 == 7)
                    options = Content.Load<Texture2D>(@"options\7op");
                else if (currentFrame2 == 8)
                    options = Content.Load<Texture2D>(@"options\8op");
                else if (currentFrame2 == 9)
                    options = Content.Load<Texture2D>(@"options\9op");
                else if (currentFrame2 == 10)
                    options = Content.Load<Texture2D>(@"options\10op");
                else if (currentFrame2 == 11)
                    options = Content.Load<Texture2D>(@"options\11op");
                #endregion
            }

            else if (!survoloptions)
            {
                options = Content.Load<Texture2D>(@"options\0op");
                currentFrame2 = 0;
            }
            #endregion
            #region BONUS
            if (survolbonus)
            {
                #region TIMER

                //Increase the timer by the number of milliseconds since update was last called
                timer3 += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                //Check if the timer is more than the chosen interval
                if (timer3 > interval3)
                {
                    //Show the next frame
                    currentFrame3++;
                    //Reset the timer
                    timer3 = 0f;
                }
                //If we are on the last frame, reset back to the one before the first frame (because currentFrame++ is called next so the next frame will be 1!)
                //if (currentFrame == 11)
                //{
                //    currentFrame = 0;
                //}
                #endregion
                #region BONUS
                if (currentFrame3 == 0)
                    bonus = Content.Load<Texture2D>(@"bonus\0bs");
                else if (currentFrame3 == 1)
                    bonus = Content.Load<Texture2D>(@"bonus\1bs");
                else if (currentFrame3 == 2)
                    bonus = Content.Load<Texture2D>(@"bonus\2bs");
                else if (currentFrame3 == 3)
                    bonus = Content.Load<Texture2D>(@"bonus\3bs");
                else if (currentFrame3 == 4)
                    bonus = Content.Load<Texture2D>(@"bonus\4bs");
                else if (currentFrame3 == 5)
                    bonus = Content.Load<Texture2D>(@"bonus\5bs");
                else if (currentFrame3 == 6)
                    bonus = Content.Load<Texture2D>(@"bonus\6bs");
                else if (currentFrame3 == 7)
                    bonus = Content.Load<Texture2D>(@"bonus\7bs");
                else if (currentFrame3 == 8)
                    bonus = Content.Load<Texture2D>(@"bonus\8bs");
                else if (currentFrame3 == 9)
                    bonus = Content.Load<Texture2D>(@"bonus\9bs");
                else if (currentFrame3 == 10)
                    bonus = Content.Load<Texture2D>(@"bonus\10bs");
                else if (currentFrame3 == 11)
                    bonus = Content.Load<Texture2D>(@"bonus\11bs");
                #endregion
            }
            else if (!survolbonus)
            {
                bonus = Content.Load<Texture2D>(@"bonus\0bs");
                currentFrame3 = 0;
            }
            #endregion
            #region QUITTER
            if (survolquitter)
            {
                #region TIMER

                //Increase the timer by the number of milliseconds since update was last called
                timer4 += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                //Check if the timer is more than the chosen interval
                if (timer4 > interval4)
                {
                    //Show the next frame
                    currentFrame4++;
                    //Reset the timer
                    timer4 = 0f;
                }
                //If we are on the last frame, reset back to the one before the first frame (because currentFrame++ is called next so the next frame will be 1!)
                //if (currentFrame == 11)
                //{
                //    currentFrame = 0;
                //}
                #endregion
                #region QUITTER
                if (currentFrame4 == 0)
                    quitter = Content.Load<Texture2D>(@"quitter\0qt");
                else if (currentFrame4 == 1)
                    quitter = Content.Load<Texture2D>(@"quitter\1qt");
                else if (currentFrame4 == 2)
                    quitter = Content.Load<Texture2D>(@"quitter\2qt");
                else if (currentFrame4 == 3)
                    quitter = Content.Load<Texture2D>(@"quitter\3qt");
                else if (currentFrame4 == 4)
                    quitter = Content.Load<Texture2D>(@"quitter\4qt");
                else if (currentFrame4 == 5)
                    quitter = Content.Load<Texture2D>(@"quitter\5qt");
                else if (currentFrame4 == 6)
                    quitter = Content.Load<Texture2D>(@"quitter\6qt");
                else if (currentFrame4 == 7)
                    quitter = Content.Load<Texture2D>(@"quitter\7qt");
                else if (currentFrame4 == 8)
                    quitter = Content.Load<Texture2D>(@"quitter\8qt");
                else if (currentFrame4 == 9)
                    quitter = Content.Load<Texture2D>(@"quitter\9qt");
                else if (currentFrame4 == 10)
                    quitter = Content.Load<Texture2D>(@"quitter\10qt");
                else if (currentFrame4 == 11)
                    quitter = Content.Load<Texture2D>(@"quitter\11qt");
                #endregion
            }
            else if (!survolquitter)
            {
                quitter = Content.Load<Texture2D>(@"quitter\0qt");
                currentFrame4 = 0;
            }
            #endregion
            #region RETOUR
            if (survolretour)
            {
                #region TIMER

                //Increase the timer by the number of milliseconds since update was last called
                timer5 += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                //Check if the timer is more than the chosen interval
                if (timer5 > interval5)
                {
                    //Show the next frame
                    currentFrame5++;
                    //Reset the timer
                    timer5 = 0f;
                }
                //If we are on the last frame, reset back to the one before the first frame (because currentFrame++ is called next so the next frame will be 1!)
                //if (currentFrame == 11)
                //{
                //    currentFrame = 0;
                //}
                #endregion
                #region QUITTER
                if (currentFrame5 == 0)
                    retour = Content.Load<Texture2D>(@"retour\0rt");
                else if (currentFrame5 == 1)
                    retour = Content.Load<Texture2D>(@"retour\1rt");
                else if (currentFrame5 == 2)
                    retour = Content.Load<Texture2D>(@"retour\2rt");
                else if (currentFrame5 == 3)
                    retour = Content.Load<Texture2D>(@"retour\3rt");
                else if (currentFrame5 == 4)
                    retour = Content.Load<Texture2D>(@"retour\4rt");
                else if (currentFrame5 == 5)
                    retour = Content.Load<Texture2D>(@"retour\5rt");
                else if (currentFrame5 == 6)
                    retour = Content.Load<Texture2D>(@"retour\6rt");
                else if (currentFrame5 == 7)
                    retour = Content.Load<Texture2D>(@"retour\7rt");
                else if (currentFrame5 == 8)
                    retour = Content.Load<Texture2D>(@"retour\8rt");
                else if (currentFrame5 == 9)
                    retour = Content.Load<Texture2D>(@"retour\9rt");
                else if (currentFrame5 == 10)
                    retour = Content.Load<Texture2D>(@"retour\10rt");
                else if (currentFrame5 == 11)
                    retour = Content.Load<Texture2D>(@"retour\11rt");
                #endregion
            }
            else if (!survolretour)
            {
                retour = Content.Load<Texture2D>(@"retour\0rt");
                currentFrame5 = 0;
            }
            #endregion
            #endregion


            #endregion

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(fondMenu, Vector2.Zero, Color.White);

            #region -Affichage général-
            if (display)
            {
                spriteBatch.Draw(nouveau, bNouveau.Position, Color.White);
                spriteBatch.Draw(charger, bCharger.Position, Color.White);
                spriteBatch.Draw(options, bOptions.Position, Color.White);
                spriteBatch.Draw(bonus, bBonus.Position, Color.White);
                spriteBatch.Draw(quitter, bQuitter.Position, Color.White);
            }
            if (displayopts)
            {
                spriteBatch.Draw(retour, bRetour.Position, Color.White);
            }
            #endregion

            #region -Affichage des boutons survolés et sélectionnés du menu-

            if (selectnouveau)
            {
                MediaPlayer.Stop();
                StateManager.PushState(GameRef.GameScreen);
            }

            if (selectbonus)   // Même principe pour les suivants, le but est de gérer les affichages successifs des boutons en fonction de "Options"
            {
                spriteBatch.Draw(bonus, bBonus.Position, Color.White);
            }

            if (selectoptions && selectretour != true)
            {
                spriteBatch.Draw(options, bOptions.Position, Color.White);
            }

            if (selectquitter)
            {
                spriteBatch.Draw(quitter, bQuitter.Position, Color.White);
                Game.Exit(); // Quitte le jeu si cliqué
            }
            #endregion

            #region -Affichage des boutons après le clic sur le bouton options-

            if (selectretour && selectoptions != true)
            {
                spriteBatch.Draw(options, bOptions.Position, Color.White);
            }

            #endregion

            spriteBatch.End();

            ControlManager.Draw(GameRef.SpriteBatch);

            base.Draw(gameTime);
        }
    }
}