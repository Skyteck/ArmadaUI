using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ArmadaUI
{
    class UIButton
    {
        internal Texture2D _BG;
        internal Texture2D _BGClicked;
        internal Texture2D _ActiveTex;
        public Vector2 _Position;
        private int Width;
        private int Height;
        public UIManager _UIManager;

        bool Clicked = false;
        internal string _Name;

        Action eventToFire;

        Rectangle _BoundingBox
        {
            get
            {
                return new Rectangle((int)this._Position.X, (int)this._Position.Y, this.Width, this.Height);
            }
        }

        public void LoadContent(string texName)
        {
            _BG = _UIManager.GetTexture(texName);
            _BGClicked = _UIManager.GetTexture(texName + "Clicked");
            this.Width = 100;
            this.Height = 100;
            _ActiveTex = _BG;
        }

        internal void Update(GameTime gt)
        {
            throw new NotImplementedException();
        }

        internal void ProcessClick(Vector2 pos)
        {
            if(this._BoundingBox.Contains(pos))
            {
                _ActiveTex = _BGClicked;
                eventToFire();

            }
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_ActiveTex, this._BoundingBox, Color.White);
        }

        internal void SetFunction(Action testClick)
        {
            eventToFire = testClick;
        }
    }
}
