using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Housekeeping.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace Housekeeping.Pages.Main
{
    public class ReportModel : PageModel
    {
        private readonly string _cs = "Server=main.shivum.xyz;port=1234;Database=housekeeping;Uid=root;Pwd=Derp123";

        public ChartJs Chart { get; set; }
        public string ChartJson { get; set; }
        public ChartJs MaintainanceChart { get; set; }
        public string MaintainChartJson { get; set; }



        public void OnGet()
        {
            List<string> temp1 = new List<string>();
            temp1.Add("Red");
            temp1.Add("Blue");
            temp1.Add("Yellow");
            temp1.Add("Green");
            temp1.Add("Purple");
            temp1.Add("Orange");

            List<int> temp2 = new List<int>();
            temp2.Add(12);
            temp2.Add(19);
            temp2.Add(3);
            temp2.Add(5);
            temp2.Add(2);
            temp2.Add(3);

            var chartData = ReturnGraphString(temp1, temp2, "# of Votes");

            Chart = JsonConvert.DeserializeObject<ChartJs>(chartData);
            ChartJson = JsonConvert.SerializeObject(Chart, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            });


            //string _cs = "";
            //string _users = "";
            //using (MySqlConnection connection = new MySqlConnection(_cs))
            //{
            //    var _rooms = new Dataset();
            //    MySqlDataAdapter adapter = new MySqlDataAdapter($"Select * from users = {_users}", _cs);
            //    adapter.Fill(_rooms);
            //    var Employees = new Dataset();
            //    MySqlDataAdapter adapter2 = new MySqlDataAdapter($"Select * from users = {_users}", _cs);
            //    adapter2.Fill(Employees);
            //    int clean = 0;
            //    int inspected = 0;
            //    int dirty = 0;
            //    int donotdisturb = 0;
            //    int maintReq = 0;

            //    for (int i = 0; i < _rooms.Tables[0].Rows.Count; i++)
            //    {
            //        if (Convert.ToInt32(_rooms.Tables[0].Rows[i][3]) == 1)
            //        {
            //            clean++;
            //        }
            //        else if (Convert.ToInt32(_rooms.Tables[0].Rows[i][3]) == 2)
            //        {
            //            inspected++;
            //        }
            //        else if (Convert.ToInt32(_rooms.Tables[0].Rows[i][3]) == 3)
            //        {
            //            dirty++;
            //        }
            //        else if (Convert.ToInt32(_rooms.Tables[0].Rows[i][3]) == 4)
            //        {
            //            donotdisturb++;
            //        }
            //        else if (Convert.ToInt32(_rooms.Tables[0].Rows[i][3]) == 5)
            //        {
            //            maintReq++;
            //        }
            //    }


            //Charts the Maintainance needed for all the rooms

            //Gets the data we need, it essentially gets the count of how many times a room has gone into maintainance required, HOWEVER, We can't access the data yet in code
            MySqlDataAdapter maintainAdapter = new MySqlDataAdapter("SELECT RoomNo, Count(*) From Log Where StatusChangedTo = 'Maintainance Required' GROUP BY RoomNo ORDER BY RoomNo asc", _cs); //_cs is defined at the top
            //Creates a dataset which is essentially a table
            DataSet maintainDS = new DataSet();
            //Actually puts the data we want from the SQL server into the dataset we created
            maintainAdapter.Fill(maintainDS);
            //Makes the two lists that we need
            var mainRoomNos = new List<string>();
            var mainCount = new List<int>();
            //Fills the lists we need
            for(int i = 0; i < maintainDS.Tables[0].Rows.Count; i++)
            {
                //Adds to the first list, it will loop through each row
                //Those numbers after .Rows is .Rows[RowNumber][RowColumn]
                //And since the value we get out of the dataset isn't technically a string, we convert it to a string
                mainRoomNos.Add(maintainDS.Tables[0].Rows[i]["RoomNo"].ToString());

                //Does the same thing but instead of converting to a string, it converts to an int
                mainCount.Add(Convert.ToInt32(maintainDS.Tables[0].Rows[i]["Count(*)"]));
            }

            //Get the data we need for the graph
            string maintainGraphString = ReturnGraphString(mainRoomNos, mainCount, "Maintainance Count");

            //Converts the chart string we just made into a json
            MaintainanceChart = JsonConvert.DeserializeObject<ChartJs>(maintainGraphString);
            MaintainChartJson = JsonConvert.SerializeObject(MaintainanceChart, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            });



        }

        public string ReturnGraphString(List<string> xLabel, List<int> data, string yLabel)
        {
            var chartData = @"
            {
                type: 'bar',
                responsive: true,
                data:
                {";

            //Used for the labels at the bottom of the graph
            var labels = @"
            labels: [";

            //Dynamically adds each one
            foreach(string label in xLabel)
            {
                labels += $"'{label}',";
            }
            labels += "],";

            //Adds it to the main string
            chartData += labels;

            chartData += @"
            datasets: [{";

            //Adds the y axis label
            chartData += @$"
            label: '{yLabel}',";

            //Adds Data dynamically
            var dataString = @"
            data: [";

            foreach(int value in data)
            {
                dataString += $"{value},";
            }

            dataString += "],";

            chartData += dataString;

            //Makes random colors
            var backgroundColor = @"
            backgroundColor: [";

            var borderColor = @"
            borderColor: [";
            foreach(int value in data)
            {
                Random rdm = new Random();
                var one = rdm.Next(0, 256);
                var two = rdm.Next(0, 256);
                var three = rdm.Next(0, 256);

                backgroundColor += @$"
                'rgba({one},{two},{three},0.2)',";

                borderColor += @$"
                'rgba({one},{two},{three},0.2)',";

            }

            backgroundColor += @"
            ],";
            borderColor += @"
            ],";

            chartData += backgroundColor;
            chartData += borderColor;
            chartData += @"
            borderWidth: 1
                }]
            },
            options:
            {
                scales:
                {
                    yAxes: [{
                        ticks:
                        {
                            beginAtZero: true
                        }
                    }]
                }
            }
        }";

            return chartData;

        }
    }
}
