using RayGui_cs;
using TwoVTwoTris.Core.Pages;


namespace TwoVTwoTris.Core
{
    public class Game
    {
        Page page; //current page singleton
        public Game()
        {
            page = new TestPage();
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

            //reset gui properties
            GuiStyle.LoadDefault();
        }

        public void GetPage()
        {
            //change page if the current page requests a change in page
            if (page.SetNextPage() is not null)
            {

            }
        }
    }
}
