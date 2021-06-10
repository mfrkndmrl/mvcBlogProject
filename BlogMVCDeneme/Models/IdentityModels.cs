using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System;

namespace BlogMVCDeneme.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]        
        [Display(Name = "Ad")]
        public string Ad { get; set; }
        [Required]        
        [Display(Name = "Soyad")]
        public string Soyad { get; set; }
        public string Fotograf { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {

            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public System.Data.Entity.DbSet<BlogMVCDeneme.Models.Makale> Makales { get; set; }
        public System.Data.Entity.DbSet<BlogMVCDeneme.Models.Yorum> Yorums { get; set; }
        public System.Data.Entity.DbSet<BlogMVCDeneme.Models.MakaleEtiket> MakaleEtikets { get; set; }
        public System.Data.Entity.DbSet<BlogMVCDeneme.Models.MakaleKategori> MakaleKategoris { get; set; }



        public System.Data.Entity.DbSet<BlogMVCDeneme.Models.Etiket> Etikets { get; set; }
       

        public System.Data.Entity.DbSet<BlogMVCDeneme.Models.Kategori> Kategoris { get; set; }

        public System.Data.Entity.DbSet<BlogMVCDeneme.ViewModels.MakaleYorumView> MakaleYorumViews { get; set; }
    }
}