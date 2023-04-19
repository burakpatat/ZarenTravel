using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Api
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
                TravelPort travelPortService = new TravelPort();
                travelPortService.TestStartupAndStop();
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
            new TravelPort()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
