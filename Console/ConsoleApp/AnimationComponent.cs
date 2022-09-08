﻿using System;
namespace Lp2EpocaEspecial.ConsoleApp
{
	public class AnimationComponent : Component
	{
		private IBuffer2D<char> buffer;
		int counter = 0;
		int frames = 0;
		public AnimationComponent(IBuffer2D<char> buffer)
		{
			this.buffer = buffer;
		}

		public override void Update()
		{

			counter++;


            switch (counter)
			{
					case 0:
						buffer[0, 0] = '/';
						break;
					case 1:
						buffer[0, 0] = '|';
						break;
					case 2:
						buffer[0, 0] = '\\';
						break;
					case 3:
						buffer[0, 0] = '-';
						break;
					case 4:
						buffer[0, 0] = '/';
						break;
					case 5:
						buffer[0, 0] = '|';
						break;
					case 6:
						buffer[0, 0] = '\\';
						break;
					case 7:
						buffer[0, 0] = '-';
						counter = 0;
						break;
					default:
						buffer[0, 0] = 't';
						break;

			}


        }
	}
}