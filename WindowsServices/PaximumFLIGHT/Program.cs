using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Api.Paximum
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        static void Main()
        {
            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[]
            //{
            //    new TwitterBot()
            //};
            //ServiceBase.Run(ServicesToRun);

            if (Environment.UserInteractive)
            {
                PaximumFlight PaximumService = new PaximumFlight();
                PaximumService.TestStartupAndStop();
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                 new Paximum()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
