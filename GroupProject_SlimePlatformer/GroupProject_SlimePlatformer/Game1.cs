using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GroupProject_SlimePlatformer
{
    //Authors: Sofia Rivas, Riley Procopio, Joshua Meyer, Gianluigi Aponte
    //Purpose: Make Game
    //Known Errors/Restrictions: When the player lands in a perfect spot in between 2 tiles they are still counted as in the air so they cannot jump
    enum GameState
    {
        Menu,
        DifficultySelection,
        Controls,
        EasyGame,
        NormalGame,
        Pause,
        Victory
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;

        SpriteBatch spriteBatch;
        GameState gameState;
        GameState prevGame;
        KeyboardState kbState;
        KeyboardState lastKbState;
        SpriteFont spriteFont;

        //Attributes to be used for the player
        Player player;

        // Stores the levels and keeps track of what levl we are on
        List<Level> levels;
        int currentLevel;
        List<Walls> invisWalls;

        /*
        //Probably add "objectRectangle" field for each object, which can equal the specified "ObjectRectangle". Will hopefully free up space later.
        private Rectangle playerRectangle;
        
        //Temporary fields for testing.
        private Walls wallTest;
        private Walls blockTest;
        private Walls ceilingTest;

        private Rat ratTest;
        private Bat batTest;

        private Spike spikeTest;
        private Water waterTest;
        */

        private FriendlySlime friendlySlime;

        //Textures
        private Texture2D wallTexureTest;

        private Texture2D ratTexureTest;
        private Texture2D batTextureTest;

        private Texture2D ratTexture;
        private Texture2D batTexture;

        //private Texture2D waterTextureTest;
        private Texture2D spikeTextureTest;

        private Texture2D friendlySlimeTexture;

        private Texture2D groundTile;
        private Texture2D wallTile;
        private Texture2D waterTile;
        private Texture2D menuBackGround;
        private Texture2D spikeDown;
        private Texture2D gameBackGround;


        //title screen
        Rectangle title;
        private Texture2D controlsTitle;
        private Texture2D victoryTitle;

        //textures buttons
        Texture2D controlsButtonTexture;
        Texture2D easyModeTexture;
        Texture2D normalModeTexture;
        Texture2D playButtonTexture;
        Texture2D gameTitleTexture;
        Texture2D aButtonT;
        Texture2D wButtonT;
        Texture2D sButtonT;
        Texture2D dButtonT;

        //buttons
        Button playButton;
        Button easyModeButton;
        Button normalModeButton;
        Button controlsButton;
        Button wButton;
        Button sButton;
        Button dButton;
        Button aButton;

        /*Insert fields for the animations (including cycles) here*/

        Texture2D playerSpriteIdle;
        Texture2D playerSpriteDeath;
        Texture2D playerSpriteJump;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferWidth = 816;
            _graphics.ApplyChanges();

            gameState = GameState.Menu; // starts game in menu state

            levels = new List<Level>();
            currentLevel = 0;
            invisWalls = new List<Walls>();

            /* For changing the size of the screen
            _graphics.PreferredBackBufferWidth = 1200;
            _graphics.PreferredBackBufferHeight = 1000;
            _graphics.ApplyChanges();
            */

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //load textures
            playerSpriteIdle = Content.Load<Texture2D>("slimeIdle");

            spriteFont = Content.Load<SpriteFont>("spriteFont");
            controlsButtonTexture = Content.Load<Texture2D>("controlsButton");
            easyModeTexture = Content.Load<Texture2D>("easyMode");
            normalModeTexture = Content.Load<Texture2D>("normalMode");
            playButtonTexture = Content.Load<Texture2D>("playButton");
            gameTitleTexture = Content.Load<Texture2D>("logo");
            controlsTitle = Content.Load<Texture2D>("controls_title");
            victoryTitle = Content.Load<Texture2D>("victory_title");
            wButtonT = Content.Load<Texture2D>("W");
            aButtonT = Content.Load<Texture2D>("A");
            sButtonT = Content.Load<Texture2D>("S");
            dButtonT = Content.Load<Texture2D>("D");


            wallTexureTest = Content.Load<Texture2D>("wallTestBig");
            ratTexureTest = Content.Load<Texture2D>("ratTestSmall");
            ratTexture = Content.Load<Texture2D>("ratTestSmall");
            batTexture = Content.Load<Texture2D>("bat spritesheet");
            //waterTextureTest = Content.Load<Texture2D>("waterTest");
            batTextureTest = Content.Load<Texture2D>("batTest");
            spikeTextureTest = Content.Load<Texture2D>("obstacleTest");
            friendlySlimeTexture = Content.Load<Texture2D>("SlimeRed_Idle4");

            groundTile = Content.Load<Texture2D>("ground_tile");
            waterTile = Content.Load<Texture2D>("water_tile");
            wallTile = Content.Load<Texture2D>("wall_tile");
            menuBackGround = Content.Load<Texture2D>("menu_background");
            spikeDown = Content.Load<Texture2D>("spike_upsidedown");
            gameBackGround = Content.Load<Texture2D>("game_background");

            //initiate stuff you need textures for
            playButton = new Button(playButtonTexture, 330, 330, 150, 40);
            controlsButton = new Button(controlsButtonTexture, 330, 380, 150, 40);

            easyModeButton = new Button(easyModeTexture, 330, 330, 150, 40);
            normalModeButton = new Button(normalModeTexture, 330, 380, 150, 40);

            wButton = new Button(wButtonT, 125, 170, 80, 80);
            aButton = new Button(aButtonT, 35, 260, 80, 80);
            sButton = new Button(sButtonT, 125, 260, 80, 80);
            dButton = new Button(dButtonT, 215, 260, 80, 80);

            

            //title rect
            title = new Rectangle(175, 120, 300, 100);

            playButton.Select(); //starts with play button selected
            easyModeButton.Select(); //starts with play button selected

            //Change these later (at least the texturing).
            /*player = new Player(playerTexture, playerX, playerY, Vectors for player.). Possibly just make "playerX" and "playerY" components of a Vector2 of the 
             * player's position
             *Then initialize the components for Player*/
            //player = new Player(testSlime, 50, 50, );
            /*
            wallTest = new Walls(wallTexureTest, 0, 400);
            ceilingTest= new Walls(wallTexureTest, 350, 200);
            blockTest = new Walls(blockTexureTest, 100, 300);

            wallObjects.Add(wallTest);
            wallObjects.Add(ceilingTest);
            wallObjects.Add(blockTest);

            spikeTest = new Spike(spikeTextureTest, 250, 375);
            waterTest = new Water(waterTextureTest, 375, 375);
            ratTest = new Rat(ratTexureTest, 130, 285);
            */

            friendlySlime = new FriendlySlime(friendlySlimeTexture, 736, 318);

            title = new Rectangle(100, 25, 600, 300);
            levels.Add(new Level("..\\..\\..\\Content\\Levels\\Level1.txt", _graphics.PreferredBackBufferHeight, _graphics.PreferredBackBufferWidth, wallTile, groundTile, spikeTextureTest, spikeDown, waterTile, ratTexture, batTexture));
            levels.Add(new Level("..\\..\\..\\Content\\Levels\\Level2.txt", _graphics.PreferredBackBufferHeight, _graphics.PreferredBackBufferWidth, wallTile, groundTile, spikeTextureTest, spikeDown, waterTile, ratTexture, batTexture));
            levels.Add(new Level("..\\..\\..\\Content\\Levels\\Level3.txt", _graphics.PreferredBackBufferHeight, _graphics.PreferredBackBufferWidth, wallTile, groundTile, spikeTextureTest, spikeDown, waterTile, ratTexture, batTexture));
            levels.Add(new Level("..\\..\\..\\Content\\Levels\\Level4.txt", _graphics.PreferredBackBufferHeight, _graphics.PreferredBackBufferWidth, wallTile, groundTile, spikeTextureTest, spikeDown, waterTile, ratTexture, batTexture));
            levels.Add(new Level("..\\..\\..\\Content\\Levels\\Level5.txt", _graphics.PreferredBackBufferHeight, _graphics.PreferredBackBufferWidth, wallTile, groundTile, spikeTextureTest, spikeDown, waterTile, ratTexture, batTexture));
            levels.Add(new Level("..\\..\\..\\Content\\Levels\\Level6.txt", _graphics.PreferredBackBufferHeight, _graphics.PreferredBackBufferWidth, wallTile, groundTile, spikeTextureTest, spikeDown, waterTile, ratTexture, batTexture));
            levels.Add(new Level("..\\..\\..\\Content\\Levels\\Level7.txt", _graphics.PreferredBackBufferHeight, _graphics.PreferredBackBufferWidth, wallTile, groundTile, spikeTextureTest, spikeDown, waterTile, ratTexture, batTexture));
            levels.Add(new Level("..\\..\\..\\Content\\Levels\\Level8.txt", _graphics.PreferredBackBufferHeight, _graphics.PreferredBackBufferWidth, wallTile, groundTile, spikeTextureTest, spikeDown, waterTile, ratTexture, batTexture));
            levels.Add(new Level("..\\..\\..\\Content\\Levels\\Level9.txt", _graphics.PreferredBackBufferHeight, _graphics.PreferredBackBufferWidth, wallTile, groundTile, spikeTextureTest, spikeDown, waterTile, ratTexture, batTexture));
            levels.Add(new Level("..\\..\\..\\Content\\Levels\\Level10.txt", _graphics.PreferredBackBufferHeight, _graphics.PreferredBackBufferWidth, wallTile, groundTile, spikeTextureTest, spikeDown, waterTile, ratTexture, batTexture));

            
            player = new Player(playerSpriteIdle, 10, 200);

            for (int i = 0; i < 20; i++)
            {
                invisWalls.Add(new Walls(wallTexureTest, -34, i * 24, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight));
            }
        }

            //level = new Level("..\\..\\TestLevel.txt", _graphics.PreferredBackBufferHeight, _graphics.PreferredBackBufferWidth, wallTexureTest, obstacleTextureTest);
            
            //playerSpriteIdle = Content.Load<Texture2D>("slimeIdle");
            //playerSpriteDeath = Content.Load<Texture2D>("slimeDeath");
            //playerSpriteJump = Content.Load<Texture2D>("slimeJump");

            //player = new Player(playerSpriteIdle, 10, 10, /*playerSpriteDeath, playerSpriteJump*/);
        //}

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            lastKbState = kbState;
            kbState = Keyboard.GetState(); //gets keyboard state
            //finite state machine
            player.Update(gameTime);
            switch (gameState)
            {
                case GameState.Menu:
                    //press up and down to move through buttons
                    //enter to select button
                    //goes to controls, easy game, and normal game, exit game
                    ResetLevel();
                    ResetGame();

                    if (IsKeyPressedOnce(Keys.W) || IsKeyPressedOnce(Keys.Up))
                    {
                        playButton.Select();
                        controlsButton.Deselect();
                    }

                    if (IsKeyPressedOnce(Keys.S) || IsKeyPressedOnce(Keys.Down))
                    {
                        playButton.Deselect();
                        controlsButton.Select();
                    }

                    if (IsKeyPressedOnce(Keys.Enter))
                    {
                        if (playButton.IsSelected())
                        {
                            prevGame = gameState;
                            gameState = GameState.DifficultySelection;
                        }
                        else if (controlsButton.IsSelected())
                        {
                            prevGame = gameState;
                            gameState = GameState.Controls;
                        }
                    }
                    if (IsKeyPressedOnce(Keys.V))
                    {
                        prevGame = gameState;
                        gameState = GameState.Victory;
                    }

                    if (IsKeyPressedOnce(Keys.X))
                    {
                        Exit();
                    }

                    break;

                case GameState.DifficultySelection:

                    //selects difficulty 

                    if (IsKeyPressedOnce(Keys.W) || IsKeyPressedOnce(Keys.Up))
                    {
                        easyModeButton.Select();
                        normalModeButton.Deselect();
                    }

                    if (IsKeyPressedOnce(Keys.S) || IsKeyPressedOnce(Keys.Down))
                    {
                        easyModeButton.Deselect();
                        normalModeButton.Select();
                    }

                    if (IsKeyPressedOnce(Keys.Enter))
                    {
                        if (easyModeButton.IsSelected())
                        {
                            prevGame = gameState;
                            currentLevel = 0;
                            gameState = GameState.EasyGame;
                        }
                        else if (normalModeButton.IsSelected())
                        {
                            prevGame = gameState;
                            currentLevel = 0;
                            gameState = GameState.NormalGame;
                        }
                    }

                    break;

                case GameState.Controls:
                    //shows info about movement
                    //press enter to go back to menu
                    if (IsKeyPressedOnce(Keys.Enter))
                    {
                        prevGame = gameState;
                        gameState = GameState.Menu;
                    }
                    //changes w key
                    if (kbState.IsKeyDown(Keys.W) || IsKeyPressedOnce(Keys.Up))
                    {
                       
                        wButton.Select();
                    }
                    else
                    {
                        wButton.Deselect();
                    }

                    //changes A key
                    if (kbState.IsKeyDown(Keys.A) || IsKeyPressedOnce(Keys.Left))
                    {

                        aButton.Select();
                    }
                    else
                    {
                        aButton.Deselect();
                    }

                    //changes S key
                    if (kbState.IsKeyDown(Keys.S) || IsKeyPressedOnce(Keys.Down))
                    {

                        sButton.Select();
                    }
                    else
                    {
                        sButton.Deselect();
                    }

                    //changes D key
                    if (kbState.IsKeyDown(Keys.D) || IsKeyPressedOnce(Keys.Right))
                    {

                        dButton.Select();
                    }
                    else
                    {
                        dButton.Deselect();
                    }




                    break;

                case GameState.EasyGame:
                    //checks level
                    //loads in level accordingly
                    //doesnt add enemies

                    //tracks movement of player (Josh: Most of this is a placeholder right now.)    
                    player.Move();
                    player.SubtractTimer(gameTime.ElapsedGameTime.TotalSeconds);
                    //Is Sticking isn't working quite yet.
                    player.IsSticking = CheckIfSticking();
                    player.UpdateAnimation(gameTime);
                    if (!player.IsSticking)
                    {
                        player.ApplyGravity();
                    }

                    // Tracks collisions with obstacles
                    foreach (Obstacle obst in levels[currentLevel].Obstacles)
                    {
                        if (player.CollisionDetection(obst))
                        {
                            ResetLevel();
                        }
                    }
                    foreach (Walls wall in levels[currentLevel].Walls)
                    {
                        if (player.IsSticking || (player.CollisionDetection(wall) && !(player.Y > wall.ObjectRectangle.Bottom - 5) && player.X + 10 > wall.X) && player.PlayerRectangle.Right - 10 < wall.ObjectRectangle.Right)
                        {
                            player.InAir = false;
                        }
                    }
                    ResolvingCollisions();

                    
                    // Invisible walls to prevent walking off
                    foreach (Walls wall in invisWalls)
                    {
                        if (player.CollisionDetection(wall))
                        {
                            player.PlayerRectangleX = 0;
                        }
                    }

                    //takes to pause or victory screen
                    if (player.CollisionDetection(friendlySlime) && IsKeyPressedOnce(Keys.V) && currentLevel == levels.Count - 1)
                    {
                        prevGame = gameState;
                        gameState = GameState.Victory;
                    }
                    if (IsKeyPressedOnce(Keys.P))
                    {
                        prevGame = gameState;
                        gameState = GameState.Pause;
                    }

                    //tracks if moved to the end of level 
                    /*
                     * if(playerPosition.X >= (_graphics.PreferredBackBufferWidth- playerTexture.Width))
                     * {
                     * 
                     *      NextLevel(); - will load the next level
                     * }
                     */
                    if (player.X >= _graphics.PreferredBackBufferWidth)
                    {
                        NextLevel();
                    }
                    break;

                case GameState.NormalGame:
                    //checks level
                    //loads in level accordingly
                    //add enemies accordingly
                    //tracks movement of player (Josh: Most of the code here is a placeholder right now. Will basically copy and paste, just not including the enemies in the EasyGame.)
                    player.Move();
                    player.SubtractTimer(gameTime.ElapsedGameTime.TotalSeconds);
                    //Is Sticking isn't working quite yet.
                    player.IsSticking = CheckIfSticking();
                    player.UpdateAnimation(gameTime);
                    if (!player.IsSticking)
                    {
                        player.ApplyGravity();
                    }

                    // Moves enemies
                    for (int i = 0; i < levels[currentLevel].Enemies.Count; i++)
                    {
                        levels[currentLevel].Enemies[i].Move();
                    }

                    // Tracks collisions with obstacles
                    foreach (Obstacle obst in levels[currentLevel].Obstacles)
                    {
                        if (player.CollisionDetection(obst))
                        {
                            ResetLevel();
                        }

                        foreach(Bat bats in levels[currentLevel].BatEnemies)
                        {
                            if (bats.CollisionDetection(obst))
                            {
                                bats.ShouldReverse = true;
                            }
                        }
                    }

                    // Tracks collisions with enemies
                    foreach (Enemy enemy in levels[currentLevel].Enemies)
                    {
                        if (player.CollisionDetection(enemy))
                        {
                            ResetLevel();
                        }
                    }
                    foreach (Walls wall in levels[currentLevel].Walls)
                    {
                        if (player.IsSticking || (player.CollisionDetection(wall) && !(player.Y > wall.ObjectRectangle.Bottom - 5) && player.X + 10 > wall.X) && 
                            player.PlayerRectangle.Right - 10 < wall.ObjectRectangle.Right)
                        {
                            player.InAir = false;
                        }

                        foreach (Bat bats in levels[currentLevel].BatEnemies)
                        {
                            if (bats.CollisionDetection(wall))
                            {
                                bats.ShouldReverse = true;  
                            }
                        }

                       foreach (Rat rats in levels[currentLevel].RatEnemies)
                       {
                           //rats.Update(gameTime);
                           if (rats.WallCollision(wall))
                           {
                               rats.ReverseDirection *= -1;
                           }
                       }
                    }

                    //makes rat not fall off of platform
                    foreach (Rat rats in levels[currentLevel].RatEnemies)
                    {
                         foreach (Air air in levels[currentLevel].Air)
                         {
                             if (rats.AirCollision(air))
                             {
                                 rats.ReverseDirection *= -1;
                             }
                         }
                    }

                    foreach (Bat bats in levels[currentLevel].BatEnemies)
                    {
                        if (bats.ShouldReverse)
                        {
                            bats.ReverseDirection *= -1;
                        }
                        
                    }

                    foreach (Bat bats in levels[currentLevel].BatEnemies)
                    {
                        bats.ShouldReverse = false; 
                    }

                    foreach(Walls wall in invisWalls)
                    {
                        if (player.CollisionDetection(wall))
                        {
                            player.PlayerRectangleX = 0;
                        }
                    }

                    ResolvingCollisions();

                    //tracks if moved to the end of level 
                    /*
                     * if(playerPosition.X >= (_graphics.PreferredBackBufferWidth- playerTexture.Width))
                     * {
                     * 
                     *      NextLevel(); - will load the next level
                     * }
                     */

                    //takes to pause or victory screen
                    if (player.CollisionDetection(friendlySlime) && IsKeyPressedOnce(Keys.V) && currentLevel == levels.Count - 1)
                    {
                        prevGame = gameState;
                        gameState = GameState.Victory;
                    }
                    if (IsKeyPressedOnce(Keys.P))
                    {
                        prevGame = gameState;
                        gameState = GameState.Pause;
                    }

                    if (player.X >= _graphics.PreferredBackBufferWidth)
                    {
                        NextLevel();
                    }

                    break;
                case GameState.Pause:
                    //back to main menu or back to game
                    if (IsKeyPressedOnce(Keys.M))
                    {
                        prevGame = gameState;
                        gameState = GameState.Menu;
                    }
                    if (IsKeyPressedOnce(Keys.G))
                    {
                        gameState = prevGame;
                    }

                    break;
                case GameState.Victory:
                    //back to main menu
                    if (IsKeyPressedOnce(Keys.Enter))
                    {
                        prevGame = gameState;
                        gameState = GameState.Menu;
                    }
                    if (IsKeyPressedOnce(Keys.X))
                    {
                        Exit();
                    }

                    break;
                default:
                    break;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);

            spriteBatch.Begin();
            switch (gameState)
            {
                case GameState.Menu:
                    spriteBatch.Draw(menuBackGround, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                    spriteBatch.DrawString(spriteFont, "Press X to exit game" /*+ GraphicsDevice.Viewport.Width +" "+ GraphicsDevice.Viewport.Height*/, new Vector2(0, 450), Color.White);
                    spriteBatch.Draw(gameTitleTexture, title, Color.White);
                    playButton.Draw(spriteBatch);
                    controlsButton.Draw(spriteBatch);
                    break;

                case GameState.DifficultySelection:
                    // spriteBatch.DrawString(spriteFont, "GameState\nThis is a test screen." +
                    //     "\nPress Enter to go back to menu.", new Vector2(300, 100), Color.White);
                    spriteBatch.Draw(menuBackGround, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                    spriteBatch.Draw(gameTitleTexture, title, Color.White);
                    easyModeButton.Draw(spriteBatch);
                    normalModeButton.Draw(spriteBatch);
                    break;

                case GameState.Controls:
                    spriteBatch.Draw(menuBackGround, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                    spriteBatch.Draw(controlsTitle, new Rectangle(315, 50, 450, 100), Color.LightYellow);
                    wButton.Draw(spriteBatch);
                    aButton.Draw(spriteBatch);
                    sButton.Draw(spriteBatch);
                    dButton.Draw(spriteBatch);
                    spriteBatch.DrawString(spriteFont, "W - Jump\n" +
                        "\nA - Move left\n " +
                        "\nS - Down / Unstick from a wall\n" +
                        "\nD - Move right\n "+
                        "\nP - Pause\n ", new Vector2(450, 180), Color.White);

                    spriteBatch.DrawString(spriteFont, "Press ENTER to go to menu" , new Vector2(560, 460), Color.White);

                    break;
                case GameState.EasyGame:
                    spriteBatch.DrawString(spriteFont, "Easy game\nThis is a test screen." +
                        "\nGo to friendly slime and press V for Victory Screen" +
                        "\nPress P to pause", new Vector2(300, 100), Color.White);
                    //draws background
                    spriteBatch.Draw(gameBackGround, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                    //This will need to be adjusted to include the sprite batch of the Friendly Slime. This goes for the enemies as well.
                    if (currentLevel == levels.Count - 1)
                    {
                        friendlySlime.Draw(spriteBatch);
                    }
                    levels[currentLevel].Draw(spriteBatch);
                   
                  //  spriteBatch.DrawString(spriteFont, $"inAir: {player.InAir}", new Vector2(300, 10), Color.White);
                    //spriteBatch.DrawString(spriteFont, $"isSticking: {player.IsSticking}", new Vector2(300, 30), Color.White);
                  //  spriteBatch.DrawString(spriteFont, $"atEdge: {ratTest.AtEdge}", new Vector2(300, 50), Color.White);
                    player.Draw(spriteBatch);
                    break;
                    

                case GameState.NormalGame:
                    spriteBatch.DrawString(spriteFont, "Normal game\nThis is a test screen." +
                        "\n Go to friendly slime and press V for Victory Screen" +
                        "\nPress P to pause", new Vector2(300, 100), Color.White);

                    //draws background
                    spriteBatch.Draw(gameBackGround, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                    player.Draw(spriteBatch);
                    /* Old stuff, keeping it here just in case

                    spikeTest.Draw(spriteBatch);
                    waterTest.Draw(spriteBatch);

                    wallTest.Draw(spriteBatch);
                    ceilingTest.Draw(spriteBatch);

                    blockTest.Draw(spriteBatch);

                    ratTest.Draw(spriteBatch);
                    batTest.Draw(spriteBatch);
                    obstacleTest.Draw(spriteBatch);
                    */
                    levels[currentLevel].Draw(spriteBatch);
                    if (currentLevel == levels.Count - 1)
                    {
                        friendlySlime.Draw(spriteBatch);
                    }

                    foreach (Enemy enemy in levels[currentLevel].Enemies)
                    {
                        enemy.Update(gameTime);
                        enemy.Draw(spriteBatch);
                    }

                    /*
                    spriteBatch.DrawString(spriteFont, $"inAir: {player.InAir}", new Vector2(300, 10), Color.White);
                    spriteBatch.DrawString(spriteFont, $"isSticking: {player.IsSticking}", new Vector2(300, 30), Color.White);
                    
                    spriteBatch.DrawString(spriteFont, $"atEdge: {ratTest.AtEdge}", new Vector2(300, 50), Color.White);
                    spriteBatch.DrawString(spriteFont, $"atWall: {batTest.ReverseDirection}", new Vector2(300, 70), Color.White);
                    */
                    //new Rectangle(175, 120, 300, 100)
                    break;
                case GameState.Pause:
                    spriteBatch.Draw(menuBackGround, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

                    spriteBatch.DrawString(spriteFont, "Pause\nThis is a test screen" +
                        "\nPress M for menu." +
                        "\nPress G to go back to game", new Vector2(300, 100), Color.White);
                    break;


                case GameState.Victory:
                    spriteBatch.Draw(menuBackGround, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                    spriteBatch.Draw(victoryTitle, new Rectangle(155, 120, 520, 150), Color.LightYellow);
                    spriteBatch.DrawString(spriteFont, "You saved your friends!" , new Vector2(320, 290), Color.White);
                    spriteBatch.DrawString(spriteFont, "Press ENTER to go to menu", new Vector2(560, 460), Color.White);
                    spriteBatch.DrawString(spriteFont, "Press X to exit game", new Vector2(0, 460), Color.White);
                    break;
                default:
                    spriteBatch.DrawString(spriteFont, "IDK how you reached this but if you did uh..." +
                        "\n something went HORRIBLY wrong....", new Vector2(300, 100), Color.White);
                    
                    break;
            }


            spriteBatch.End();
        }

        /// <summary>
        /// This method checks for a single key press.
        /// </summary>
        /// <param name="keySelected"></param>
        /// <returns></returns>
        public bool IsKeyPressedOnce(Keys keySelected)
        {
            if (lastKbState.IsKeyUp(keySelected) && kbState.IsKeyDown(keySelected))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This method is used to make sure the player doesn't go through any of the walls in each level.
        /// </summary>
        public void ResolvingCollisions()
        {
            foreach(Walls wall in levels[currentLevel].Walls)
            {
                if (player.PlayerRectangle.Intersects(wall.ObjectRectangle))
                {
                    Rectangle overlapRectangle = Rectangle.Intersect(player.PlayerRectangle, wall.ObjectRectangle);
                    
                    if (overlapRectangle.Width >= overlapRectangle.Height)
                    {
                        if (player.Y - wall.ObjectRectangle.Y < 0)
                        {
                            player.PlayerRectangleY -= overlapRectangle.Height;
                        }
                        if (player.Y - wall.ObjectRectangle.Y > 0)
                        {
                            player.PlayerRectangleY += overlapRectangle.Height;
                        }

                    }
                    if (!player.InAir || player.PlayerRectangle.Bottom <= wall.ObjectRectangle.Y)
                    {
                        player.PlayerVelocity = Vector2.Zero;
                    }

                    if (overlapRectangle.Height > overlapRectangle.Width)
                    {
                        if (player.X - wall.ObjectRectangle.X < 0)
                        {
                            player.PlayerRectangleX -= overlapRectangle.Width;
                        }

                        if (player.X - wall.ObjectRectangle.X > 0)
                        {
                            player.PlayerRectangleX += overlapRectangle.Width;
                        }
                    }

                }
                player.Y = player.PlayerRectangle.Y;
                player.X = player.PlayerRectangle.X;

            }
        }

        /// <summary>
        /// Checks if the player is sticking on the left or right side of a wall.
        /// </summary>
        /// <returns></returns>
        public bool CheckIfSticking()
        {
            for(int i = 0; i < levels[currentLevel].Walls.Count; i++)
            {
                //Will have to check if the player is on the wall and if so, switch to the "wall stick" animation (probably rotated idle) and then keep the Player's position in place until specific key is pressed
                /*The reason why the "IsSticking" variable is continuing to go back and forth is because the parameters set MUST have the player colliding with the wall, which means they have to hold in the
                 *direction of the wall to maintain sticking on it*/
                if (player.IsSticking || (player.CollisionDetection(levels[currentLevel].Walls[i]) && (player.X >= levels[currentLevel].Walls[i].ObjectRectangle.Left 
                    || player.X <= levels[currentLevel].Walls[i].ObjectRectangle.Right) && player.Timer <= 0))
                {
                    return true;
                }
            }
            return false;
        }

        //May need to change positioning of this in code for the main method.

        /// <summary>
        /// Plays death animation and resets character position
        /// </summary>
        public void ResetLevel()
        {
            // Play death animation here first
            player.PlayerRectangleY =  (int)levels[currentLevel].RespawnPoint.Y;
            player.PlayerRectangleX = (int)levels[currentLevel].RespawnPoint.X;
            player.PlayerVelocity = new Vector2(0, 0);
            player.InAir = false;
            player.IsSticking = false;
        }

        /// <summary>
        /// Plays death animation and resets character position to the very first level's initial position.
        /// </summary>
        public void ResetGame()
        {
            player.PlayerRectangleY = (int)levels[0].RespawnPoint.Y;
            player.PlayerRectangleX = (int)levels[0].RespawnPoint.X;
            player.PlayerVelocity = new Vector2(0, 0);
            player.InAir = false;
            player.IsSticking = false;
        }

        /// <summary>
        /// Advances the game to the next level
        /// </summary>
        public void NextLevel()
        {
            currentLevel++;
            player.PlayerRectangleY = (int)levels[currentLevel].RespawnPoint.Y;
            player.PlayerRectangleX = (int)levels[currentLevel].RespawnPoint.X;
            player.PlayerVelocity = new Vector2(0, 0);
            player.InAir = false;
            player.IsSticking = false;
            //foreach (Enemy enemy in levels[currentLevel].Enemies)
            //{
            //    enemy.Update(gameTime);
            //}
        }
    }
}
