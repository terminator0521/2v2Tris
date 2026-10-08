using TwoVTwoTris.Core.Pages;


namespace TwoVTwoTris.Core
{
    public class Game
    {
        Scene page; //current page singleton
        public Game()
        {
            page = new TestScene();
        }

        //run game updates
        public void Update()
        {
            page.Update();
        }

        //run draw updates
        public void Render()
        {
            page.Render();
        }

        //run ui updates
        public void UI()
        {
            page.UI();
        }

        public void GetPage()
        {
            //change page if the current page requests a change in page
            if (page.SetNextScene() is not null)
            {

            }
        }
    }
}
