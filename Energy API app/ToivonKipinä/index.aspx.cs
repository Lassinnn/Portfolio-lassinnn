using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Xml;
using System.Globalization;

namespace ToivonKipinä
{
    public partial class index : System.Web.UI.Page
    {
        public void Hae_Tiedot(object sender, EventArgs e)
        {
            double FinGrid(int id, string paiva, int vv)
            {
                string usernamePassword = "k6UP1uAdwf7Iml5OxoMVf85pMWRlTmYF14S68qTn";
                double tuotantomäärä = 0;
                StringWriter writer = new StringWriter();
                WebRequest myReq = WebRequest.Create(@"https://api.fingrid.fi/v1/variable/" + id + "/events/xml?start_time=" + paiva + "T00%3A00%3A00Z&end_time="+ paiva +"T23%3A59%3A59Z");
                myReq.Headers.Add("x-api-key", usernamePassword);
                WebResponse response = myReq.GetResponse();                                 // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();                           // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);                         // Read the content.
                string responseFromServer = reader.ReadToEnd();                             // Now this string includes all data from the external web site for further use

                int n = 0;
                string[] valuet = new string[1000];                                         //taulukon alustaminen
                double[] määrä = new double[1000];
                using (StringReader stringReader = new StringReader(responseFromServer))    //parserointi
                using (XmlTextReader xmlReader = new XmlTextReader(stringReader))
                {
                    while (xmlReader.Read())
                    {
                        if (xmlReader.IsStartElement())
                        {
                            switch (xmlReader.Name)
                            {
                                case "value":
                                    valuet[n] = xmlReader.ReadString();
                                    valuet[n] = valuet[n].Replace('.',',');
                                    määrä[n] = Convert.ToDouble(valuet[n]);
                                    tuotantomäärä += (määrä[n] / vv);
                                    n++;
                                    break;
                            }
                        }
                    }
                }
                return tuotantomäärä;
            }

            yvResult.InnerHtml = "";
            lvResult.InnerHtml = "";
            avResult.InnerHtml = "";
            tvResult.InnerHtml = "";
            vvResult.InnerHtml = "";
            error.InnerHtml = "";
            ohjeValitse.InnerHtml = "";

            int kokoID = 74;// kokoaistuotanto ID 74 60min
            int tarkastelu = 1;
            double kokonaisTuotanto = FinGrid(kokoID, pvm.Value, tarkastelu);

            if ((!ydinvoima.Checked) && (!lauhdevoima.Checked) && (!aurinkovoima.Checked) && (!tuulivoima.Checked) && (!vesivoima.Checked))
            {
                ohjeValitse.InnerHtml = "<p style='color:red;'>Valitse 1 tai useampi tuotanto muoto</p>";
                error.InnerHtml = "<p style='color:red; size:10,5px;'>Valitse tuotantomuodot</p>";
            }
            else
            {
                paivamaaraOutPut.InnerHtml = pvm.Value;
                if (ydinvoima.Checked) //3 min tarkasteluväli
                {
                    int vv = 20;
                    int id = 188;
                    double haettuTuotanto = FinGrid(id, pvm.Value, vv);
                    double osuusKokonais = (haettuTuotanto / kokonaisTuotanto * 100);
                    yvResult.InnerHtml = $"Ydinvoimaa on tuotettu: <span class='result'>{haettuTuotanto.ToString("0.00")} MW</span> ({osuusKokonais.ToString("0.00")}%)";
                }
                /*if (lauhdevoima.Checked)//kaukolämpö | 3min tarkasteluväli
                {
                    int vv = 20;
                    int id = 201;
                    double haettuTuotanto = FinGrid(id, pvm.Value, vv);
                    double osuusKokonais = (haettuTuotanto / kokonaisTuotanto * 100);
                    
                    lvResult.InnerHtml = "Lauhdevoimaa on tuotettu: <span class=" + (char)34 + "result" + (char)34 + ">" + haettuTuotanto + " MW/h</span>";
                }*/
                if (aurinkovoima.Checked)//60min ennuste
                {
                    int vv = 1;
                    int id = 248;
                    double haettuTuotanto = FinGrid(id, pvm.Value, vv);
                    double osuusKokonais = (haettuTuotanto / kokonaisTuotanto * 100);
                    avResult.InnerHtml = $"Aurinkovoimaa on tuotettu: <span class='result'>{haettuTuotanto.ToString("0.00")} MW</span> ({osuusKokonais.ToString("0.00")}%)";
                }
                if (tuulivoima.Checked)//3min tarkasteluväli
                {
                    int vv = 20;
                    int id = 181;
                    double haettuTuotanto = FinGrid(id, pvm.Value, vv);
                    double osuusKokonais = (haettuTuotanto / kokonaisTuotanto * 100);
                    tvResult.InnerHtml = $"Tuulivoimaa on tuotettu: <span class='result'>{haettuTuotanto.ToString("0.00")} MW</span> ({osuusKokonais.ToString("0.00")}%)";
                }
                if (vesivoima.Checked)//3min tarkasteluväli
                {
                    int vv = 20;
                    int id = 191;
                    double haettuTuotanto = FinGrid(id, pvm.Value, vv);
                    double osuusKokonais = (haettuTuotanto / kokonaisTuotanto * 100);
                    vvResult.InnerHtml = $"Vesivoimaa on tuotettu: <span class='result'>{haettuTuotanto.ToString("0.00")} MW</span> ({osuusKokonais.ToString("0.00")}%)";
                }
            }
        }
    }
}