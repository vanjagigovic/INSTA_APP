using INSTA_APP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace INSTA_APP.MainLogic
{
    public class MainLogic
    {
        INSTA_APPEntities DB = null;
        public MainLogic()
        {
            DB = new INSTA_APPEntities();
        }
        public void FindProfile(string korsnickoime,string ime,string prezime)
        {
           
        }
    }
}