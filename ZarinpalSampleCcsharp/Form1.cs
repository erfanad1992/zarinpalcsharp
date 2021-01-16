using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace ZarinpalSampleCcsharp
{
    public partial class Form1 : Form
    {
        //in nemoone code ba estandarde Rest va mostanadate jadaid tahiye shode ast
        //ketabkhane haye morede niaz ***NewtonSoft.json*** va ***RestSharp*** ast ke az nuggetpackagemanager mitavanid nasb konid

        //ketabkhaneye restsharp be dalile sadegi dar piadesazi dar in nemoone code estefade shode ast
        //dar file code.txt piade sazi az tarighe HttpWebRequest niz anjam shode ast ke dar soorate tamayol mitavanid estefade konid


        string merchant = "424baadf-ea4c-4744-b29e-5eb62a855821";
        string amount = "10000";
        string authority;
        string description = "خرید تستی ";
        string callbackurl = "http://www.erfandn.ir";
      
        
       
        public Form1()
        {
           
            InitializeComponent();
    
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
   
            try
            {

                string[] metadata=new string[2];
                metadata[0] = "[mobile: 09121234567]";
                metadata[1] = "[email: info.test@gmail.com]";

                //be dalil in ke metadata be sorate araye ast va do meghdare mobile va email dar metadata gharar mmigirad
                //shoma mitavanid in maghadir ra az kharidar begirid va set konid dar gheir in sorat khali ersal konid

                string requesturl;
                requesturl = "https://api.zarinpal.com/pg/v4/payment/request.json?merchant_id=" +
                    merchant + "&amount=" + amount +
                    "&callback_url=" + callbackurl +
                    "&description=" + description +
                    "&metadata[0]=" + metadata[0] + "& metadata[1]=" + metadata[1];
;


                var client = new RestClient(requesturl);

                client.Timeout = -1;

                var request = new RestRequest(Method.POST);

                request.AddHeader("accept", "application/json");

                request.AddHeader("content-type", "application/json");

                IRestResponse requestresponse = client.Execute(request);

                Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Parse(requestresponse.Content);
                string errorscode = jo["errors"].ToString();

                Newtonsoft.Json.Linq.JObject jodata = Newtonsoft.Json.Linq.JObject.Parse(requestresponse.Content);
                string dataauth = jodata["data"].ToString();
  
                if (dataauth != "[]")
                {
                    
                    authority = jodata["data"]["authority"].ToString();

                    lblrequest.Text = "data = " + authority;

                    string gatewayUrl = "https://www.zarinpal.com/pg/StartPay/" + authority;
                    try
                    {
                        System.Diagnostics.Process.Start(gatewayUrl);
                    }
                    catch (System.ComponentModel.Win32Exception noBrowser)
                    {
                        if (noBrowser.ErrorCode == -2147467259)
                            MessageBox.Show(noBrowser.Message);
                    }
                    catch (System.Exception other)
                    {
                        MessageBox.Show(other.Message);
                    }

                }
                else
                {

                    MessageBox.Show("errors" + errorscode);

                }
            

            }

            catch (Exception ex)
            {
                MessageBox.Show("Wrong request ! " + ex.Message, "Error");
            }
        }

        private void btnverify_Click(object sender, EventArgs e)
        {


            try {

                string authorityverify = authority;

               // lblverify.Text = authorityverify;

                ////////////////////////////////////////////////////////////////////////////////////
                string url = "https://api.zarinpal.com/pg/v4/payment/verify.json?merchant_id=" +
                    merchant + "&amount="
                    + amount + "&authority="
                    + authorityverify;

                var client = new RestClient(url);
                client.Timeout = -1;

                var request = new RestRequest(Method.POST);

                request.AddHeader("accept", "application/json");

                request.AddHeader("content-type", "application/json");

                IRestResponse response = client.Execute(request);


                Newtonsoft.Json.Linq.JObject jodata = Newtonsoft.Json.Linq.JObject.Parse(response.Content);
                string data = jodata["data"].ToString();

                Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Parse(response.Content);
                string errors = jo["errors"].ToString();

                if (data != "[]")
                {
                    string refid = jodata["data"]["ref_id"].ToString();
                    lblverify.Text = "تراکنش موفق بوده است با شناسه " + refid;
                }
                else if (errors != "[]")
                {

                    string errorscode = jo["errors"]["code"].ToString();

                    lblverify.Text = "تراکنش ناموفق بوده است با ارور " + errorscode;

                }


            }
            catch (Exception ex)
            {
                lblverify.Text = ex.ToString();

            }

            


        

        }
    }
  

}
