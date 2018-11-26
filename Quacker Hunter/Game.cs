using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;
using System.Media;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Runtime.Serialization;

namespace Quacker_Hunter
{
    [DataContract]
    public class Game
    {
        private DataModel records;
        public Boolean enableLoggingWindow = true;

        /*ENABLE LOGGING WINDOW */
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        /* Configurations */
        public const int WIND_WIDTH = 1072;
        public const int WIND_HEIGHT = 566;
        public const int POINT_PER_KILL = 10;
        public static int AIMER_X = WIND_WIDTH / 2;
        public static int AIMER_Y = WIND_HEIGHT / 2;

        /* Changable Settings */
        /*public static int DUCK_MIN_MOVE_SPEED = 4;
        public static int DUCK_MAX_MOVE_SPEED = 7;
        public static int DUCK_CREATE_SPEED = 1500;
        public static int POINT_PER_KILL = 10;*/
        //[DataMember]
        public static int DUCK_MIN_MOVE_SPEED;
        //[DataMember]
        public static int DUCK_MAX_MOVE_SPEED;
        //[DataMember]
        public static int DUCK_CREATE_SPEED;

        private GEngine gengine;

        public static ArrayList ducks = new ArrayList();
        public static string movingAimer = "none";
        public static int SCORE = 0;
        public static int KILLS = 0;
        public static int MISS = 0;

        public Boolean areGraphicsStartarted = false;

        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int scoreForSerialization { get; set; }
        [DataMember]
        public int killsForSerialization { get; set; }
        [DataMember]
        public int missForSerialization { get; set; }
        [DataMember]
        public int duck_Min_Move_SpeedForSerialization { get; set; }
        [DataMember]
        public int duck_Max_Move_SpeedscoreForSerialization { get; set; }
        [DataMember]
        public int duck_Create_SpeedscoreForSerialization { get; set; }

        public Game(DataModel Records)
        {
            records = DataModel.Load()/*Records*/;            
            if ( enableLoggingWindow ) AllocConsole();
            Console.WriteLine("Game class created");
        }

        public Game()
        {
            if (enableLoggingWindow) AllocConsole();
            Console.WriteLine("Game class created");
        }

        public void startGraphics(Graphics g)
        {
            Console.WriteLine("Game->startGraphics called");
            gengine = new GEngine(g);
            gengine.init();
            areGraphicsStartarted = true;
        }

        public void stopGame()
        {
            Console.WriteLine("Game->stopGame(): Game Stopped");
            gengine.stop();
        }

        public void SetDataToSerialization()
        {
            scoreForSerialization = SCORE;
            killsForSerialization = KILLS;
            missForSerialization = MISS;
            duck_Min_Move_SpeedForSerialization = DUCK_MIN_MOVE_SPEED;
            duck_Max_Move_SpeedscoreForSerialization = DUCK_MAX_MOVE_SPEED;
            duck_Create_SpeedscoreForSerialization = DUCK_CREATE_SPEED;
            name = "Oleh";
        }

        public static void createDuck( int x = 0)
        {
            if (x == 0)
                x = WIND_WIDTH;

            string start_from = "right";
            if (new Random().Next(0, 100) < 50)
            {
                start_from = "left";
                x = -200;
            }

            if (x != WIND_WIDTH)
                Console.WriteLine("Game->createdDuck at {0} (X was assigned as a variable - Starting from {1})", x.ToString(), start_from );
            else
                Console.WriteLine("Game->createDuck at {0} (X wasn't assigned -- assuming SIDE - Starting from {1})", x.ToString(), start_from);

            Dictionary<string, string> t = new Dictionary<string, string>();
            t["pos_x"] = x.ToString();
            t["pos_y"] = (new Random().Next(20, Game.WIND_HEIGHT - 310)).ToString();
            t["start_from"] = start_from;
            t["is_dead"] = "false";
            t["move_speed"] = (new Random().Next(DUCK_MIN_MOVE_SPEED, DUCK_MAX_MOVE_SPEED)).ToString();

            t["shot_loc_x"] = "0";
            t["shot_loc_y"] = "0";
            t["shot_time"] = "0";
            ducks.Add(t);
        }

