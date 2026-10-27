using TwoVTwoTris.Core.Scenes;


namespace TwoVTwoTris.Core
{
    public class Game
    {
        Scene _scene; //current page singleton
        public Game()
        {
            _scene = new TestScene();
        }

        //run game updates
        public void Update()
        {
            _scene.Update();
        }

        //run draw updates
        public void Render()
        {
            _scene.Render();
        }

        //run ui updates
        public void UI()
        {
            _scene.UI();
        }

        public void GetPage()
        {

            //change page if the current page requests a change in page
            Scene nextScene = _scene.SetNextScene();
            if (nextScene is not null)
            {
                _scene = nextScene;
            }
        }
    }
}
