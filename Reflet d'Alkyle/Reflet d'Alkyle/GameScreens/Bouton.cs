using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Reflet_d_Alkyle
{
    public class Bouton
    {
        private Texture2D texture; //Définit la variable représentant la texture

        public Texture2D Texture // Récupère la dite texture du sprite
        {
            get { return texture; }
            set { texture = value; }
        }

        public Vector2 Position // Récupère la position du sprite
        {
            get { return position; }
            set { position = value; }
        }

        private Vector2 position; //Définit la variable représentant le vecteur

        public Rectangle container; //Définit la variable représentant le rectangle



        public virtual void Initialize()
        {
            position = Vector2.Zero;  //Initialise les variables pour la position du sprite

        }

        public Rectangle getContainer() // Créé le rectangle contenant le bouton
        {
            container = new Rectangle((int)position.X,
                (int)position.Y,
                (int)texture.Width,
                (int)texture.Height);
            return container;
        }

        public virtual void LoadContent(ContentManager content, string assetName) //Charge le contenu
        {
            texture = content.Load<Texture2D>(assetName);
        }

        public virtual void Draw(SpriteBatch spriteBatch) //Dessine le sprite
        {
                spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
