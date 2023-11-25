using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeaselServer.Logger;
using WeaselServer.WeaselControllerBackend.Map;
using static System.Net.WebRequestMethods;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace WeaselServer.Roboter.Weasels.WeaselTypes
{
    internal class RealWeasel : Weasel
    {
        private string _IPAddress;
        private Thread _LastPositionUpdater;

        public RealWeasel(string Name1, int ID1, bool HasBox1,
            int HomePosition1, Color Color1) : base(ID1, HasBox1, -1, ID1+1,
            HomePosition1, Color1, Name1,
            true)
        {
            _IPAddress = "http://10.0.9.22:4567";

            _LastPositionUpdater = new Thread(GetPosition);
            _LastPositionUpdater.Start();
        }

        public override void WeaselMove(int position)
        {
            var address = _IPAddress + "/controller/move/" + _Name + "/" + position;

            var request = WebRequest.Create(address);
            request.Method = "POST";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();
            if (webStream == null) return;
            var reader = new StreamReader(webStream);
            string temp = reader.ReadToEnd();
            return;
        }

        private void GetPosition()
        {
            while(1 == 1)
            {
                WebClient wc = new WebClient();

                byte[] raw = new byte[0];

                try
                {
                    LoggerWorker.LogText("Online: Trying to get " + _Name + " last position.");
                    raw = wc.DownloadData("http://10.0.9.22:4567/weasels");

                    //Convert in an string
                    string webData = System.Text.Encoding.UTF8.GetString(raw);

                    //Create the JSON Document
                    JsonDocument doc = JsonDocument.Parse(webData);
                    JsonElement root = doc.RootElement;
                    var u1 = root[this.ID];

                    //Create string values
                    string test = u1.GetProperty("lastWaypoint") + "";
                    _LastPosition = Int32.Parse(test);
                }
                catch (Exception e)
                {
                    LoggerWorker.LogText("Error getting Weasel Position." + " " + e.ToString());
                }

                //Wait an moment before the next request
                Thread.Sleep(100);
            }
        }

        public override void RenewSetLastPosition()
        {
            try
            {
                WebClient wc = new WebClient();

                byte[] raw = new byte[0];

                LoggerWorker.LogText("Online: Trying to get " + _Name + " last position.");
                raw = wc.DownloadData("http://10.0.9.22:4567/weasels");

                //Convert in an string
                string webData = System.Text.Encoding.UTF8.GetString(raw);

                //Create the JSON Document
                JsonDocument doc = JsonDocument.Parse(webData);
                JsonElement root = doc.RootElement;
                var u1 = root[this.ID];

                //Create string values
                string test = u1.GetProperty("lastWaypoint") + "";
                _LastPosition = Int32.Parse(test);
            }
            catch (Exception e)
            {
                LoggerWorker.LogText("Error getting Weasel Position." + " " + e.ToString());
                _LastPosition =  -1;
            }
        }
    }
}
