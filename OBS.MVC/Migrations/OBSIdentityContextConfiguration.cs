namespace OBS.MVC.Migrations
{
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class OBSIdentityContextConfiguration : DbMigrationsConfiguration<OBS.MVC.Repositories.OBSIdentityContext>
    {
        public OBSIdentityContextConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OBS.MVC.Repositories.OBSIdentityContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var userManager =
new UserManager<OBS.MVC.Models.ApplicationUser>(
new Microsoft.AspNet.Identity.EntityFramework.UserStore<OBS.MVC.Models.ApplicationUser>(new OBS.MVC.Repositories.OBSIdentityContext()));

            var roleManager = new Microsoft.AspNet.Identity.RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(
            new Microsoft.AspNet.Identity.EntityFramework.RoleStore<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(
            new OBS.MVC.Repositories.OBSIdentityContext()));

            //Rolleri oluþturma
            System.Collections.Generic.List<string> roller = new System.Collections.Generic.List<string>() { "BilgiIslem", "Ogrenci", "OgretimGorevlisi" };
            foreach (string rolAdi in roller)
            {
                if (roleManager.RoleExists(rolAdi) == false) //Eðer rol veritabanýnda yok ise rolü oluþtur
                    roleManager.Create(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole(rolAdi));
            }

            string bilgiIslemKullaniciAdi = "Anil";
            if (userManager.FindByName(bilgiIslemKullaniciAdi) == null) //ugur isimli kullanýcý yoksa
            {
                //Kullanýcýyý oluþtur
                OBS.MVC.Models.ApplicationUser bilgiIslemKullanicisi = new OBS.MVC.Models.ApplicationUser()
                {
                    UserName = "Anil"
                };
                var kullaniciKayitSonuc = userManager.Create(bilgiIslemKullanicisi, "123456");

                //Kullanýcý oluþtuysa kullanýcýyý "BilgiIslem" rolüne ekle
                if (kullaniciKayitSonuc.Succeeded)
                {
                    userManager.AddToRole(bilgiIslemKullanicisi.Id, "BilgiIslem");
                }
            }



            string bilgiIslemKullaniciAdi2 = "Berkan";
            if (userManager.FindByName(bilgiIslemKullaniciAdi2) == null) //ugur isimli kullanýcý yoksa
            {
                //Kullanýcýyý oluþtur
                OBS.MVC.Models.ApplicationUser bilgiIslemKullanicisi2 = new OBS.MVC.Models.ApplicationUser()
                {
                    UserName = "Berkan"
                };
                var kullaniciKayitSonuc = userManager.Create(bilgiIslemKullanicisi2, "123456");

                //Kullanýcý oluþtuysa kullanýcýyý "BilgiIslem" rolüne ekle
                if (kullaniciKayitSonuc.Succeeded)
                {
                    userManager.AddToRole(bilgiIslemKullanicisi2.Id, "BilgiIslem");
                }
            }
        }
    }
}
