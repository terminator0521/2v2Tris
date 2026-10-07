<<<<<<< HEAD
﻿using TwoVTwoTris.Core.Pages;
=======
﻿using RayGui_cs;
using Raylib_cs;
using System.Formats.Tar;
using System.Net.Http.Headers;
using TwoVTwoTris.Core.Pages;
>>>>>>> refs/remotes/origin/main


namespace TwoVTwoTris.Core
{
    public class Game
    {
<<<<<<< HEAD
        Page page; //current page singleton
        public Game()
=======
        IPage page; //current page singleton
        public Game() 
>>>>>>> refs/remotes/origin/main
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
<<<<<<< HEAD
=======

            //reset gui properties
            GuiStyle.LoadDefault();
>>>>>>> refs/remotes/origin/main
        }

        public void GetPage()
        {
            //change page if the current page requests a change in page
<<<<<<< HEAD
            if (page.SetNextPage() is not null)
            {

=======
            if (page.SetNextPage() is not null)  
            {
                
>>>>>>> refs/remotes/origin/main
            }
        }
    }
}
