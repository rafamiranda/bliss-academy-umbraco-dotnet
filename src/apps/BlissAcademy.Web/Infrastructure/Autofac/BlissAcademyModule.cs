using Autofac;
using BlissAcademy.Core.Infrastructure.AutoFac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlissAcademy.Web.Infrastructure.Autofac
{

    public class BlissAcademyModule : CoreModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
        }
    }
}
