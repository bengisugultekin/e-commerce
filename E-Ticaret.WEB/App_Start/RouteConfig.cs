using System.Web.Mvc;
using System.Web.Routing;

namespace E_Ticaret.WEB
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
             name: "SiparisDetayi",
             url: "SiparisDetayi/{id}",
             defaults: new { controller = "Customer", action = "OrderDetail", id = UrlParameter.Optional }
         );

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
             name: "Hesabım",
             url: "Hesabım",
             defaults: new { controller = "Customer", action = "Account", id = UrlParameter.Optional }
         );

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
             name: "SiparisBilgilerim",
             url: "SiparisBilgilerim/{id}",
             defaults: new { controller = "Customer", action = "Orders", id = UrlParameter.Optional }
         );

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
             name: "KisiselBilgilerim",
             url: "KisiselBilgilerim/{id}",
             defaults: new { controller = "Customer", action = "Account", id = UrlParameter.Optional }
         );
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
             name: "UyeOl",
             url: "UyeOl",
             defaults: new { controller = "Customer", action = "Register", id = UrlParameter.Optional }
         );

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
             name: "Cikis",
             url: "Cikis",
             defaults: new { controller = "Customer", action = "Logout", id = UrlParameter.Optional }
         );

            routes.MapRoute(
              name: "Giris",
              url: "Giriş",
              defaults: new { controller = "Customer", action = "Login", id = UrlParameter.Optional }
          );

            routes.MapRoute(
               name: "Arama",
               url: "Arama",
               defaults: new { controller = "Home", action = "Search", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Odeme",
                url: "Odeme",
                defaults: new { controller = "Home", action = "Payment", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Yazar",
                url: "Yazar/{id}",
                defaults: new { controller = "Home", action = "Writer", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Sepetim",
                url: "Sepetim",
                defaults: new { controller = "Home", action = "ShoppingChart", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Kategori",
                url: "Kategori/{id}",
                defaults: new { controller = "Home", action = "Category", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Kitap-Bilgileri",
                url: "Kitap-Bilgileri/{id}",
                defaults: new { controller = "Home", action = "BookDetails", id = UrlParameter.Optional }
            );



            routes.MapRoute(
                name: "Anasayfa",
                url: "Anasayfa",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );
        }
    }
}
