using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmadaUI
{
    public class UIElement
    {
        public string _Name;
        public Vector2 _Position;
        public UIManager _UIManager;
        public string HoverText;
        public bool _Show = true;

        public virtual void LoadContent(string texName)
        {

        }

        public virtual void Draw(SpriteBatch sb)
        {

        }
    }
}
