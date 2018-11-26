using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.Collections;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Quacker_Hunter
{
    class GEngine
    {

        private Graphics drawHandle;
        private Thread renderThread;
        public Boolean isPaused = true;

        // ASSETS //
        private Bitmap asset_weapon;
        private Bitmap asset_background;
        private Bitmap asset_duckFromRight;
        private Bitmap asset_duckFromLeft;
        private Bitmap asset_aimer;
        private Bitmap asset_bloodSplatter;
        ///////////////

        public static int FPS = 0;

        public GEngine(Graphics g )
        {
            Console.WriteLine("Gengine: Class created");
            drawHandle = g;
        }

        public bool isGamePaused()
        {
            return isPaused;
        }

        public void init()
        {
            Console.WriteLine("GEngine->init(): Graphics Engine initization");
            this.loadAssets();

            renderThread = new Thread(new ThreadStart(render));
            renderThread.Start();
            isPaused = false;
        }

        public void startGame()
        {
            renderThread = new Thread(new ThreadStart(render));
            renderThread.Start();
            isPaused = false;
        }

        private void loadAssets()
        {
            Console.WriteLine("GEngine->loasdAssets(): Loading game assets....");
            asset_background = Quacker_Hunter.Properties.Resources.background;
            asset_weapon = Quacker_Hunter.Properties.Resources.FirstPersonGun;
            asset_duckFromRight = Quacker_Hunter.Properties.Resources.DuckFromRight;
            asset_duckFromLeft = Quacker_Hunter.Properties.Resources.DuckFromLeft;
            asset_aimer = Quacker_Hunter.Properties.Resources.aimer;
            asset_bloodSplatter = Quacker_Hunter.Properties.Resources.blood_splatter;
        }

        public void stop()
        {
            Console.WriteLine("GEngine->stop(): Game Puased");
            renderThread.Abort();
            isPaused = true;
        }

        private void render()
        {
            int framesRendered = 0;
            long startTime = Environment.TickCount;
            long lastDuckRecord = Environment.TickCount;

            Bitmap CANV_FRAME = new Bitmap(Game.WIND_WIDTH, Game.WIND_HEIGHT);
            Graphics CANV_GRAPHIC = Graphics.FromImage(CANV_FRAME);

            int x, y, index;
            ArrayList removeItems;
            while (true)
            {
                x = 0;
                y = 0;
                removeItems = new ArrayList();
                CANV_GRAPHIC.DrawImage(asset_background, 0, 0);

                /* Render Ducks */
                try
                {
                    foreach (Dictionary<string, string> value in Game.ducks)
                    {
                        index = Game.ducks.IndexOf(value);
                        x = Convert.ToInt32(value["pos_x"]);
                        y = Convert.ToInt32(value["pos_y"]);

                        if (Convert.ToBoolean(value["is_dead"]))
                        {
                            if (Environment.TickCount - Convert.ToInt64(value["shot_time"]) <= 2000)
                                CANV_GRAPHIC.DrawImage(asset_bloodSplatter, Convert.ToInt32(value["shot_loc_x"]), Convert.ToInt32(value["shot_loc_y"]));
                        }

                        if (value["start_from"] == "right")
                        {
                            if (Convert.ToBoolean(value["is_dead"]))
                                value["pos_y"] = (y + Convert.ToInt32(value["move_speed"])).ToString();

                            value["pos_x"] = (x - Convert.ToInt32(value["move_speed"])).ToString();

                            /*CANV_GRAPHIC.DrawLine(new Pen(Color.Red), new Point(x, y ), new Point ( x+200, y ) );
                            CANV_GRAPHIC.DrawLine(new Pen(Color.Red), new Point(x, y), new Point(x, y + 123));
                            CANV_GRAPHIC.DrawLine(new Pen(Color.Red), new Point(x+200, y), new Point(x+200, y + 123));
                            CANV_GRAPHIC.DrawLine(new Pen(Color.Red), new Point(x, y + 123), new Point(x+200, y + 123));*/
                            CANV_GRAPHIC.DrawImage(asset_duckFromRight, x, y);
                        }
                        else
                        {
                            if (Convert.ToBoolean(value["is_dead"]))
                                value["pos_y"] = (y + Convert.ToInt32(value["move_speed"])).ToString();

                           value["pos_x"] = (x + Convert.ToInt32(value["move_speed"])).ToString();

                            /*CANV_GRAPHIC.DrawLine(new Pen(Color.Red), new Point(x, y), new Point(x + 200, y));
                            CANV_GRAPHIC.DrawLine(new Pen(Color.Red), new Point(x, y), new Point(x, y + 123));
                            CANV_GRAPHIC.DrawLine(new Pen(Color.Red), new Point(x + 200, y), new Point(x + 200, y + 123));
                            CANV_GRAPHIC.DrawLine(new Pen(Color.Red), new Point(x, y + 123), new Point(x + 200, y + 123));*/
                            CANV_GRAPHIC.DrawImage(asset_duckFromLeft, x, y);
                        }

                        
                        // Remove ducks if they're off the screen
                        if (x <= -200 && value["start_from"] == "right")
                        {
                            Console.WriteLine("GEngine->render(): Removing duck at index " + index + " due to not being shot");
                            Game.MISS += 1;
                            removeItems.Add( index );
                        }
                        else if (x >= Game.WIND_WIDTH && value["start_from"] == "left")
                        {
                            Console.WriteLine("GEngine->render(): Removing duck at index " + index + " due to not being shot");
                            Game.MISS += 1;
                            removeItems.Add(index);
                        }

                        if (y >= Game.WIND_HEIGHT)
                        {
                            Console.WriteLine("GEngine->render(): Removing duck at index " + index + " due to being shot");
                            removeItems.Add(index);
                        }

                    }
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine("GEngine->render():Handled Exception InvalidOperationException. " + e.Message);
                }


                // Render Aimer
                switch (Game.movingAimer)
                {
                    case "left":
                        if ( Game.AIMER_X > 30 )
                            Game.AIMER_X -= 10;
                        break;
                    case "right":
                        if (Game.AIMER_X < Game.WIND_WIDTH - 30)
                            Game.AIMER_X += 10;
                        break;
                    case "up":
                        if (Game.AIMER_Y > 30)
                            Game.AIMER_Y -= 10;
                        break;
                    case "down":
                        if (Game.AIMER_Y < Game.WIND_HEIGHT - 30)
                            Game.AIMER_Y += 10;
                        break;
                    default:
                        break;
                }

                CANV_GRAPHIC.DrawImage(asset_aimer, Game.AIMER_X, Game.AIMER_Y);
                CANV_GRAPHIC.DrawImage(asset_weapon, Game.AIMER_X - 5, Game.WIND_HEIGHT - 240);
                CANV_GRAPHIC.DrawString("Score: " + Game.SCORE + "        Kills: " + Game.KILLS + "        Misses: " + Game.MISS + "        FPS: " + GEngine.FPS.ToString(), new Font ( "Arial", 16 ), new SolidBrush ( Color.DarkSeaGreen ), new Point ( 20, 20 ));

                // Create the actual image
                try
                {
                    drawHandle.DrawImage(CANV_FRAME, 0, 0);
                }
                catch (ExternalException e)
                {
                    Console.WriteLine("GEngine->render(): ExternalException recivied. Error: "+ e.Message);
                    System.Threading.Thread.Sleep(700);
                    Application.Exit();
                    break;
                }

                // Remove dead birds
                foreach (int ind in removeItems)
                {
                    Game.ducks.Remove(Game.ducks[ind]);
                }
                // Calculate FPS
                framesRendered++;
                if (Environment.TickCount - startTime >= 1000)
                {
                    startTime = Environment.TickCount;
                    Console.WriteLine("GEngine->render: FPS - " + framesRendered);
                    FPS = framesRendered;
                    framesRendered = 0;
                }
                // Create new ducks
                if (Environment.TickCount - lastDuckRecord >= Game.DUCK_CREATE_SPEED )
                {
                    Game.createDuck();
                    lastDuckRecord = Environment.TickCount;
                }
            }
        }
    }
}
