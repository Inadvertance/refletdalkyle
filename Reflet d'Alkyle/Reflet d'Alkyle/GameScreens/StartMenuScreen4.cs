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
    public class StartMenuScreen4 : BaseGameState
    {
        SpriteBatch spriteBatch;

        #region XNA Field region
        #region -Définition des boutons & int-
        int sexyviolon = 1280;
        int sexysaxo = 720;

        public Rectangle container;

        Bouton boutonBonus;
        Bouton boutonBonusSurvol;
        Bouton boutonBonusSelect;
        Bouton boutonChargerPartie;
        Bouton boutonChargerSurvol;
        Bouton boutonChargerSelect;
        Bouton boutonChargerDONTDOTHIS;
        Bouton boutonNouveauJeu;
        Bouton boutonNouveauJeuSurvol;
        Bouton boutonNouveauJeuSelect;
        Bouton boutonOptions;
        Bouton boutonOptionsSurvol;
        Bouton boutonOptionsSelect;
        Bouton boutonQuitter;
        Bouton boutonQuitterSurvol;
        Bouton boutonQuitterSelect;

        Bouton boutonRetour;
        Bouton boutonRetourSurvol;
        Bouton boutonRetourSelect;
        Bouton boutonFenetre;
        Bouton boutonFenetreSurvol;
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
        bool survolfenetre = false;

        Texture2D fondMenu;

        #endregion
        #endregion

        #region Constructor Region

        public StartMenuScreen4(Game game, GameStateManager manager)
            : base(game, manager)
        {

        }

        #endregion

        #region XNA Method Region

        public override void Initialize()
        {
            #region Init des boutons
            boutonBonus = new Bouton();
            boutonBonusSurvol = new Bouton();
            boutonBonusSelect = new Bouton();
            boutonChargerPartie = new Bouton();
            boutonChargerSurvol = new Bouton();
            boutonChargerSelect = new Bouton();
            boutonChargerDONTDOTHIS = new Bouton();
            boutonNouveauJeu = new Bouton();
            boutonNouveauJeuSurvol = new Bouton();
            boutonNouveauJeuSelect = new Bouton();
            boutonOptions = new Bouton();
            boutonOptionsSurvol = new Bouton();
            boutonOptionsSelect = new Bouton();
            boutonQuitter = new Bouton();
            boutonQuitterSurvol = new Bouton();
            boutonQuitterSelect = new Bouton();

            boutonRetour = new Bouton();
            boutonRetourSurvol = new Bouton();
            boutonRetourSelect = new Bouton();
            boutonFenetre = new Bouton();
            boutonFenetreSurvol = new Bouton();
            #endregion

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ContentManager Content = GameRef.Content;

            fondMenu = Content.Load<Texture2D>(@"backgrounds\titlescreen4");

            #region BOUTONS
            #region -Bouton Nouveau Jeu-


            boutonNouveauJeu.LoadContent(Content, "nouveaujeu"); // NOUVEAU JEU
            boutonNouveauJeu.Position = new Vector2(3 * sexyviolon / 4, sexysaxo / 10);
            boutonNouveauJeuSelect.LoadContent(Content, "nouveaujeuC");
            boutonNouveauJeuSelect.Position = boutonNouveauJeu.Position;
            boutonNouveauJeuSurvol.LoadContent(Content, "nouveaujeuSurvol");
            boutonNouveauJeuSurvol.Position = boutonNouveauJeu.Position;

            #endregion

            #region -Bouton Charger Partie-

            boutonChargerDONTDOTHIS.LoadContent(Content, "chargerpartieInactif"); // CHARGER PARTIE
            boutonChargerDONTDOTHIS.Position = new Vector2(3 * sexyviolon / 4, sexysaxo / 10 + 100);
            boutonChargerPartie.LoadContent(Content, "chargerpartie");
            boutonChargerPartie.Position = boutonChargerDONTDOTHIS.Position;
            boutonChargerSelect.LoadContent(Content, "chargerpartieC");
            boutonChargerSelect.Position = boutonChargerDONTDOTHIS.Position;
            boutonChargerSurvol.LoadContent(Content, "chargerpartieSurvol");
            boutonChargerSurvol.Position = boutonChargerDONTDOTHIS.Position;

            #endregion

            #region -Bouton Bonus-

            boutonBonus.LoadContent(Content, "bonus"); // BONUS
            boutonBonus.Position = new Vector2((3 * sexyviolon / 4), sexysaxo / 10 + 200);
            boutonBonusSelect.LoadContent(Content, "bonusC");
            boutonBonusSelect.Position = boutonBonus.Position;
            boutonBonusSurvol.LoadContent(Content, "bonusSurvol");
            boutonBonusSurvol.Position = boutonBonus.Position;

            #endregion

            #region -Bouton Options-

            boutonOptions.LoadContent(Content, "options"); //OPTIONS
            boutonOptions.Position = new Vector2(3 * sexyviolon / 4, sexysaxo / 10 + 300);
            boutonOptionsSelect.LoadContent(Content, "optionsC");
            boutonOptionsSelect.Position = boutonOptions.Position;
            boutonOptionsSurvol.LoadContent(Content, "optionsSurvol");
            boutonOptionsSurvol.Position = boutonOptions.Position;

            #endregion

            #region -Bouton Quitter-

            boutonQuitter.LoadContent(Content, "quitter"); // QUITTER
            boutonQuitter.Position = new Vector2(3 * sexyviolon / 4, sexysaxo / 10 + 400);
            boutonQuitterSelect.LoadContent(Content, "quitterC");
            boutonQuitterSelect.Position = boutonQuitter.Position;
            boutonQuitterSurvol.LoadContent(Content, "quitterSurvol");
            boutonQuitterSurvol.Position = boutonQuitter.Position;

            #endregion

            #region -Bouton Retour-

            boutonRetour.LoadContent(Content, "retour"); // RETOUR
            boutonRetour.Position = new Vector2((3 * sexyviolon / 4) - 200, sexysaxo / 10 + 300);
            boutonRetourSelect.LoadContent(Content, "retourC");
            boutonRetourSelect.Position = boutonRetour.Position;
            boutonRetourSurvol.LoadContent(Content, "retourSurvol");
            boutonRetourSurvol.Position = boutonRetour.Position;

            #endregion

            #region -Bouton Fenetre-

            boutonFenetre.LoadContent(Content, "fenetre"); // FENETRE
            boutonFenetre.Position = new Vector2((3 * sexyviolon / 4) - 200, sexysaxo / 10 + 400);
            boutonFenetreSurvol.LoadContent(Content, "fenetreSurvol");
            boutonFenetreSurvol.Position = boutonFenetre.Position;

            #endregion
            #endregion

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            ControlManager.Update(gameTime, PlayerIndex.One);

            #region -Surbrillance & sélection-

            // Bouton Nouveau Jeu
            if ((mouse.X >= boutonNouveauJeu.Position.X && mouse.X <= boutonNouveauJeu.Position.X + 200)
                && (mouse.Y >= boutonNouveauJeu.Position.Y && mouse.Y <= boutonNouveauJeu.Position.Y + 100) && display) // sous-entendu display == true
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
            if ((mouse.X >= boutonBonus.Position.X && mouse.X <= boutonBonus.Position.X + 200)
                && (mouse.Y >= boutonBonus.Position.Y && mouse.Y <= boutonBonus.Position.Y + 100) && display)
            {
                survolbonus = true;
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    selectbonus = true;
                    survolbonus = false;
                }
                else
                {
                    selectbonus = false;
                }
            }

            else
                survolbonus = false;

            // Bouton Options
            if ((mouse.X >= boutonOptions.Position.X && mouse.X <= boutonOptions.Position.X + 200)
                && (mouse.Y >= boutonOptions.Position.Y && mouse.Y <= boutonOptions.Position.Y + 100) && display)
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
            if ((mouse.X >= boutonQuitter.Position.X && mouse.X <= boutonQuitter.Position.X + 200)
                && (mouse.Y >= boutonQuitter.Position.Y && mouse.Y <= boutonQuitter.Position.Y + 100) && display)
            {
                survolquitter = true;
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    selectquitter = true;
                    survolquitter = false;
                }
                else
                {
                    selectquitter = false;
                }
            }

            else
                survolquitter = false;

            #endregion

            #region -Boutons des options-

            // Bouton Retour
            if ((mouse.X >= boutonRetour.Position.X && mouse.X <= boutonRetour.Position.X + 200)
                    && (mouse.Y >= boutonRetour.Position.Y && mouse.Y <= boutonRetour.Position.Y + 100) && displayopts)
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

            // Bouton Fenêtré
            if ((mouse.X >= boutonFenetre.Position.X && mouse.X <= boutonFenetre.Position.X + 200)
                    && (mouse.Y >= boutonFenetre.Position.Y && mouse.Y <= boutonFenetre.Position.Y + 100) && displayopts)
            {
                survolfenetre = true;
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    survolfenetre = false;
                }
            }

            else
                survolfenetre = false;


            #endregion

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(fondMenu, Vector2.Zero, Color.White);
            #region -Affichage général-
            if (display == true)
            {
                boutonNouveauJeu.Draw(spriteBatch);
                boutonChargerDONTDOTHIS.Draw(spriteBatch);
                boutonOptions.Draw(spriteBatch);
                boutonBonus.Draw(spriteBatch);
                boutonQuitter.Draw(spriteBatch);
            }
            if (displayopts == true)
            {
                boutonRetour.Draw(spriteBatch);
                boutonFenetre.Draw(spriteBatch);
            }
            #endregion

            #region -Affichage des boutons survolés et sélectionnés du menu-

            if (selectnouveau) // si nouveau jeu est sélectionné (le booleen est vrai) ET options n'a pas encore été cliqué, on affiche le bouton sélectionné
            {                                   // on affiche le bouton sélectionné
                boutonNouveauJeuSelect.Draw(spriteBatch);
                MediaPlayer.Stop();
                StateManager.PushState(GameRef.GameScreen);
            }

            if (survolnouveau) // si nouveau jeu est sélectionné ET options n'a pas encore été cliqué (les booleens sont vrais)
            {                                   // on affiche le bouton survolé
                boutonNouveauJeuSurvol.Draw(spriteBatch);
            }


            if (selectbonus)   // Même principe pour les suivants, le but est de gérer les affichages successifs des boutons en fonction de "Options"
            {
                boutonBonusSelect.Draw(spriteBatch);
            }

            if (survolbonus)
            {
                boutonBonusSurvol.Draw(spriteBatch);
            }

            if (selectoptions && selectretour != true)
            {
                boutonOptionsSelect.Draw(spriteBatch);
            }

            if (survoloptions)
            {
                boutonOptionsSurvol.Draw(spriteBatch);
            }

            if (selectquitter)
            {
                boutonQuitterSelect.Draw(spriteBatch);
                Game.Exit(); // Quitte le jeu si cliqué
            }

            if (survolquitter)
            {
                boutonQuitterSurvol.Draw(spriteBatch);
            }

            #endregion

            #region -Affichage des boutons après le clic sur le bouton option-

            if (selectretour && selectoptions != true)
            {
                boutonOptions.Draw(spriteBatch);
            }

            if (survolretour)
            {
                boutonRetourSurvol.Draw(spriteBatch);
            }

            if (survolfenetre)
            {
                boutonFenetreSurvol.Draw(spriteBatch);
            }

            #endregion
            spriteBatch.End();

            ControlManager.Draw(GameRef.SpriteBatch);

            base.Draw(gameTime);
        }

        #endregion
    }
}
