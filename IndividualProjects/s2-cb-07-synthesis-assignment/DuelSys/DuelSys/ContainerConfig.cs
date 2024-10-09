using Autofac;
using DataLayer;
using LogicLayer;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelSys
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<TournamentManagement>().As<ITournamentService>();
            builder.RegisterType<TournamentAdmin>().AsSelf().SingleInstance();

            builder.RegisterType<MatchManagement>().As<IMatchService>();
            builder.RegisterType<MatchAdmin>().AsSelf().SingleInstance(); 

            builder.RegisterType<UserManagement>().As<IUserService>();
            builder.RegisterType<UserAdmin>().AsSelf().SingleInstance();

            builder.RegisterType<UserData>().As<ILoginService>();
            builder.RegisterType<LoginAdmin>().AsSelf().SingleInstance();
            
            builder.RegisterType<SportManagement>().As<ISportService>();
            builder.RegisterType<SportAdmin>().AsSelf().SingleInstance();

            builder.RegisterType<UserHelper>().AsSelf().SingleInstance();

            builder.RegisterType<Dashboard>();
            return builder.Build();
        }
    }
}
