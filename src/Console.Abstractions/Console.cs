﻿// Copyright (c) 2019 Console.Abstractions. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

using JetBrains.Annotations;

namespace Console.Abstractions
{
	public abstract class Console : IConsole
	{
		public abstract ConsoleKeyInfo ReadKey(bool intercept);

		public void PutChar(char character, int x, int y, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
		{
			var oldX = X;
			var oldY = Y;
			var oldForeground = Foreground;
			var oldBackground = Background;

			X = x;
			Y = y;
			Foreground = foregroundColor;
			Background = backgroundColor;

			Write(character.ToString());

			X = oldX;
			Y = oldY;
			Foreground = oldForeground;
			Background = oldBackground;
		}

		public abstract int Width { get; }
		public abstract int Height { get; }

        [NotNull] public abstract string ReadLine();

		public abstract void Write([NotNull] string line);

		public abstract void Clear();

		public abstract int X { get; set; }

		public abstract int Y { get; set; }

		public abstract ConsoleColor Foreground { get; set; }

		public abstract ConsoleColor Background { get; set; }
	}
}