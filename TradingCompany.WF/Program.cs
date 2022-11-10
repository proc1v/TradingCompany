using AutoMapper;
using DAL.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TradingCompany.BL.Concrete;
using TradingCompany.BL.Interfaces;
using TradingCompany.DAL.Concrete;
using TradingCompany.DAL.Interfaces;
using TradingCompany.DTO;
using Unity;

namespace TradingCompany.WF
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        //public static AppDataManager SettingsManager;
        public static UnityContainer Container;
        public static int CurrentUserID;
        public static OrderDTO CurrenOrder;

        [STAThread]
        static void Main()
        {
            ConfigureUnity();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //SettingsManager = new AppDataManager();
            //bool check = true;
            LoginForm lf = Container.Resolve<LoginForm>();

            if (lf.ShowDialog() == DialogResult.OK)
            {
                Application.Run(Container.Resolve<OrdersForm>());
            }
            else
            {
                //check = false;
                Application.Exit();
            }
        }

        private static void ConfigureUnity()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddMaps(typeof(OrderDAL).Assembly);
                });

            Container = new UnityContainer();
            Container.RegisterInstance<IMapper>(config.CreateMapper());
            Container.RegisterType<IUserDAL, UserDAL>()
                     .RegisterType<IOrderDAL, OrderDAL>()
                     .RegisterType<IReviewDAL, ReviewDAL>()
                     .RegisterType<IProductDAL, ProductDAL>()
                     .RegisterType<IAuthManager, AuthManager>()
                     .RegisterType<IOrderManager, OrderManager>()
                     .RegisterType<IReviewManager, ReviewManager>();

        }
    }
}
