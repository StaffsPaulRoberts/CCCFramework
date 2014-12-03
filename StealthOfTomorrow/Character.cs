using System;


using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace StealthOfTomorrow
{
	enum AttackType
	{
		highPunch,
		highKick,
		punch,
		kick,
		lowKick,
		lowPunch
	}
	
	public class Character
	{
		//private SpriteUV sprite;
		private AnimatedSprite sprite;
		private TextureInfo textureInfo;
		
		private int lives;
		private int health;
		private int energy;
		private int jumpHeight;
		private AttackType attackType;
		
		private GamePadData gamePadData;
		private bool isJumping;
		Vector2 origPos,jumpForce;
		
		private uint controllerIndex;
		
		private bool isFalling = false;
		public int Health{get {return this.health;}}
		public int Energy{get {return this.energy;}}
		public int Lives{get { return this.lives;}}
		
		
		public Character (Scene scene,AnimatedSprite animSprite, Vector2 position, uint playerNo, int lives, int health, int energy) 
		{
			
//			textureInfo  = new TextureInfo(path);
//			sprite = new SpriteUV(textureInfo);
//			sprite.Quad.S = textureInfo.TextureSizef;
//			sprite.Position = new Vector2(Director.Instance.GL.Context.GetViewport().Width/2,
//			                              Director.Instance.GL.Context.GetViewport().Height /2);
//			
//			sprite.Pivot 	= new Vector2(0.5f,1.0f);
//			sprite.CenterSprite(TRS.Local.BottomCenter);
			this.sprite = animSprite;
			this.sprite.position = position;
			isJumping = false;
			this.jumpHeight = 40;
			this.health = health;
			this.energy = energy;
			this.lives = lives;
			controllerIndex = playerNo;
			
			//this.health = health;
			//this.energy = energy;
			
			//scene.AddChild(sprite);
		}
		
		public void Dispose()
		{
			textureInfo.Dispose();	
		}
		
		public void Attack()
		{
			energy -= 10;
			Console.WriteLine("Energy: " + energy.ToString());
			if(energy <= 0)
				energy = 100;
		}
		
		public void TakeDamage(int dmg)
		{
			health -= dmg;
			Console.WriteLine("Health: " + health.ToString());
			if(health <= 0)
			{
				health = 100;
			}
		}
		
		public void Update(float deltaTime)
		{
			var gamePad = Input2.GamePad.GetData(0);
			
			int speed = 4;
			Vector2 direction = Vector2.Zero;
			
			if (controllerIndex == 0)
				direction = gamePad.Dpad;
			else if (controllerIndex == 1)
			{
				if (gamePad.Triangle.On) direction += new Vector2(0, 1);
				if (gamePad.Cross.On) direction -= new Vector2(0, 1);
				if (gamePad.Square.On) direction -= new Vector2(1, 0);
				if (gamePad.Circle.On) direction += new Vector2(1, 0);
			}
			
			if (direction != Vector2.Zero) direction.Normalize();
			
			sprite.position += direction * speed;
			
			if(isJumping)
			{
				if(!isFalling)
				{
					if(sprite.position.Y - origPos.Y < 220)//jumpheight//220)
					{
						sprite.position = new Vector2(sprite.position.X + jumpForce.X, sprite.position.Y + jumpForce.Y);
						Console.WriteLine(sprite.position);
					}
					else
						isFalling = true;
				}
				
				
				else if(isFalling)
				{
					if(sprite.position.Y > origPos.Y)
					{
						 sprite.position = new Vector2(sprite.position.X + jumpForce.X, sprite.position.Y - jumpForce.Y);
					}
					else
					{
						sprite.position = new Vector2(sprite.position.X, origPos.Y);
						Console.WriteLine(sprite.position);
						isJumping = false;
						isFalling = false;
					}
				}
			}
			
			//adjusting health and energy for testing GAMEHUD
			if ( Input2.GamePad0.Circle.Press )
			{
				lives--;
				if(lives < 0)
					lives = 4;
			}
			if ( Input2.GamePad0.Cross.Press )
			{
				TakeDamage(10);
				AnimationManager.Instance.SetSpriteState(sprite.name, "Walk");
			}
			if ( Input2.GamePad0.Square.Press )
			{
				Attack();
				AnimationManager.Instance.SetSpriteState(sprite.name, "Kick");
			}
		}
		
		private void Jump(string dir,float deltaTime,int speed)
		{
			if(!this.isJumping)
			{
				this.isJumping = true;
				this.origPos = sprite.position;
				switch (dir) 
				{
				case "Left":
					jumpForce = new Vector2(-1 * speed * deltaTime , 2 * speed * deltaTime);
					
					break;
				case "Right":
					jumpForce = new Vector2(1 * speed * deltaTime , 2 * speed * deltaTime);
					break;
				default:
					break;
				}
			}
		}
	}
}

