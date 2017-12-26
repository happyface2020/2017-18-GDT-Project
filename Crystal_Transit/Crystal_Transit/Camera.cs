using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal_Transit
{
    public class Camera // by: sean https://goo.gl/bYojjD
    {
        public Matrix Transfrom { get; private set; }

        public void Follow(Hero target)
        {
            var position = Matrix.CreateTranslation( //makes the camera follow the target by target.position
                -target.position.X,
                -target.position.Y, 
                0);

            var offset = Matrix.CreateTranslation( // postion of hero on screen
                (Game1.WindowWidth / 2) - (target.texture.Width / 2 ),
                (Game1.WindowHeight / 2) - (target.texture.Height / 2),
                0);

            Transfrom = position * offset;
        }
    }
}
