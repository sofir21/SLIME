using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace GroupProject_SlimePlatformer
{
    //Authors: Riley Procopio, Joshua Meyer, & Sofia Rivas
    //Purpose:
    //Known Errors/Restrictions:
    class Level
    {
        List<GameObject> levelLayout;
        List<Walls> walls;
        List<Obstacle> obstacles;
        List<Enemy> enemies;
        List<Rat> ratEnemies;
        List<Bat> batEnemies;
        List<GameObject> air;
        Vector2 respawnPoint;

        // Start of properties
        public List<Obstacle> Obstacles
        {
            get
            {
                return obstacles;
            }
        }

        public List<Walls> Walls
        {
            get
            {
                return walls;
            }
        }

        public List<Enemy> Enemies
        {
            get
            {
                return enemies;
            }
        }

        public List<Rat> RatEnemies
        {
            get
            {
                return ratEnemies;
            }
        }

        public List<Bat> BatEnemies
        {
            get
            {
                return batEnemies;
            }
        }

        public List<GameObject> Air
        {
            get
            {
                return air;
            }
        }

        public Vector2 RespawnPoint
        {
            get
            {
                return respawnPoint;
            }
        }

        //End of properties

        // Constructor, creates a new level layout based on the filename passed in
        public Level(string filePath, int levelHeight, int levelWidth, Texture2D wallTexture, Texture2D groundTexture, Texture2D spikeTexture, Texture2D reverseSpikeTexture, Texture2D waterTexture,
            Texture2D ratTexture, Texture2D batTexture)
        {
            levelLayout = new List<GameObject>();
            walls = new List<Walls>();
            obstacles = new List<Obstacle>();
            enemies = new List<Enemy>();
            ratEnemies = new List<Rat>();
            batEnemies = new List<Bat>();
            air = new List<GameObject>();

            FileStream stream = File.OpenRead(filePath);
            StreamReader sr = new StreamReader(stream);
            string currentLine = sr.ReadLine();

            // For spacing purposes
            int currentX = 0;
            int currentY = 0;

            // Reading in the file
            while (currentLine != null)
            {
                if (currentLine == "ground")
                {
                    Walls newWall = new Walls(groundTexture, currentX, currentY, levelWidth, levelHeight);
                    levelLayout.Add(newWall);
                    walls.Add(newWall);

                }
                else if (currentLine == "wall")
                {
                    Walls newWall = new Walls(wallTexture, currentX, currentY, levelWidth, levelHeight);
                    levelLayout.Add(newWall);
                    walls.Add(newWall);
                }
                else if (currentLine == "water")
                {
                    Water newObstacle = new Water(waterTexture, currentX, currentY + 5, levelWidth, levelHeight);
                    levelLayout.Add(newObstacle);
                    obstacles.Add(newObstacle);
                }
                else if (currentLine == "spike")
                {
                    Spike newObstacle = new Spike(spikeTexture, currentX, currentY, levelWidth, levelHeight);
                    levelLayout.Add(newObstacle);
                    obstacles.Add(newObstacle);
                }
                else if (currentLine == "reverseSpike")
                {
                    Spike newObstacle = new Spike(reverseSpikeTexture, currentX, currentY, levelWidth, levelHeight);
                    levelLayout.Add(newObstacle);
                    obstacles.Add(newObstacle);
                }
                else if (currentLine == "rat")
                {
                    Rat newRat = new Rat(ratTexture, currentX, currentY);
                    ratEnemies.Add(newRat);
                    enemies.Add(newRat);
                }
                else if (currentLine == "bat")
                {
                    Bat newBat = new Bat(batTexture, currentX, currentY);
                    batEnemies.Add(newBat);
                    enemies.Add(newBat);
                }
                else if (currentLine == "respawn")
                {
                    respawnPoint = new Vector2(currentX, currentY + 7);
                }
                else
                {
                    Air newAir = new Air(waterTexture, currentX, currentY + 2, levelWidth, levelHeight);
                    levelLayout.Add(newAir);
                    air.Add(newAir);
                }

                currentX += levelWidth / 24;

                // Numbers aren't perfect so we need to subtract
                if (currentX >= levelWidth - 8)
                {
                    currentX = 0;
                    currentY += levelHeight / 20;
                }

                currentLine = sr.ReadLine();
            }

            sr.Close();

        }

        /// <summary>
        /// Draws the level
        /// </summary>
        /// <param name="sb"> The spritebatch that will draw the level </param>
        public void Draw(SpriteBatch sb)
        {
            for (int i = 0; i < levelLayout.Count; i++)
            {
                if (!air.Contains(levelLayout[i]))
                {
                    levelLayout[i].Draw(sb);
                }

            }
        }
    }
}