        public void onWeaponFire()
        {
            if (gengine.isPaused) return;
            Console.WriteLine("Game->onWeaponFire(): Weapon has been fired at {0}, {1}", Game.AIMER_X, Game.AIMER_Y);

            //MessageBox.Show("Gun fired");

            // Check for hit
            int x, y, index;
            int aim_x = Game.AIMER_X + 10;
            int aim_y = Game.AIMER_Y + 10;
            foreach (Dictionary<string, string> value in Game.ducks)
            {
                index = Game.ducks.IndexOf(value);
                
                if (Convert.ToBoolean(value["is_dead"])) continue;

                x = Convert.ToInt32(value["pos_x"]);
                y = Convert.ToInt32(value["pos_y"]);
                // check X axis
                if (aim_x >= x && aim_x <= x + 200)
                {
                    // Check Y
                    if (aim_y >= y && aim_y <= y+120)
                    {
                        //Game.ducks.Remove(Game.ducks[index]);
                        value["is_dead"] = "true";

                        value["shot_loc_x"] = x.ToString();
                        value["shot_loc_y"] = y.ToString();
                        value["shot_time"] = Environment.TickCount.ToString();

                        SoundPlayer sndf = new SoundPlayer(Quacker_Hunter.Properties.Resources.quack);
                        sndf.Play();
                        SCORE += POINT_PER_KILL;
                        KILLS += 1;
                        //System.Threading.Thread.Sleep(500);
                        break;
                    }
                }
            }
            // Play audio
            SoundPlayer snd = new SoundPlayer(Quacker_Hunter.Properties.Resources.gunFire);
            snd.Play();
        }




        //// Game Controls ////
        public void onKeyPress(KeyEventArgs e)
        {
            String key = e.KeyCode.ToString().ToLower();
            if (key == "up" || key == "down" || key == "left" || key == "right" || key == "w" || key == "a" || key == "d" || key == "s")
            {
                switch (key)
                {
                    case "w":
                        {
                            key = "up";
                            SetDataToSerialization();
                            DataSerializer.SerializeData("save.dat", this);
                            //stopGame();
                        }
                        break;
                    case "a":
                        {
                            key = "left";
                            Game dgame = DataSerializer.DeserializeItem("save.dat");
                            SCORE = dgame.scoreForSerialization;
                            KILLS = dgame.killsForSerialization;
                            MISS = dgame.missForSerialization;
                            //dgame.
                        }
                        break;
                    case "s":
                        {
                            key = "down";
                            SetDataToSerialization();
                            //AddTo
                            //DataSerializer.SerializeDataToRecords("saverecords.dat", records);
                            //Game dgame = DataSerializer.DeserializeItem("save.dat");
                            records.Records.Add(new Profile(this.name, SCORE));
                            //records.Records = new List<Game>() { this, dgame };
                            //records.Records.Add(this);
                            records.Save();
                            stopGame();
                        }

                        break;
                    case "d":
                            key = "right";

                        break;
                    default:
                        break;
                }
                movingAimer = key;
            }
            else if (key == "space")
            {
                this.onWeaponFire();
            }
        }

        public void onKeyRelease(KeyEventArgs e)
        {
            string key = e.KeyCode.ToString().ToLower();
            if (key == "up" || key == "down" || key == "left" || key == "right" || key == "w" || key == "a" || key == "d" || key == "s")
            {
                /*if ((key == "up" || key == "w ") && (movingAimer == "up_left" || movingAimer == "down_left"))
                    movingAimer = "left";

                else if ((key == "up" || key == "w ") && (movingAimer == "up_right" || movingAimer == "down_right"))
                    movingAimer = "right";

                else if ((key == "down" || key == "s") && (movingAimer == "down_left" || movingAimer == "up_left"))
                    movingAimer = "left";

                else if ((key == "down" || key == "s") && (movingAimer == "down_right" || movingAimer == "down_right"))
                    movingAimer = "right";*/
                movingAimer = "n";
            }
            else if (key == "escape")
            {
                if (gengine.isGamePaused())
                    gengine.startGame();
                else
                    gengine.stop();
            }
        }
    }
}
