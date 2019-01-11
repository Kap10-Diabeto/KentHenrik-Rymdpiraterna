using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO; 


namespace Kent_Henrik_Rymdpiraterna
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SNEL ZNEL;
        Texture2D SE;
        Texture2D Xion;
        public static List<Basklass> ELAKLista = new List<Basklass>();
        Texture2D SPACE;
        Texture2D E;
        Texture2D Pets;
        int points = 0;
        SpriteFont pointsfont;
        //private Explosion explosion;
        List<Explosion> explosions = new List<Explosion>();
        List<Explosion2> explosions2 = new List<Explosion2>();
        Texture2D explosion;
        Texture2D explosion2;
        bool mainMenu = true;
        Texture2D startBG;
        Texture2D HPH;
        Random rand = new Random();







        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 596;
            graphics.PreferredBackBufferHeight = 972;

            if (File.Exists("score.txt")){
                StreamReader sr = new StreamReader("score.txt");
                sr.readline(points);
                sr.Close();
            }

            else{
            File.Create("score.txt");
            StreamWriter sw = new StreamWriter("score.txt");
            sw.WriteLine("0");
            sw.Close();
            }


            
        }


        protected override void Initialize()
        {
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D x = Content.Load<Texture2D>("SNEL");
            Texture2D b = Content.Load<Texture2D>("Bullets" + "");
            HPH = Content.Load<Texture2D>("HPH");
            ZNEL = new SNEL(x, b);
            Xion = Content.Load<Texture2D>("Xion");
            ELAKLista.Add(new Xion(Xion));
            E = Content.Load<Texture2D>("ELAK");
            SE = Content.Load<Texture2D>("SuperELAK");
            ELAKLista.Add(new ELAK(E));
            ELAKLista.Add(new SUPERELAK(SE));
            SPACE = Content.Load<Texture2D>("Space3");
            Pets = Content.Load<Texture2D>("Pets");
            pointsfont = Content.Load<SpriteFont>("Pointsfont");
            explosion = Content.Load<Texture2D>("BOOM");
            explosion2 = Content.Load<Texture2D>("BOOMSuperELAK");
            //explosion = new Explosion(texture, 9, 9);
            startBG = Content.Load<Texture2D>("Space3"); ;

            Color[] color = new Color[startBG.Width * startBG.Height];
            startBG.GetData(color);
            for (int i = 0; i < color.Length; i++)
            {
                color[i] *= .5f;
                color[i].A = 255;
            }
            startBG.SetData(color);

        }


        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (!mainMenu)
            {
                ZNEL.Update(gameTime, Window);

                foreach (var item in ELAKLista)
                {
                    item.Update();
                }
                int slump = rand.Next(0, 230);
                if (slump < 6)
                {
                    ELAKLista.Add(new ELAK(E));
                }
                slump = rand.Next(0, 1000);
                slump = rand.Next(0, 3000);
                if (slump == 2)
                {
                    ELAKLista.Add(new ELAK(E));
                }

                ELAKbulletkrock();
                Trollabortelak();

                foreach (Explosion item in explosions)
                {
                    item.Update();
                }
                foreach (Explosion2 item in explosions2)
                {
                    item.Update();
                }
                EnemyHitMotherShip();

            }
            else
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    mainMenu = false;
                    Color[] color = new Color[startBG.Width * startBG.Height];
                    startBG.GetData(color);
                    for (int i = 0; i < color.Length; i++)
                    {
                        color[i] *= 2f;
                        color[i].A = 255;
                    }
                    startBG.SetData(color);
                }
            }
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            if (!mainMenu)
            {
                spriteBatch.Draw(SPACE, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
                ZNEL.Draw(spriteBatch);

                foreach (var ELAK in ELAKLista)
                {
                    ELAK.Draw(spriteBatch);
                }

                for (int i = 1; i <= ZNEL.Health; i++)
                {
                    spriteBatch.Draw(HPH, new Rectangle(30 * i, 30, 30, 30), Color.White);
                }

                spriteBatch.DrawString(pointsfont, points.ToString(), new Vector2(Window.ClientBounds.Width - 50, 30), Color.White);
                spriteBatch.End();

            }
            else
            {
                spriteBatch.Draw(startBG, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
                spriteBatch.Draw(Pets, new Rectangle(20, 436, 572, 63), Color.White);



                spriteBatch.End();
            }
            base.Draw(gameTime);

            foreach (var item in explosions)
            {
                item.Draw(spriteBatch);
            }

            foreach (var item in explosions2)
            {
                item.Draw(spriteBatch);
            }

            Bullet b;
            foreach (var item in ELAKLista)
            {
                if(item is Bullet)
                {
                    b = item as Bullet;
                }
            }
        }

        void ELAKbulletkrock()
        {
            List<Basklass> BULLET = ELAKLista.Where(x => x is Bullet).ToList();
            for (int i = 0; i < BULLET.Count; i++)
            {
                for (int j = 0; j < ELAKLista.Count; j++)
                {
                    if (BULLET[i].HitBox.Intersects(ELAKLista[j].HitBox) && !BULLET[i].Equals(ELAKLista[j]))
                    {
                        BULLET[i].IsDead = true;
                        ELAKLista[j].IsDead = true;
                        points = points + 1;
                        explosions.Add(new Explosion(explosion, 9, 9, new Vector2(ELAKLista[j].HitBox.X - 20, ELAKLista[j].HitBox.Y - 10)));

                    }

                }
            }
        }


        void Trollabortelak()
        {
            List<Basklass> temp = new List<Basklass>();
            for (int j = 0; j < ELAKLista.Count; j++)
            {
                if (!ELAKLista[j].IsDead)
                    temp.Add(ELAKLista[j]);
            }
            ELAKLista = temp;

        }

        void EnemyHitMotherShip()
        {
            for (int i = 0; i < ELAKLista.Count; i++)
            {

                if (ELAKLista[i].HitBox.Y > Window.ClientBounds.Height)
                {
                    ELAKLista[i].IsDead = true;
                    ZNEL.LHP();
                    if (ZNEL.Health == 0)
                    {
                        SteamReader sr = new StreamReader("Score.txt");
                        string file = sr.ReadToEnd();
                        Exit();
                    }
                }

            }

        }

    }
}
