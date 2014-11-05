using System;
using Sce.PlayStation.HighLevel.UI;

namespace StealthOfTomorrow
{
	public class GameHUD: Scene
	{
		private ImageBox thumb, health, energy, lives;
		
		public GameHUD (): base ()
		{
			this.Title = "Main HUD";
			this.Transition = new CrossFadeTransition();
			
			int screenWidth = UISystem.FramebufferWidth;
			int screenHeight = UISystem.FramebufferHeight;
			
			int playerCount = 1;
			float xFactor = 0.5f; //players.Count;
			float xPos = screenWidth * xFactor * playerCount;
			float yPos = screenHeight * 0.05f;
			// Thumbnail
			thumb = new ImageBox();
			thumb.Image = new ImageAsset("/Application/Assets/bird1.png");
			thumb.ImageScaleType = ImageScaleType.Stretch;
			thumb.SetSize(thumb.Image.Width, thumb.Image.Height);
			yPos += thumb.Height;
			xPos -= thumb.Width/2;
			thumb.SetPosition(xPos, yPos);
			this.RootWidget.AddChildLast(thumb);
			
			float barHeight = thumb.Height - 10f;
			// Energy bar
			xPos += thumb.Width;
			energy = new ImageBox();
			energy.Image = new ImageAsset("/Application/Assets/energy_bar.png");
			energy.ImageScaleType = ImageScaleType.Stretch;
			energy.SetPosition(xPos, yPos);
			energy.SetSize(energy.Image.Width, barHeight);
			this.RootWidget.AddChildLast(energy);
			
			// Lives bar
			xPos += energy.Width;
			lives = new ImageBox();
			lives.Image = new ImageAsset("/Application/Assets/lives_bar.png");
			lives.ImageScaleType = ImageScaleType.Stretch;
			lives.SetPosition(xPos, yPos);
			lives.SetSize(lives.Image.Width, barHeight);
			this.RootWidget.AddChildLast(lives);
			
			// Health bar
			health = new ImageBox();
			health.Image = new ImageAsset("/Application/Assets/health_bar.png");
			health.ImageScaleType = ImageScaleType.Stretch;
			health.SetSize(thumb.Width + energy.Width + lives.Width, health.Image.Height);
			// Move down the bar height, and left the thumbnail and energy bar width
			yPos -= health.Height;
			xPos -= thumb.Width + energy.Width;
			health.SetPosition(xPos, yPos);
			this.RootWidget.AddChildLast(health);
			/* Per player
			foreach(var player in players)
			{
			}
			*/
		}
	}
}
