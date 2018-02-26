using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ArmadaUI
{
    public class UIManager
    {        
        List<UIPanel> PanelList;
        ContentManager _ContentManager;
        public UIManager()
        {
            PanelList = new List<UIPanel>();
        }

        public void LoadContent(ContentManager content)
        {
            _ContentManager = content;
        }

        public void CreatePanel(String name, Vector2 pos)
        {
            UIPanel p = new UIPanel();
            p.Name = name;
            p._UIManager = this;
            p.LoadContent("test");
            p._Position = pos;
            p.PlaceButton("test", new Vector2(160, 160), p.TestClick);
            PanelList.Add(p);
        }

        public Texture2D GetTexture(string texName)
        {
            return _ContentManager.Load<Texture2D>(@"Art/" + texName);
        }

        public void Update(GameTime gt)
        {

            //only handling clicks for now
            if (InputHelper.LeftButtonClicked)
            {
                foreach (UIPanel p in PanelList)
                {
                    p.ProcessClick(InputHelper.MouseScreenPos);
                }
            }
        }

        public void Draw(SpriteBatch sb)
        {
            foreach(UIPanel p in PanelList)
            {
                p.Draw(sb);
            }
        }
    }
}
