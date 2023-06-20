using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Animation
    {
        public bool interrupt;
        private bool isLoop;
        private string name;
        public int currentFrameIndex = 0;
        private float speed = 0.5f;
        private float currentAnimationTime;
        private List<Texture> textures;
        public Texture CurrentFrame => textures[currentFrameIndex];

        public Animation(string name, List<Texture> frames, float speed, bool isLoopEnabled, bool interrupt)
        {
            this.name = name;
            this.textures = frames;
            this.speed = speed;
            this.isLoop = isLoopEnabled;
            this.interrupt = interrupt;
        }

        public void Update()
        {
            currentAnimationTime += Time.DeltaTime;

            if (currentAnimationTime >= speed)
            {
                currentFrameIndex++;
                currentAnimationTime = 0;

                if (currentFrameIndex >= textures.Count)
                {
                    if (name == "Jab" || name == "Kick" || name == "punch")
                    {
                        interrupt = false;
                    }
                    if (isLoop)
                    {
                        currentFrameIndex = 0;
                    }
                    else
                    {
                        currentFrameIndex = textures.Count - 1;
                    }
                }
            }
        }
    }
}
