﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TE4TwoDSidescroller
{
    public abstract class States
    {
        #region Fields

        protected ContentManager content;

        protected GraphicsDevice graphicsDevice;

        protected Game1 game;

        #endregion

        #region Methods

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public abstract void PostUpdate(GameTime gameTime);

        public States(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
        {
            this.game = game;
            this.graphicsDevice = graphicsDevice;
            this.content = content;
        }

        public abstract void Update(GameTime gameTime);

      
        #endregion
    }
}
