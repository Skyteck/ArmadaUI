﻿using System;
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
        private SpriteFont font;
        internal Texture2D _BG;
        internal Texture2D _BGHover;
        internal Texture2D _BGClicked;
        internal Texture2D _ActiveTex;
        internal Texture2D iconTex;
        public Vector2 _Position;
        private int Width;
        private int Height;
        public UIManager _UIManager;

        bool Clicked = false;
        bool Hovered = false;
        internal string _Name;
        string _Label;

        Action eventToFire;
        private Action pressEvent;

        public UIButton(string name, Vector2 pos, Vector2 size, string label, UIManager uIManager, Action pressEvent)
        {
            this._Name = name;
            this._Position = pos;
            _UIManager = uIManager;
            eventToFire = pressEvent;
            Width = (int)size.X;
            Height = (int)size.Y;
            _Label = label;
        }

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
            _BGHover = _UIManager.GetTexture(texName + "Hover");
            font = _UIManager.GetFont("Fipps");
            
            _ActiveTex = _BG;
        }

        internal void Update(GameTime gt)
        {
            if(Clicked)
            {
                //button was clicked on, now check if mouse click released also on button
                if(this._BoundingBox.Contains(InputHelper.MouseScreenPos))
                {
                    if (InputHelper.LeftButtonReleased)
                    {
                        eventToFire();
                        _ActiveTex = _BG;
                        //Hovered = false;
                        Clicked = false;
                    }
                }
                //button was clicked on, but now the mouse is not on the button
                else if(!this._BoundingBox.Contains(InputHelper.MouseScreenPos))
                {
                    //mouse released off of button. do nothing
                    if(InputHelper.LeftButtonReleased)
                    {
                        Clicked = false;
                        _ActiveTex = _BG;
                        //Hovered = false;
                    }
                }
            }
            else if(this._BoundingBox.Contains(InputHelper.MouseScreenPos))
            {
                //_ActiveTex = _BGHover;
                Hovered = true;
            }
            else
            {
                _ActiveTex = _BG;
                Hovered = false;
            }


        }

        internal void ProcessClick(Vector2 pos)
        {
            //button clicked, so mark as clicked and check in update if the click is released and stil in hitbox
            if(this._BoundingBox.Contains(pos))
            {
                _ActiveTex = _BGClicked;
                Clicked = true;

            }
        }

        public void SetIcon(string iconName)
        {
            iconTex = _UIManager.GetTexture(iconName);
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_ActiveTex, this._BoundingBox, Color.White);
            Vector2 textPos = this._BoundingBox.Center.ToVector2();

            if(iconTex == null)
            {
                Vector2 TextSize = font.MeasureString(_Label);
                textPos.X -= (float)Math.Floor(TextSize.X / 2);
                textPos.Y -= (float)Math.Floor(TextSize.Y / 2);
                spriteBatch.DrawString(font, _Label, textPos, Color.White);
            }
            else
            {
                spriteBatch.Draw(iconTex, new Vector2(textPos.X - (iconTex.Width / 2), textPos.Y - (iconTex.Height / 2)), Color.White);
            }

            
            if (Hovered)
            {
                if (Clicked) return;
                DrawRectangleOutline(spriteBatch, this._BoundingBox, _BGHover, Color.White);
            }

        }

        internal void SetFunction(Action testClick)
        {
            eventToFire = testClick;
        }

        private void DrawRectangleOutline(SpriteBatch sb, Rectangle rect, Texture2D tex, Color col, int border = 3)
        {
            //Left Line
            sb.Draw(tex, new Rectangle(rect.X, rect.Y, border, rect.Height), col);

            //top line
            sb.Draw(tex, new Rectangle(rect.X, rect.Y, rect.Width + border, border), col);

            //right line
            sb.Draw(tex, new Rectangle(rect.X + rect.Width, rect.Y, border, rect.Height + border), col);

            //bottom line
            sb.Draw(tex, new Rectangle(rect.X, rect.Y + rect.Height, rect.Width + border, border), col);
        }
    }
}
