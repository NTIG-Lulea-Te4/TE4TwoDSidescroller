using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TE4TwoDSidescroller
{
    class MeleeAttack : Entity
    {

        Texture attackTexture;

        public MeleeAttack()
        {

            collisionBox = new Rectangle(0, 0, 0, 0);
            LoadTexture2D();
        }

        //Grafik för att se hur stor attacken är
        public void LoadTexture2D()
        {
            string currentPath = Path.GetDirectoryName(
             System.Reflection.Assembly.GetExecutingAssembly().Location)
             + "/Content/Pngs/" + "Box.png";

            using (Stream textureStream = new FileStream(currentPath, FileMode.Open))
            {
                attackTexture = Texture2D.FromStream(GameInfo.graphicsDevice.GraphicsDevice, textureStream);
            }

        }

        public static void AttackCollision()
        {




        }

    }
}
