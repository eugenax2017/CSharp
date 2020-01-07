using Common.Lib.Context.Interfaces;
using Common.Lib.Infrastructure.Interfaces;
using Common.Lib.Models;
using EstadisticaDeAlumnos3_WPF_Core.Context;
using EstadisticaDeAlumnos3_WPF_Core.EFCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstadisticaDeAlumnos3_WPF_Core
{
    public class Bootstrapper
    {
        public Bootstrapper()
        {

        }

        public void Init(IDependencyContainer dp, Func<ProjectDbContext> dbContextConst)
        {
            RegisterRepositories(dp, dbContextConst);
        }

        void RegisterRepositories(IDependencyContainer dp, Func<ProjectDbContext> dbContextConst)
        {
            var studentRepoBuilder = new Func<object[], object>((parameters) =>
            {
                return new GenericRepository<Student>(dbContextConst());
            });
            var subjectsRepoBuilder = new Func<object[], object>((parameters) =>
            {
                //return new SubjectsRepository(dbContextConst());
                return new GenericRepository<Subject>(dbContextConst());
            });

            var examensRepoBuilder = new Func<object[], object>((parameters) =>
            {
                return new GenericRepository<Examen>(dbContextConst());
            });

            dp.Register<IRepository<Student>, GenericRepository<Student>>(studentRepoBuilder);
            dp.Register<IRepository<Subject>, GenericRepository<Subject>>(subjectsRepoBuilder);
            dp.Register<IRepository<Examen>, GenericRepository<Examen>>(examensRepoBuilder);
            //dp.Register<IRepository<Subject>, SubjectsRepository>(subjectsRepoBuilder);
            //dp.Register<ISubjectsRepository, SubjectsRepository>(subjectsRepoBuilder);
        }
    }
}
