using System;
using Sce.PlayStation.HighLevel.UI;

namespace StealthOfTomorrow
{
	public class GameHUD: Scene
	{
		private int screenWidth, screenHeight;
		private PlayerHUD playerHUD;
		private float Y_PADDING = 5f;
		
		public GameHUD (Character player): base ()
		{
			float xFactor = 0.5f;
			
			Initialise();
			playerHUD = new PlayerHUD(player, screenWidth * xFactor, Y_PADDING);
			this.RootWidget.AddChildLast(playerHUD);
		}
		
		public GameHUD(Character[] players, int maxPlayers): base()
		{
			float playerCount = maxPlayers;
			float xFactor = 1f / playerCount;
			
			Initialise();
			
			for(int i=1; i <= playerCount; i++)
			{
				this.RootWidget.AddChildLast(new PlayerHUD(players[i], screenWidth * xFactor * i, Y_PADDING));
			}
		}
		
		private void Initialise()
		{
			// HUD properties
			this.Title = "Main HUD";
			this.Transition = new CrossFadeTransition();
			
			// Read screen dimensions
			screenWidth = UISystem.FramebufferWidth;
			screenHeight = UISystem.FramebufferHeight;
			
		}
		override protected void OnUpdate(float dt)
		{
			playerHUD.Update(dt);
		}
		
	}
	
	class PlayerHUD : Panel
	{
		// Load images (reused)
		private static ImageAsset thumbImage = new ImageAsset("/Application/Assets/bird1.png");
		private static ImageAsset frameImage = new ImageAsset("/Application/Assets/HealthGUI/EmptyBar.png");
		private static ImageAsset verticalFrameImage = new ImageAsset("/Application/Assets/HealthGUI/EmptyVerticalBar.png");
		private static ImageAsset energyImage = new ImageAsset("/Application/Assets/HealthGUI/StaminaBar.png");
		private static ImageAsset healthImage = new ImageAsset("/Application/Assets/HealthGUI/HealthBar.png");
		private static ImageAsset livesImage = new ImageAsset("/Application/Assets/HealthGUI/Lives.png");
		
		private const int MAX_LIVES = 4;
		private const float MAX_VALUE = 100f;
		
		private Character player;
		private ImageBox energyBar, healthBar;
		private ImageBox[] lives;
		
		private float verticalFrameHeight, horizontalFrameWidth;
		
		public PlayerHUD(Character player, float x, float y): base()
		{
			this.player = player;
			float xPos = 0f;
			float yPos = 0f;
			
			// Thumbnail
			ImageBox thumb = new ImageBox();
			thumb.Image = thumbImage;
			thumb.ImageScaleType = ImageScaleType.AspectInside;
			thumb.SetSize(thumbImage.Width, thumbImage.Height);
			yPos += thumb.Height;
			xPos -= thumb.Width/2;
			thumb.SetPosition(xPos, yPos);
			this.AddChildLast(thumb);
			// Move cursor to right end of thumbnail
			xPos += thumb.Width;
			
			// Frame dimensions
			verticalFrameHeight = thumb.Height;
			float verticalFrameWidth = (verticalFrameHeight / verticalFrameImage.Height) * verticalFrameImage.Width;
			
			// Lives bar frame
			float livesSize = verticalFrameHeight / MAX_LIVES;
			ImageBox livesFrame = new ImageBox();
			livesFrame.Image = verticalFrameImage;
			livesFrame.ImageScaleType = ImageScaleType.Stretch;
			livesFrame.SetPosition(xPos, yPos);
			livesFrame.SetSize(livesSize, verticalFrameHeight);
			this.AddChildLast(livesFrame);
			// Lives in bar
			lives = new ImageBox[MAX_LIVES];
			for (int i = 0; i < player.Lives; i++)
			{
				lives[i] = new ImageBox();
				lives[i].Image = livesImage;
				lives[i].ImageScaleType = ImageScaleType.AspectInside;
				lives[i].SetPosition(xPos, yPos);
				lives[i].SetSize(livesSize, livesSize);
				this.AddChildLast(lives[i]);
				yPos += livesSize;
			}
			// Move cursor to top right end of frame
			xPos += livesSize;
			yPos -= livesSize * player.Lives;
			
			// Energy bar frame
			ImageBox energyFrame = new ImageBox();
			energyFrame.Image = verticalFrameImage;
			energyFrame.ImageScaleType = ImageScaleType.Stretch;
			energyFrame.SetPosition(xPos, yPos);
			energyFrame.SetSize(verticalFrameWidth, verticalFrameHeight);
			this.AddChildLast(energyFrame);
			// Energy bar
			energyBar = new ImageBox();
			energyBar.Image = energyImage;
			energyBar.ImageScaleType = ImageScaleType.Stretch;
			energyBar.SetPosition(xPos, yPos);
			energyBar.SetSize(verticalFrameWidth, verticalFrameHeight); // * player.Energy / MAX_VALUE);
			this.AddChildLast(energyBar);
			
			// Horizontal frame dimensions
			horizontalFrameWidth = thumb.Width + livesSize + verticalFrameWidth;
			float horizontalFrameHeight = (healthImage.Width / horizontalFrameWidth) * healthImage.Height;
			
			// Move down the frame height, and left the thumbnail and lives frame width
			yPos -= horizontalFrameHeight;
			xPos -= thumb.Width + livesSize;
			// Health bar frame
			ImageBox healthFrame = new ImageBox();
			healthFrame.Image = frameImage;
			healthFrame.ImageScaleType = ImageScaleType.Stretch;
			healthFrame.SetSize(horizontalFrameWidth, horizontalFrameHeight);
			healthFrame.SetPosition(xPos, yPos);
			this.AddChildLast(healthFrame);
			// Health bar
			healthBar = new ImageBox();
			healthBar.Image = healthImage;
			healthBar.ImageScaleType = ImageScaleType.Stretch;
			healthBar.SetSize(horizontalFrameWidth, horizontalFrameHeight);
			healthBar.SetPosition(xPos, yPos);
			this.AddChildLast(healthBar);
			
			// Position this
			this.SetPosition(x, y);
		}
		
		public void Update(float dt)
		{
			energyBar.Height = verticalFrameHeight * player.Energy / MAX_VALUE;
			healthBar.Width = horizontalFrameWidth * player.Health/MAX_VALUE;
			for(int i = MAX_LIVES - 1; i >= player.Lives; i--)
			{
				lives[i].Visible = false;
			}
		}
}
}
