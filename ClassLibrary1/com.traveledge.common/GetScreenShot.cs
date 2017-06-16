using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.com.traveledge.common
{

    public class GetScreenShot
    {
        
        /// <summary>
        /// Take the Screenshot of Failed test case
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="screenShotName"></param>
        /// <returns></returns>
        public static string Capture(IWebDriver driver, string screenShotName)
        {



            //string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            //string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            //string projectPath = new Uri(actualPath).LocalPath;
            //string reportPath = projectPath + "Reports\\" + currentDate + "ADX.html";

            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "ErrorScreenshots\\" + screenShotName + ".png";
            string localpath = new Uri(finalpth).LocalPath;
            screenshot.SaveAsFile(localpath, ImageFormat.Png);
            return localpath;
        }

    }
}
