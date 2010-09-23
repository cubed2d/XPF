namespace RedBadger.Xpf.Sandbox
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    using RedBadger.Xpf.Adapters.Xna;
    using RedBadger.Xpf.Adapters.Xna.Graphics;
    using RedBadger.Xpf.Adapters.Xna.Input;
    using RedBadger.Xpf.Controls;
    using RedBadger.Xpf.Media;

    using Color = Microsoft.Xna.Framework.Color;

    /// <summary>
    ///     This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        private RootElement rootElement;

        private SpriteBatchAdapter spriteBatchAdapter;

        public Game1()
        {
            new GraphicsDeviceManager(this) { PreferredBackBufferWidth = 1024, PreferredBackBufferHeight = 768 };

            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.CornflowerBlue);

            this.rootElement.Draw();
            base.Draw(gameTime);
        }

        protected override void LoadContent()
        {
            this.spriteBatchAdapter = new SpriteBatchAdapter(new SpriteBatch(this.GraphicsDevice));
            var renderer = new Renderer(this.spriteBatchAdapter, new PrimitivesService(this.GraphicsDevice));
            this.rootElement = new RootElement(this.GraphicsDevice.Viewport.ToRect(), renderer, new InputManager());

            var grid = new Grid
                {
                    ColumnDefinitions =
                        {
                            new ColumnDefinition(), 
                            new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) }
                        }
                };

            var left = new Border { Background = new SolidColorBrush(Colors.Red) };
            grid.Children.Add(left);

            var right = new Border { Background = new SolidColorBrush(Colors.Blue) };
            Grid.SetColumn(right, 1);
            grid.Children.Add(right);

            this.rootElement.Content = grid;
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                this.Exit();
            }

            this.rootElement.Update();
            base.Update(gameTime);
        }
    }
}