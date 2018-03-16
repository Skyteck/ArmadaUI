using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmadaUI
{
    class UILabel : UIElement
    {
        string _Label;
        private SpriteFont font;
        Vector2 _Size;

        public UILabel(Vector2 pos, string text, UIManager uim)
        {
            _Position = pos;
            _Label = text;
            _UIManager = uim;
        }

        public override void LoadContent(string fontName)
        {
            font = _UIManager.GetFont(fontName);

            _Size = font.MeasureString(_Label);
            _Position.X -= (int)(_Size.X / 2);
            _Position.Y -= (int)(_Size.Y / 2);
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.DrawString(font, _Label, _Position, Color.White);
        }
    }
}
