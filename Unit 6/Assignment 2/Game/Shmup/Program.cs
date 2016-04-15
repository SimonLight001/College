using System;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Primitives;
using SdlDotNet.Core;

using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Shmup {

    // ===== Data Types =====

    public class SpriteSheet {
        
        private string imagefile;
        
        private List<Rectangle> rects = new List<Rectangle>();

        private SpriteSheet() {
        }
        public static SpriteSheet load(string configfile) {
            SpriteSheet ss = new SpriteSheet();
            StreamReader sr = new StreamReader(configfile);
            string line = sr.ReadLine();
            line = sr.ReadLine();
            string[] fields = line.Split('=');
            ss.imagefile = fields[1];
            while (!sr.EndOfStream) {
                line = sr.ReadLine();
                fields = line.Split(',');
                int x = int.Parse(fields[1]);
                int y = int.Parse(fields[2]);
                int w = int.Parse(fields[3]);
                int h = int.Parse(fields[4]);
                Rectangle r = new Rectangle(x,y,w,h);
                ss.rects.Add(r);
            }
            return ss;
        }

        public Rectangle getRectangle(int sprite) {
            return rects[sprite];
        }

        public string getImagefile() {
            return imagefile;
        }
    }

    public class Duck {

        // state

        private int x;
        private int y;
        private int dx;
        private int dy;
        private int sprite;
        private int direction;
        private int rotation;

        // constructors

        public Duck(int x, int y, int sprite, int direction, int rotation, int dx, int dy) {
            this.x = x;
            this.y = y;
            this.sprite = sprite;
        }

        // behaviour 

        public void setX(int x) {
            this.x = x;
        }

        public int getX() {
            return x;
        }

        public void setY(int y) {
            this.y = y;
        }

        public int getY() {
            return y;
        }

        public void setSprite(int sprite)  {
            this.sprite = sprite;
        }

        public int getSprite() {
            return sprite;
        }

        public void setDirection(int direction) {
            this.direction = direction;
        }

        public int getDirection() {
            return direction;
        }

        public void setRotation(int rotation) {
            this.rotation = rotation;
        }

        public int getRotation() {
            return rotation;
        }

        public void move() {
            x += dx;
            y += dy;

            if (rotation != 0) {
                direction = (direction + rotation) % 360;
            }
        }

        public void thrust(int thrust) {
            double rad = (double)(direction + 90) * Math.PI / 180.0;
            dx += (int)((double)thrust * Math.Cos(rad));
            dy += -(int)((double)thrust * Math.Sin(rad));
        }

    }

    public class Bomb {

        // state

        private int x;
        private int y;
        private int dx;
        private int dy;
        private int sprite;
        private int direction;
        private int rotation;

        // constructors

        public Bomb(int x, int y, int sprite, int direction, int rotation, int dx, int dy) {
            this.x = x;
            this.y = y;
            this.dx = dx;
            this.dy = dy;
            this.sprite = sprite;
            this.direction = direction;
            this.rotation = rotation;
        }

        // behaviour 
        public void setDY(int dy)
        {
            this.dy = dy;
        }
        public void setX(int x) {
            this.x = x;
        }

        public int getX() {
            return x;
        }

        public void setY(int y) {
            this.y = y;
        }

        public int getY() {
            return y;
        }

        public void setSprite(int sprite) {
            this.sprite = sprite;
        }

        public int getSprite() {
            return sprite;
        }

        public void setDirection(int direction) {
            this.direction = direction;
        }

        public int getDirection() {
            return direction;
        }

        public void setRotation(int rotation) {
            this.rotation = rotation;
        }

        public int getRotation() {
            return rotation;
        }

        public void move() {
            x += dx;
            y += dy;

            if (rotation != 0) {
                direction = (direction + rotation) % 360;
            }
        }

    }

    public class Coin
    {

        // state

        private int x;
        private int y;
        private int dx;
        private int dy;
        private int sprite;
        private int direction;
        private int rotation;

        // constructors

        public Coin(int x, int y, int sprite, int direction, int rotation, int dx, int dy)
        {
            this.x = x;
            this.y = y;
            this.dx = dx;
            this.dy = dy;
            this.sprite = sprite;
            this.direction = direction;
            this.rotation = rotation;
        }

        // behaviour 
        public void setDY(int dx)
        {
            this.dx = dx;
        }
        public void setX(int x)
        {
            this.x = x;
        }

        public int getX()
        {
            return x;
        }

        public void setY(int y)
        {
            this.y = y;
        }

        public int getY()
        {
            return y;
        }

        public void setSprite(int sprite)
        {
            this.sprite = sprite;
        }

        public int getSprite()
        {
            return sprite;
        }

        public void setDirection(int direction)
        {
            this.direction = direction;
        }

        public int getDirection()
        {
            return direction;
        }

        public void setRotation(int rotation)
        {
            this.rotation = rotation;
        }

        public int getRotation()
        {
            return rotation;
        }

        public void move()
        {
            x += dx;
            y += dy;

            if (rotation != 0)
            {
                direction = (direction + rotation) % 360;
            }
        }

    }

    
    // -- Body --

    public class Body {

        private double mass;
        private Position position;
        private Motion motion;

        public Body(double mass, double x, double y, double velocity, double direciton) {
            this.mass = mass;
            this.position = new Position(x,y);
            this.motion = new Motion(velocity,direciton);
        }

        public double getMass() {
            return mass;
        }

        public void setMass(double mass) {
            this.mass = mass;
        }

        public Position getPosition() {
            return position;
        }

        public Motion getMotion() {
            return motion;
        }

    }

    // -- Position --

    public class Position {

        private double x;
        private double y;

        public Position(double x, double y) {
            this.x = x;
            this.y = y;
        }

        public double getX() {
            return x;
        }

        public void setX(double x) {
            this.x = x;
        }

        public double getY() {
            return y;
        }

        public void setY(double y) {
            this.y = y;
        }

    }

    // -- Motion --

    public class Motion {

        private double velocity;
        private double direction;

        public Motion(double velocity, double direction) {
            this.velocity = velocity;
            this.direction = direction;
        }

        public double getVelocity() {
            return velocity;
        }

        public void setVelocity(double velocity) {
            this.velocity = velocity;
        }

        public double getDirection() {
            return direction;
        }

        public void setDirection(double direction) {
            this.direction = direction;
        }

    }
 
    // -- Program, Entry Point --

    static class Program {

        // STATE
        // Keep the state of the elements of the game here (variables hold state).

        static Random rnd = new Random();

        static SpriteSheet ss;
        static Duck duck;
        static Bomb[] bombs = new Bomb[3];
        static Coin[] coins = new Coin[3];

        // This procedure is called (invoked) before the first time onTick is called.
        static void onInit() {
            //int x, int y, int sprite, int direction, int rotation, int dx, int dy
            duck = new Duck(FRAME_WIDTH/2, FRAME_HEIGHT - 100, 0, 0, 0, 0, 0);
            for(int i = 0; i < bombs.Length; i++)
            {
                bombs[i] = new Bomb(rnd.Next(FRAME_WIDTH), 0, rnd.Next(1,3), rnd.Next(360), rnd.Next(1,4), 0, rnd.Next(1,4));
            }
            for(int i = 0; i < coins.Length; i++)
            {
                coins[i] = new Coin(100, 100, 3, rnd.Next(360), rnd.Next(1, 4), 0, rnd.Next(1, 4));
            }
        }
        static int bombStepper = 0;
        static int coinStepper = 0;

        // This procedure is called (invoked) for each window refresh
        static void onTick(object sender, TickEventArgs args) {

            // STEP
            // Update the automagic elements and enforce the rules of the game here.

            duck.move();

            bombStepper++;
            coinStepper++;

            if(bombStepper > 60)
            {
                for (int i = 0; i < bombs.Length; ++i){
                     if(bombs[i].getSprite() == 2)
                     {
                         bombs[i].setSprite(1);
                     }
                     else{
                         bombs[i].setSprite(2);
                     }
                     bombStepper = 0;
                }
            }
            /*
            if(coinStepper > 30)
            {
                for(int i = 0; i < coins.Length; i++)
                {
                      if is on last sprite go to first
             *        else go to next sprite
                }
            }
             */

            if (duck.getY() < 0) {
                duck.setY(FRAME_HEIGHT);
            } else if (duck.getY() > FRAME_HEIGHT) {
                duck.setY(0);
            }

            for (int i = 0; i < bombs.Length; ++i) {
                bombs[i].move();
                if (bombs[i].getY() > FRAME_HEIGHT) {
                    bombs[i].setY(0);
                    bombs[i].setX(rnd.Next(FRAME_WIDTH));
                    bombs[i].setDY(rnd.Next(1,4));
                }
            }

            for (int i = 0; i < coins.Length; ++i)
            {
                coins[i].move();
                if (coins[i].getY() > FRAME_HEIGHT)
                {
                    coins[i].setY(0);
                    coins[i].setX(rnd.Next(FRAME_WIDTH));
                    coins[i].setDY(rnd.Next(1, 4));
                }
            }

            // DRAW
            // Draw the new view of the game based on the state of the elements here.

            drawBackground();

            drawSprite(duck.getSprite(),duck.getX(),duck.getY(),duck.getDirection());

            for(int i = 0; i < bombs.Length; ++i) {
                drawSprite(bombs[i].getSprite(), bombs[i].getX(), bombs[i].getY(), bombs[i].getDirection());
            }
            for(int i = 0; i < coins.Length; i++)
            {
                drawSprite(coins[i].getSprite(), coins[i].getX(), coins[i].getY(), coins[i].getDirection());
            }


                // ANIMATE 
                // Step the animation frames ready for the next tick
                // ...

                // REFRESH
                // Tranfer the new view to the screen for the user to see.
                video.Update();

        }

        // this procedure is called when the mouse is moved
        static void onMouseMove(object sender, SdlDotNet.Input.MouseMotionEventArgs args) {
            duck.setX(SdlDotNet.Input.Mouse.MousePosition.X);
        }

        // this procedure is called when a mouse button is pressed or released
        static void onMouseButton(object sender, SdlDotNet.Input.MouseButtonEventArgs args) {
        }

        // this procedure is called when a key is pressed or released
        static void onKeyboard(object sender, SdlDotNet.Input.KeyboardEventArgs args)
        {
            if (args.Down)
            {
                switch (args.Key)
                {
                    case SdlDotNet.Input.Key.Escape:
                        Events.QuitApplication();
                        break;
                }
            }
        }


        // --------------------------
        // ----- GAME Utilities -----  
        // --------------------------

        // draw the background image onto the frame
        static void drawBackground() {
            video.Blit(background);
        }

        // draw the sprite image onto the frame
        // Sprite sprite - which sprite to draw
        // int x, int y - the co-ordinates of where to draw the sprite on the frame.
        static void drawSprite(int sprite, int x, int y, int direction) {
            Surface temp1 = sprites.CreateSurfaceFromClipRectangle(ss.getRectangle(sprite));
            Surface temp2 = temp1.CreateRotatedSurface(direction,false);
            Surface temp3 = temp2.Convert(video,false,false);
            temp3.SourceColorKey = temp3.GetPixel(new Point(0, 0));
            video.Blit(temp3, new Point(x - (temp3.Width / 2), y - (temp3.Height / 2)));
            temp3.Dispose();
            temp2.Dispose();
            temp1.Dispose();
        }


        // -- APPLICATION ENTRY POINT --

        static void Main() {

            //System.Windows.Forms.Cursor.Hide();
            ss = SpriteSheet.load("images/config.csv");

            // Create display surface.
            video = Video.SetVideoMode(FRAME_WIDTH, FRAME_HEIGHT, COLOUR_DEPTH, FRAME_RESIZABLE, USE_OPENGL, FRAME_FULLSCREEN, USE_HARDWARE);
            Video.WindowCaption = "Shmup";
            Video.WindowIcon(new Icon(@"images/shmup.ico"));

            // invoke application initialisation subroutine
            setup();

            // invoke secondary initialisation subroutine
            onInit();

            // register event handler subroutines
            Events.Tick += new EventHandler<TickEventArgs>(onTick);
            Events.Quit += new EventHandler<QuitEventArgs>(onQuit);
            Events.KeyboardDown += new EventHandler<SdlDotNet.Input.KeyboardEventArgs>(onKeyboard);
            Events.KeyboardUp += new EventHandler<SdlDotNet.Input.KeyboardEventArgs>(onKeyboard);
            Events.MouseButtonDown += new EventHandler<SdlDotNet.Input.MouseButtonEventArgs>(onMouseButton);
            Events.MouseButtonUp += new EventHandler<SdlDotNet.Input.MouseButtonEventArgs>(onMouseButton);
            Events.MouseMotion += new EventHandler<SdlDotNet.Input.MouseMotionEventArgs>(onMouseMove);

            // while not quit do process events
            Events.TargetFps = 60;
            Events.Run();
        }

        // This procedure is called after the video has been initialised but before any events have been processed.
        static void setup() {

            // Load Art
            sprites = new Surface(ss.getImagefile());

            backgroundColour = sprites.GetPixel(new Point(200, 200));

            background = video.CreateCompatibleSurface();
            background.Transparent = false;
            background.Fill(backgroundColour);

        }

        // This procedure is called when the event loop receives an exit event (window close button is pressed)
        static void onQuit(object sender, QuitEventArgs args) {
            Events.QuitApplication();
        }

        // -- DATA --

        const int FRAME_WIDTH = 1366;
        const int FRAME_HEIGHT = 768;
        const int COLOUR_DEPTH = 32;
        const bool FRAME_RESIZABLE = false;
        const bool FRAME_FULLSCREEN = true;
        const bool USE_OPENGL = false;
        const bool USE_HARDWARE = true;

        static Surface video;  // the window on the display

        static Surface background;
        static Surface sprites;

        static Color backgroundColour;

    }
}
