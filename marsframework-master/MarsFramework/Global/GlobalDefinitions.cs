using Excel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace MarsFramework.Global
{
    class GlobalDefinitions
    {
        //Initialise the browser
        public static IWebDriver driver { get; set; }

        #region WaitforElement 

        public static void wait(int time)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);

        }

        public static IWebElement WaitForElement(IWebDriver driver, By by, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public static IWebElement WaitForElementClickable(IWebDriver driver, IWebElement element, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }
        public static Boolean WaitForElementToBeSelected(IWebDriver driver, IWebElement element, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return wait.Until(ExpectedConditions.ElementToBeSelected(element));
        }

        #endregion
        #region CommonMethods
        public static bool IsWindows()
        {
            OperatingSystem osInfo = Environment.OSVersion;
            Console.WriteLine("os is " + osInfo);
            return osInfo.ToString().Contains("Windows");
        }
        public static string GetCodeDirectory()
        {
            string BasePath = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine("BaseDirectory = " + BasePath);
            return FormatFilePath(BasePath);
        }

        public static string FormatFilePath(string FilePath)
        {
            if (FilePath == null || FilePath.Length == 0)
                return String.Empty;
            string CodeDirectoryPath = "";
            string slash;
            if (IsWindows())
            {
                slash = @"\";
            }
            else
            {
                slash = @"/";
            }
            for (int index = 0; index <= 2; index++)
            {
                CodeDirectoryPath = FilePath.Substring(0, FilePath.LastIndexOf(slash));
                FilePath = CodeDirectoryPath;
            }
            Console.WriteLine("CodeDirectoryPath = " + CodeDirectoryPath);
            return CodeDirectoryPath;
        }

        public static string FormatDateFromExcel(string date)
        {
            string subDate = date.Substring(0,10);
            Console.WriteLine("subDate = " + subDate);
            DateTime dateTime = DateTime.Parse(subDate);
            Console.WriteLine("dateTime = " + dateTime.ToString("yyyy-MM-dd"));
            return dateTime.ToString("yyyy-MM-dd");
        }

        public static string FormatTimeFromExcel(string time)
        {
            string subTime = time.Substring(10);
            Console.WriteLine("subTime = " + subTime);
            DateTime dateTime = DateTime.Parse(subTime);
            Console.WriteLine("dateTime = " + dateTime.ToString("HH:ss"));
            return dateTime.ToString("HH:ss");
        }
        #endregion



        #region Excel 
        public class ExcelLib
        {
            static List<Datacollection> dataCol = new List<Datacollection>();

            public class Datacollection
            {
                public int rowNumber { get; set; }
                public string colName { get; set; }
                public string colValue { get; set; }
            }


            public static void ClearData()
            {
                dataCol.Clear();
            }


            private static DataTable ExcelToDataTable(string fileName, string SheetName)
            {
                // Open file and return as Stream
                using (System.IO.FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                    {
                        excelReader.IsFirstRowAsColumnNames = true;

                        //Return as dataset
                        DataSet result = excelReader.AsDataSet();
                        //Get all the tables
                        DataTableCollection table = result.Tables;

                        // store it in data table
                        DataTable resultTable = table[SheetName];

                        //excelReader.Dispose();
                        //excelReader.Close();
                        // return
                        return resultTable;
                    }
                }
            }

            public static string ReadData(int rowNumber, string columnName)
            {
                try
                {
                    //Retriving Data using LINQ to reduce much of iterations

                    rowNumber = rowNumber - 1;
                    string data = (from colData in dataCol
                                   where colData.colName == columnName && colData.rowNumber == rowNumber
                                   select colData.colValue).SingleOrDefault();

                    //var datas = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;


                    return data.ToString();
                }

                catch (Exception e)
                {
                    //Added by Kumar
                    Console.WriteLine("Exception occurred in ExcelLib Class ReadData Method!" + Environment.NewLine + e.Message.ToString());
                    return null;
                }
            }

            public static void PopulateInCollection(string fileName, string SheetName)
            {
                ExcelLib.ClearData();
                DataTable table = ExcelToDataTable(fileName, SheetName);

                //Iterate through the rows and columns of the Table
                for (int row = 1; row <= table.Rows.Count; row++)
                {
                    for (int col = 0; col < table.Columns.Count; col++)
                    {
                        Datacollection dtTable = new Datacollection()
                        {
                            rowNumber = row,
                            colName = table.Columns[col].ColumnName,
                            colValue = table.Rows[row - 1][col].ToString()
                        };


                        //Add all the details for each row
                        dataCol.Add(dtTable);

                    }
                }

            }
        }

        #endregion

        #region screenshots
        public class SaveScreenShotClass
        {
            public static string SaveScreenshot(IWebDriver driver, string ScreenShotFileName) // Definition
            {
                var folderLocation = (Base.ScreenshotPath);

                if (!System.IO.Directory.Exists(folderLocation))
                {
                    System.IO.Directory.CreateDirectory(folderLocation);
                }

                var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                var fileName = new StringBuilder(folderLocation);

                fileName.Append(ScreenShotFileName);
                fileName.Append(DateTime.Now.ToString("_dd-mm-yyyy_mss"));
                //fileName.Append(DateTime.Now.ToString("dd-mm-yyyym_ss"));
                fileName.Append(".jpeg");
                screenShot.SaveAsFile(fileName.ToString(), ScreenshotImageFormat.Jpeg);
                return fileName.ToString();
            }
        }
        #endregion
    }
}