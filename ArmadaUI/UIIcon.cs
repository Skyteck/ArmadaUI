using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmadaUI
{
    class UIIcon : UIElement
    {
        public Texture2D _Texture;

        public override void LoadContent(string texName)
        {
            _Texture = _UIManager.GetTexture(texName);
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(_Texture, this._Position, null, Color.White, 0f, new Vector2(this._Texture.Width / 2, this._Texture.Height / 2), 0f, SpriteEffects.None, 0f);
        }
    }
}
