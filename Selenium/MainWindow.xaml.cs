using ClosedXML.Excel;
using Newtonsoft.Json;
using OfficeOpenXml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows;

namespace Selenium
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

             string pathExcel = @"E:\"
                + txtSearch.Text.Replace(" ","")
                + DateTime.Now.ToString("yyyyMMdd")
                + ".xlsx";
            const string sheetName = "All";
            const int sleepTime = 500;
            const string windowHeight = "1500";
            //string textSheet = 

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--disable-notifications");

            ChromeDriver chromeDriver = new ChromeDriver(options);

            chromeDriver.Url = "https://facebook.com";
            chromeDriver.Navigate();
            chromeDriver.Manage().Window.Maximize();
            var loginEmail = chromeDriver.FindElementById("email");
            loginEmail.SendKeys(txtAccount.Text);
            var pass = chromeDriver.FindElementById("pass");
            pass.SendKeys(txtPassword.Password);
            var loginBtn = chromeDriver.FindElementById("u_0_b");
            loginBtn.Click();
            Thread.Sleep(1000);
            var result = new List<object>();
            string q = "/search?q=" + txtSearch.Text.Replace(" ", "%20");
            string newLine = Environment.NewLine;
            List<string> listPage = new List<string>();
            if (!string.IsNullOrWhiteSpace(tbMultiLine.Text))
            {
                List<string> listString = tbMultiLine.Text.Split(newLine.ToCharArray()).ToList();
                for (var i = 0; i < listString.Count; i++)
                {
                    if (!string.IsNullOrWhiteSpace(listString[i]) && (listString[i].Contains("http://") || listString[i].Contains("https://")))
                    {
                        listPage.Add(listString[i]);
                    }
                }
            }

            IJavaScriptExecutor js = (IJavaScriptExecutor)chromeDriver;

            for (int i = 0; i < listPage.Count; i++)
            {
                List<object> x = new List<object>();

                chromeDriver.Url = listPage[i] + q;
                chromeDriver.Navigate();
                Thread.Sleep(2000);
                js.ExecuteScript(@"
                function getElementByXpath(path) { return document.evaluate(path, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;}
                  getElementByXpath('/html/body/div[1]/div/div/div[1]/div[3]/div/div/div[1]/div[1]/div[1]/div/div[3]/div[1]/div[2]/div[2]/div[2]/div/div[2]/div/input').click();");
                Thread.Sleep(1000);
                js.ExecuteScript(@"
function getElementByXpath(path) { return document.evaluate(path, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;}
                 getElementByXpath('/html/body/div[1]/div/div/div[1]/div[3]/div/div/div[1]/div[1]/div[1]/div/div[3]/div[1]/div[2]/div[2]/div[5]/div/div/div').click();  
                    ");
                Thread.Sleep(1000);
                js.ExecuteScript(@"
function getElementByXpath(path) { return document.evaluate(path, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;}
                 getElementByXpath('/html/body/div[1]/div/div/div[1]/div[3]/div/div/div[2]/div/div/div[1]/div[1]/div/div/div/div/div[1]/div').firstElementChild.click();
                    ");

                int index = 1;
                do
                {
                    js.ExecuteScript("window.scrollBy(0," + windowHeight + ")");
                    Thread.Sleep(sleepTime);
                    js.ExecuteScript("window.scrollBy(0," + windowHeight + ")");
                    Thread.Sleep(sleepTime);
                    js.ExecuteScript("window.scrollBy(0," + windowHeight + ")");
                    Thread.Sleep(sleepTime);
                    js.ExecuteScript("window.scrollBy(0," + windowHeight + ")");
                    Thread.Sleep(sleepTime);
                    js.ExecuteScript("window.scrollBy(0," + windowHeight + ")");
                    Thread.Sleep(sleepTime);
                    js.ExecuteScript("window.scrollBy(0," + windowHeight + ")");
                    Thread.Sleep(sleepTime);
                    js.ExecuteScript("window.scrollBy(0," + windowHeight + ")");
                    Thread.Sleep(sleepTime);

                    var lst = (string)js.ExecuteScript(@"

var constParent = '/html/body/div[1]/div/div/div[1]/div[3]/div/div/div[1]/div/div[2]/div/div/div/div/div/div';

function getElementByXpath(path) {
    return document.evaluate(path, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
}

var xrootE = getElementByXpath(constParent);
var lstArr = [];

for (var j = 0;  j < xrootE.childNodes.length-1; j++) { // lastChild is not the target

    i = j + 1;
    
        var obj = {
            xLinkBaiDangfb, xTenFb, xLinkTenFb, xNgaydang, xNoiDung
        }
        var xLinkBaiDangfb = constParent + '/div[' + i + ']/div/div/div/div/div[1]/div/div[2]/div/div/span/div/a[1]';
        var xTenFb = constParent + '/div[' + i + ']/div/div/div/div/div[1]/div/div[2]/div/div/span/div/a[1]/span';
        var xLinkTenFb = constParent + '/div[' + i + ']/div/div/div/div/div[3]/a';
        var xNgaydang = constParent + '/div[' + i + ']/div/div/div/div/div[3]/a/div/div[1]/span/div/span';
        var xNoiDung = constParent + '/div[' + i + ']/div/div/div/div/div[3]/a/div/div[1]/span/div';
        if (getElementByXpath(xTenFb)) {
            obj.xTenFb = getElementByXpath(xTenFb).innerText;
        }

        var xNgayDangSpan = getElementByXpath(xNgaydang);
        var xNoiDungDiv = getElementByXpath(xNoiDung);
        if (xNgayDangSpan !== null && xNgayDangSpan !== 'undefined') {
            obj.xNgaydang = xNgayDangSpan.innerText;
        }
        if (xNoiDungDiv !== null && xNgayDangSpan !==null) {
            xNoiDungDiv.removeChild(xNgayDangSpan);
            obj.xNoiDung = xNoiDungDiv.innerText;
        }else if(xNoiDungDiv !== null){
            obj.xNoiDung = xNoiDungDiv.innerText;
        }
        if (getElementByXpath(xLinkBaiDangfb) !== null) {
            obj.xLinkBaiDangfb = getElementByXpath(xLinkBaiDangfb).getAttribute('href');
        }

        if (getElementByXpath(xLinkTenFb) !== null) {
            obj.xLinkTenFb = getElementByXpath(xLinkTenFb).getAttribute('href');
        }

        var item = {
            'xLinkBaiDangfb': obj.xLinkBaiDangfb,
            'xTenFb' :  obj.xTenFb, 
            'xLinkTenFb' : obj.xLinkTenFb, 
            'xNgaydang' : obj.xNgaydang,
            'xNoiDung' : obj.xNoiDung
}
        
        lstArr.push(item);
   

}

return JSON.stringify(lstArr);

");

                    //List<object> resultp =((IEnumerable)lst).Cast<object>().ToList();

                    JavaScriptSerializer json_serializer = new JavaScriptSerializer();

                    x.AddRange((IEnumerable<object>)json_serializer.DeserializeObject(lst));
                    index++;
                    if (index > 35) {
                        break;
                    }
                }
                while (x.Count() < 250);

                result.AddRange(x);
            }
            //var test = chromeDriver.FindElement(By.XPath("https://www.facebook.com/groups/donnhachosach/"));


            DataTable dt = new DataTable();
            dt.TableName = "TestTable";
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("Tên Facebook", typeof(string));
            dt.Columns.Add("Link Facebook", typeof(string));
            dt.Columns.Add("Link bài đăng", typeof(string));
            dt.Columns.Add("Thời gian đăng", typeof(string));
            dt.Columns.Add("Nội dung bài đăng", typeof(string));

            for (var i = 0; i < result.Count; i++)
            {


                Dictionary<string, object> item1 = (Dictionary<string, object>)result[i];

                object val1 = null, val2 = null, val3 = null, val4 = null, val5 = null;
                if (item1.TryGetValue("xLinkBaiDangfb", out val1)
                    && item1.TryGetValue("xTenFb", out val2)
                   && item1.TryGetValue("xLinkTenFb", out val3)
                    && item1.TryGetValue("xNgaydang", out val4)
                    && item1.TryGetValue("xNoiDung", out val5))
                {
                    val1 = item1["xTenFb"];
                    val2 = item1["xLinkBaiDangfb"];
                    val3 = item1["xLinkTenFb"];
                    val4 = item1["xNgaydang"];
                    val5 = item1["xNoiDung"];
                }
                dt.Rows.Add(
                    i + 1,
                     val1 != null ? val1.ToString() : "",
                     val2 != null ? val2.ToString() : "",
                     val3 != null ? val3.ToString() : "",
                     val4 != null ? val4.ToString().Replace(" · \n · ", "") : "",
                     val5 != null ? val5.ToString() : "");
                dt.AcceptChanges();
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                wb.SaveAs(pathExcel);

            }
            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //if (File.Exists(pathExcel))
            //{


            //    FileInfo fi2 = new FileInfo(pathExcel);

            //    using (ExcelPackage excelPackage = new ExcelPackage(fi2))
            //    {
            //        ExcelWorksheet firstWorksheet = excelPackage.Workbook.Worksheets[sheetName];
            //        firstWorksheet.Cells["A1:B5000"].Clear();
            //        for (int j = 0; j < result.Count; j++)
            //        {
            //            Dictionary<string, object> item1 = (Dictionary<string, object>)result[j];

            //            object val1 = null, val2 = null, val3 = null, val4 = null, val5 = null;
            //            if (item1.TryGetValue("xLinkBaiDangfb", out val1)
            //                && item1.TryGetValue("xTenFb", out val2)
            //               && item1.TryGetValue("xLinkTenFb", out val3)
            //                && item1.TryGetValue("xNgaydang", out val4)
            //                && item1.TryGetValue("xNoiDung", out val5))
            //            {
            //                val1 = item1["xTenFb"];
            //                val2 = item1["xLinkBaiDangfb"];
            //                val3 = item1["xLinkTenFb"];
            //                val4 = item1["xNgaydang"];
            //                val5 = item1["xNoiDung"];
            //            }
            //            firstWorksheet.Cells["A" + (j + 2).ToString()].Value = j;
            //            firstWorksheet.Cells["B" + (j + 2).ToString()].Value = val1 != null ? val1.ToString() : "";
            //            firstWorksheet.Cells["C" + (j + 2).ToString()].Value = val2 != null ? val2.ToString() : "";
            //            firstWorksheet.Cells["D" + (j + 2).ToString()].Value = val3 != null ? val3.ToString() : "";
            //            firstWorksheet.Cells["E" + (j + 2).ToString()].Value = val4 != null ? val4.ToString().Replace(" · \n · ", "") : "";
            //            firstWorksheet.Cells["F" + (j + 2).ToString()].Value = val5 != null ? val5.ToString() : "";
            //        }
            //        excelPackage.SaveAs(fi2);
            //    }
            //}
            //else
            //{

            //    using (ExcelPackage excelPackage = new ExcelPackage())
            //    {

            //        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(sheetName);
            //        for (int j = 0; j < result.Count; j++)
            //        {
            //            Dictionary<string, object> item1 = (Dictionary<string, object>)result[j];

            //            object val1 = null, val2 = null, val3 = null, val4 = null, val5 = null;
            //            if (item1.TryGetValue("xLinkBaiDangfb", out val1)
            //                && item1.TryGetValue("xTenFb", out val2)
            //               && item1.TryGetValue("xLinkTenFb", out val3)
            //                && item1.TryGetValue("xNgaydang", out val4)
            //                && item1.TryGetValue("xNoiDung", out val5))
            //            {
            //                val1 = item1["xTenFb"];
            //                val2 = item1["xLinkBaiDangfb"];
            //                val3 = item1["xLinkTenFb"];
            //                val4 = item1["xNgaydang"];
            //                val5 = item1["xNoiDung"];
            //            }
            //            worksheet.Cells["A" + (j + 2).ToString()].Value = j;
            //            worksheet.Cells["B" + (j + 2).ToString()].Value = val1 != null ? val1.ToString() : "";
            //            worksheet.Cells["C" + (j + 2).ToString()].Value = val2 != null ? val2.ToString() : "";
            //            worksheet.Cells["D" + (j + 2).ToString()].Value = val3 != null ? val3.ToString() : "";
            //            worksheet.Cells["E" + (j + 2).ToString()].Value = val4 != null ? val4.ToString().Replace(" · \n · ", "") : "";
            //            worksheet.Cells["F" + (j + 2).ToString()].Value = val5 != null ? val5.ToString() : "";
            //        }
            //        FileInfo fi = new FileInfo(pathExcel);
            //        excelPackage.SaveAs(fi);
            //    }
            //}
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
                
        }
    }
}
