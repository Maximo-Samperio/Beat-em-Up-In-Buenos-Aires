using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class StaticScreen
    {
        private string _image;

        public StaticScreen(string image)
        {
            _image = image;
        }

        public void Update()
        {

        }
        public void Render()
        {
            Engine.Draw(_image, 0, 0);
        }
}
    
}
