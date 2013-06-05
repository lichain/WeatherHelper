using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Net.Sockets;
using WeatherAPIServices.Services;
using CommonLib.String;

namespace WeatherHelper.Models
{
        public class GPSLocation
        {
                public string County {get;set;}
                public string CountyCode { get; set; }
                public string Area {get;set;}
                public string AreaCode { get; set; }
                public double Location1 { get; set; }
                public double Location2 { get; set; }

                public static string GetCurrentIP()
                {

                    return "";
                }

                // Contributed by Gokhan Saltik
                public static string GetMaxMindOmniData(string IP)
                {
                    System.Uri objUrl = new System.Uri("http://geoip.maxmind.com/e?l=pK1gLCahHp56&i=" + IP);
                    System.Net.WebRequest objWebReq;
                    System.Net.WebResponse objResp;
                    System.IO.StreamReader sReader;
                    string strReturn = string.Empty;

                    try
                    {
                        objWebReq = System.Net.WebRequest.Create(objUrl);
                        objResp = objWebReq.GetResponse();

                        sReader = new System.IO.StreamReader(objResp.GetResponseStream());
                        strReturn = sReader.ReadToEnd();

                        sReader.Close();
                        objResp.Close();
                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
                        objWebReq = null;
                    }

                    return strReturn;
                }

                public string GetLocation(string IP)
                {
                    var location = "";
                    List<string> HTML_code = new List<string>();
                    WebRequest request = WebRequest.Create("http://www.maxmind.com/app/locate_demo_ip?ips=" + IP);
                    using (WebResponse response = request.GetResponse())
                    using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                    {
                        string line;
                        while ((line = stream.ReadLine()) != null)
                        {
                            HTML_code.Add(line);
                        }
                    }
                    location = (HTML_code[296].Replace("<td><font size=\"-1\">", "")).Replace("</font></td>", "");
                    return location;
                }

                public static string GetClientIP()
                {
                    String direction = "";
                    //WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
                    WebRequest request = WebRequest.Create("http://myip.com.tw/");
                    using (WebResponse response = request.GetResponse())
                    using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                    {
                        direction = stream.ReadToEnd();
                    }

                    //Search for the ip in the html
                    int first = direction.IndexOf("我的 IP 是 ") + 8;
                    int last = direction.LastIndexOf(" - 簡單又快速");
                    direction = direction.Substring(first, last - first);

                    return direction;
                }

                public static GPSLocation GetClientGPSLocationInfo(string IP = "")
                {
                    if (IP.Trim() == string.Empty)
                        IP = GetClientIP();

                    //Query GPS Location info by IP
                    GPSLocation gpsLocationInfo = new GPSLocation();
                    string result = "";
                    result = HttpHelper.DoHttpPost("http://www.pttip.com/server_ip2coordinates.php?nocache=1369992040861", IP);

                    //Parser string
                    result = result.Substring(1, result.Length - 2).Replace("[","").Replace("]","").Replace(@"""","");
                    string[] resultArray = result.Split(',');
                    gpsLocationInfo.County = Unicode.UnicodeToString(resultArray[2]);//.Substring(1, resultArray[2].Length-2));
                    gpsLocationInfo.CountyCode = resultArray[4];
                    gpsLocationInfo.Area = Unicode.UnicodeToString(resultArray[3]);//.Substring(1, resultArray[2].Length - 2));
                    gpsLocationInfo.Location1 = Convert.ToDouble(resultArray[0]);
                    gpsLocationInfo.Location2 = Convert.ToDouble(resultArray[1]);

                     //= result;

                    return gpsLocationInfo;
                }
        }

        
}