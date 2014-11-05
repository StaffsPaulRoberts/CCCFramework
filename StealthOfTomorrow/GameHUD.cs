using System;
using Sce.PlayStation.HighLevel.UI;

namespace StealthOfTomorrow
{
	public class GameHUD: Scene
	{
		private ImageAsset thumbImage, healthImage, energyImage, livesImage, frameImage;
		private int screenWidth, screenHeight;
		private float Y_PADDING = 5f;
		private float MAX_LIVES = 4f;
		private float MAX_VALUE = 100f;
		
		public GameHUD (Character player): base ()
		{
			float xFactor = 0.5f;
			
			Initialise();
			this.RootWidget.AddChildLast(PlayerHUD(player, screenWidth * xFactor, Y_PADDING));
		}
		
		public GameHUD(Character[] players, int maxPlayers): base()
		{
			float playerCount = maxPlayers;
			float xFactor = 1f / playerCount;
			
			Initialise();
			
			for(int i=1; i <= playerCount; i++)
			{
				this.RootWidget.AddChildLast(PlayerHUD(players[i], screenWidth * xFactor * i, Y_PADDING));
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
			
			// Load images (reused)
			thumbImage = new ImageAsset("/Application/Assets/bird1.png");
			frameImage = new ImageAsset("/Application/Assets/HealthGUI/EmptyBar.png");
			energyImage = new ImageAsset("/Application/Assets/HealthGUI/StaminaBar.png");
			healthImage = new ImageAsset("/Application/Assets/HealthGUI/HealthBar.png");
			livesImage = new ImageAsset("/Application/Assets/HealthGUI/Lives.png");
		}
		
		private Panel PlayerHUD(Character player, float x, float y)
		{
			Panel panel = new Panel();
			float xPos = 0f;
			float yPos = 0f;
			
			// Thumbnail
			ImageBox thumb = new ImageBox();
			thumb.Image = thumbImage;
			thumb.ImageScaleType = ImageScaleType.Stretch;
			thumb.SetSize(thumbImage.Width, thumbImage.Height);
			yPos += thumb.Height;
			xPos -= thumb.Width/2;
			thumb.SetPosition(xPos, yPos);
			panel.AddChildLast(thumb);
			
			float barHeight = thumb.Height - 10f;
			// Energy bar frame
			xPos += thumb.Width;
			ImageBox energyFrame = new ImageBox();
			energyFrame.Image = frameImage;
			energyFrame.ImageScaleType = ImageScaleType.Stretch;
			energyFrame.SetPosition(xPos, yPos);
			energyFrame.SetSize(frameImage.Width, barHeight);
			panel.AddChildLast(energyFrame);
			// Energy bar
			ImageBox energy = new ImageBox();
			energy.Image = energyImage;
			energy.ImageScaleType = ImageScaleType.Stretch;
			energy.SetPosition(xPos, yPos);
			energy.SetSize(energyImage.Width, barHeight * player.Energy / MAX_VALUE);
			panel.AddChildLast(energy);
			// Lives bar frame
			xPos += energy.Width;
			ImageBox livesFrame = new ImageBox();
			livesFrame.Image = frameImage;
			livesFrame.ImageScaleType = ImageScaleType.Stretch;
			livesFrame.SetPosition(xPos, yPos);
			livesFrame.SetSize(frameImage.Width, barHeight);
			panel.AddChildLast(livesFrame);
			// Lives bar
			ImageBox lives = new ImageBox();
			lives.Image = livesImage;
			lives.ImageScaleType = ImageScaleType.Stretch;
			lives.SetPosition(xPos, yPos);
			lives.SetSize(livesImage.Width, barHeight * player.Lives / MAX_LIVES);
			panel.AddChildLast(lives);
			
			float healthBarMaxWidth = thumb.Width + energyFrame.Width + livesFrame.Width;
			// Health bar frame
			xPos -= thumb.Width + energy.Width;
			ImageBox healthFrame = new ImageBox();
			healthFrame.Image = frameImage;
			healthFrame.ImageScaleType = ImageScaleType.Stretch;
			healthFrame.SetSize(healthBarMaxWidth, frameImage.Height);
			// Health bar
			ImageBox health = new ImageBox();
			health.Image = healthImage;
			health.ImageScaleType = ImageScaleType.Stretch;
			health.SetSize(healthBarMaxWidth * player.Health/MAX_VALUE, healthImage.Height);
			// Move down the bar height, and left the thumbnail and energy bar width
			yPos -= health.Height;
			healthFrame.SetPosition(xPos, yPos);
			health.SetPosition(xPos, yPos);
			panel.AddChildLast(healthFrame);
			panel.AddChildLast(health);
			
			// Position panel
			panel.SetPosition(x, y);
			return panel;
		}
	}
}
