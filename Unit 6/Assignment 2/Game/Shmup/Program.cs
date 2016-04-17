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
    public class GameOver{
        private int x;
        private int y;
        private int sprite;
        private bool show;

        public GameOver(int x, int y, int sprite){
            this.x = x;
            this.y = y;
            this.sprite = sprite;
            show = false;
        }

        public void setShow(bool show)
        {
            this.show = show;
        }
        public bool getShow()
        {
            return show;
        }
        public void setX(int x){
            this.x = x;
        }
        public int getX(){
            return x;
        }
        public void setY(int y){
            this.y = y;
        }
        public int getY(){
            return y;
        }
        public void setSprite(int sprite){
            this.sprite = sprite;
        }
        public int getSprite(){
            return sprite;
        }
    }
   
    public class ScoreWord{
        private int x;
        private int y;
        private int sprite;

        public ScoreWord(int x, int y, int sprite){
            this.x = x;
            this.y = y;
            this.sprite = sprite;
        }

        public void setX(int x){
            this.x = x;
        }
        public int getX(){
            return x;
        }
        public void setY(int y){
            this.y = y;
        }
        public int getY(){
            return y;
        }
        public void setSprite(int sprite){
            this.sprite = sprite;
        }
        public int getSprite(){
            return sprite;
        }
    }
    public class TensScore{
        private int x;
        private int y;
        private int sprite;

        public TensScore(int x, int y, int sprite){
            this.x = x;
            this.y = y;
            this.sprite = sprite;
        }

        public void setX(int x){
            this.x = x;
        }
        public int getX(){
            return x;
        }
        public void setY(int y){
            this.y = y;
        }
        public int getY(){
            return y;
        }
        public void setSprite(int sprite){
            this.sprite = sprite;
        }
        public int getSprite(){
            return sprite;
        }
    }
    public class UnitsScore{
        private int x;
        private int y;
        private int sprite;

        public UnitsScore(int x, int y, int sprite){
            this.x = x;
            this.y = y;
            this.sprite = sprite;
        }

        public void setX(int x){
            this.x = x;
        }
        public int getX(){
            return x;
        }
        public void setY(int y){
            this.y = y;
        }
        public int getY(){
            return y;
        }
        public void setSprite(int sprite){
            this.sprite = sprite;
        }
        public int getSprite(){
            return sprite;
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
        public void setDY(int dy)
        {
            this.dy = dy;
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
        static Bomb[] bombs = new Bomb[10];
        static Coin[] coins = new Coin[10];
        static ScoreWord scoreWord;
        static TensScore tens;
        static UnitsScore units;
        static GameOver gameOver;

        // This procedure is called (invoked) before the first time onTick is called.
        static void onInit() {
            //int x, int y, int sprite, int direction, int rotation, int dx, int dy
            duck = new Duck(FRAME_WIDTH/2, FRAME_HEIGHT - 100, 0, 0, 0, 0, 0);
            scoreWord = new ScoreWord(1500, 50, 21);
            tens = new TensScore(1555,50,20);
            units = new UnitsScore(1580,50,20);
            gameOver = new GameOver(750,500,22);
            for(int i = 0; i < bombs.Length; i++)
            {
                bombs[i] = new Bomb(rnd.Next(FRAME_WIDTH), 0, rnd.Next(1,3), rnd.Next(360), rnd.Next(1,4), 0, rnd.Next(1,4));
            }
            for(int i = 0; i < coins.Length; i++)
            {
                coins[i] = new Coin(rnd.Next(FRAME_WIDTH), 0, rnd.Next(3,11), rnd.Next(360), rnd.Next(1, 4), 0, rnd.Next(1, 4));
            }
            
        }

        static bool checkBombsIntercept(int i)
        {
            //duck = rect 1, bomb = rect 
            if (duck.getX() < bombs[i].getX() + 48 &&
                duck.getX() + 90 > bombs[i].getX() &&
                duck.getY() < bombs[i].getY() + 62 &&
                duck.getY() - 90 < bombs[i].getY())
            {
                return true;
            }
            else
            {
                return false;
            }
            //if (rect1.x < rect2.x + rect2.width &&
              //  rect1.x + rect1.width > rect2.x &&
                //rect1.y < rect2.y + rect2.height &&
                //rect1.height + rect1.y > rect2.y) {
                // collision detected!
        }
        static bool checkCoinsIntercept(int i)
        {
            //duck = rect 1, bomb = rect 
            if (duck.getX() < coins[i].getX() + 48 &&
                duck.getX() + 90 > coins[i].getX() &&
                duck.getY() < coins[i].getY() + 62 &&
                duck.getY() - 90 < coins[i].getY())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void newScore(int score)
        {
            if(score < 10)
            {
                tens.setSprite(20);
                units.setSprite(score + 10);
            }
            else
            {
                string scoreStr = Convert.ToString(score);
                char[] scoreChar = scoreStr.ToCharArray();
                
                switch("1")
                {
                    case "1":
                        tens.setSprite(11);
                        break;
                    case "2":
                        tens.setSprite(12);
                        break;
                    case "3":
                        tens.setSprite(13);
                        break;
                }
            }
            if(score % 10 == 0)
            {
                units.setSprite(20);
            }


            
        }


        static int bombStepper = 0;
        static int coinStepper = 0;
        static int delayer = 0;
        static int score = 0;
        static int secDelayer = 201;

        // This procedure is called (invoked) for each window refresh
        static void onTick(object sender, TickEventArgs args) {

            // STEP
            // Update the automagic elements and enforce the rules of the game here.

            duck.move();

            bombStepper++;
            coinStepper++;
            delayer++;
            secDelayer++;

            if(secDelayer > 150 && secDelayer < 200){
                Events.QuitApplication();
            }
            for(int i = 0; i < bombs.Length; i++)
            {
                if(checkBombsIntercept(i))
                {
                    //Events.QuitApplication();
                    //game over
                    gameOver.setShow(true);
                    secDelayer = 0;
                }
            }

            for(int i = 0; i < coins.Length; i++)
            {
                if(checkCoinsIntercept(i))
                {
                    if(delayer>10)
                    {
                        score++;
                        newScore(score);

                        coins[i].setY(0);
                        coins[i].setX(rnd.Next(FRAME_WIDTH));
                        coins[i].setDY(rnd.Next(1, 4));

                        delayer = 0;
                    }
                }
            }

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
            if(coinStepper > 2)
            {
                for(int i = 0; i < coins.Length; i++)
                {
                    //if is on last sprite go to first
                    if(coins[i].getSprite() == 10)
                    {
                        coins[i].setSprite(4);
                    }
                    else
                    {
                        coins[i].setSprite(coins[i].getSprite()+1);
                    }
                    coinStepper = 0;
                }
            }

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
            drawSprite(scoreWord.getSprite(), scoreWord.getX(), scoreWord.getY(),0);
            drawSprite(tens.getSprite(), tens.getX(), tens.getY(),0);
            drawSprite(units.getSprite(), units.getX(), units.getY(),0);
            if(gameOver.getShow())
                drawSprite(gameOver.getSprite(), gameOver.getX(), gameOver.getY(), 0);

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

            backgroundColour = sprites.GetPixel(new Point(200, 400));

            background = video.CreateCompatibleSurface();
            background.Transparent = false;
            background.Fill(backgroundColour);

        }

        // This procedure is called when the event loop receives an exit event (window close button is pressed)
        static void onQuit(object sender, QuitEventArgs args) {
            Events.QuitApplication();
        }

        // -- DATA --

        const int FRAME_WIDTH = 1680;
        const int FRAME_HEIGHT = 1050;
        const int COLOUR_DEPTH = 32;
        const bool FRAME_RESIZABLE = false;
        const bool FRAME_FULLSCREEN = false;
        const bool USE_OPENGL = false;
        const bool USE_HARDWARE = true;

        static Surface video;  // the window on the display

        static Surface background;
        static Surface sprites;

        static Color backgroundColour;

    }
}
