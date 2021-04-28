using System;
using System.Collections.Generic;
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
        public ChartJs Chart { get; set; }
        public string ChartJson { get; set; }
        
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