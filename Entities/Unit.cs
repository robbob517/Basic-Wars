﻿using Basic_Wars.Graphics;
using Basic_Wars_V2.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Wars_V2.Entities
{
    public class Unit : IGameEntity, ICollideable
    {
        private const int UNIT_WIDTH = 56;
        private const int UNIT_HEIGHT = 56;

        private const int X_SPRITE_SHEET_START_POS = 0;
        private const int Y_SPRITE_SHEET_START_POS = 0;

        private const int ANIMATION_SHIFT = 56;

        private const int SPRITE_SHEET_TEAM_SHIFT = 168;
        private const int SPRITE_SHEET_UNIT_SHIFT = 56;

        public Sprite unitSprite;

        private Texture2D Texture { get; set; }

        public Vector2 Position { get; set; }
        public UnitState State { get; set; }
      
        public int Team { get; set; }
        public UnitType Type { get; set; }

        public int Health { get; set; }
        public int MovementPoints { get; set; }
        public int CostToProduce { get; set; }

        
        public int ID { get; set; }
        public int DrawOrder { get; set; }
        public Color UnitUsed = Color.White * 0.5f;

        public Unit(Texture2D texture, Vector2 position, int unitType, int team)
        {
            Texture = texture;
            Position = position;
            Team = team;

            CreateUnitSprite(unitType);
            SetUnitAttributes(unitType);
        }

        public void CreateUnitSprite(int unitType)
        {
            int teamShift = (Team - 1) * SPRITE_SHEET_TEAM_SHIFT;
            int unitShift = (unitType - 1) * SPRITE_SHEET_UNIT_SHIFT;
            unitSprite = new Sprite(Texture, X_SPRITE_SHEET_START_POS + teamShift, Y_SPRITE_SHEET_START_POS + unitShift, UNIT_WIDTH, UNIT_HEIGHT);
        }

        public Rectangle Collider
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, UNIT_WIDTH, UNIT_HEIGHT);
            }
        }

        public void Draw(SpriteBatch _spriteBatch, GameTime gameTime)
        {
            unitSprite.Draw(_spriteBatch, Position);
        }

        public void SetUnitAttributes(int unitType)
        {
            Health = 100;
            State = UnitState.Idle;

            switch (unitType - 1)
            {
                case 0:
                    Type = UnitType.Infantry;
                    CostToProduce = 1000;
                    MovementPoints = 3;
                    break;

                case 1:
                    Type = UnitType.Mech;
                    CostToProduce = 3000;
                    MovementPoints = 2;
                    break;

                case 2:
                    Type = UnitType.Tank;
                    CostToProduce = 7000;
                    MovementPoints = 6;
                    break;

                case 3:
                    Type = UnitType.APC;
                    CostToProduce = 5000;
                    MovementPoints = 6;
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {

        }

    }
}
