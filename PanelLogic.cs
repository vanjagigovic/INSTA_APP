using INSTA_APP.Models;
using INSTA_APP.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace INSTA_APP.BLL
{
    public class PanelLogic
    {
        
        INSTA_APPEntities DB = null;
        

        public PanelLogic()
        {
            DB = new INSTA_APPEntities();
        }

        public object profil { get; internal set; }

        public List<WebSitesViewModel> GetWebsites()
        {

            var data = DB.profils.Select(x => new WebSitesViewModel 
            { 
                Website = x.website, 
                Pol = x.pol 
            }).ToList();

            return data;
        }

        public void SaveObjava(objava model)
        {
            var zadnjiID = DB.objavas.Select(x => x.IDobjava).Select(int.Parse).OrderByDescending(x => x).FirstOrDefault();
            model.IDobjava = (zadnjiID + 1).ToString();

            DB.objavas.Add(model);
            DB.SaveChanges();
        }

        //public List<ObjavaViewModel> FindProfiles(string SerachTerm)
        //{
        //    var profils = DB.profils.Include(o => o.profil).AsEnumerable().Select(x => new ObjavaViewModel
        //    {
        //        IDkorisnicko_ime = x.IDkorisnicko_ime,
        //        ImeProfile = x.ime,



        //    });



        //}
        
    }
}

