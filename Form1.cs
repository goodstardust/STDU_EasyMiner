using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serialize.Linq;
using System.Diagnostics;

namespace WindowsFormsApp2
{
    
    public partial class Form1 : Form
    { 
        public Form1()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //CreateNewJson config = new CreateNewJson();
            string a = textBox1.Text.ToString();
            string url = textBox2.Text.ToString();
            string por = textBox3.Text.ToString();
            string thead = numericUpDown1.Text.ToString();
            CreateNewJson abc = new CreateNewJson();
            abc.r = a;
            abc.url1 = url;
            abc.por1 = por;
            abc.thead1 = thead;
            abc.CreateJson();// CreateNewJson();
            

            Process p = Process.Start("start.cmd");
            p.WaitForExit();//关键，等待外部程序退出后才能往下执行

            ///////
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
    }

    ////////////////////
    class CreateNewJson
    {
        public string r;
        public string url1;
        public string por1;
        public string thead1;

        public  void CreateJson()
        {
            string qbdz;//= "KjDRoEQiqL7A4Qeh4s7dKqdDcb6Rz85ZRd1R4fUmLH5pc1uHeHBJirRHeFJ1WWaf2tcE399zQJT9LAguetLMDmoNABjXeFv";
            if (r == "") { qbdz = "fyT32M7Y9TRXv4oWHEQBacQZicAMMmPv94TZMwu42PUTTD3LXTbuEXfcih1yi1oGpjiyF1XUf2uTadu4nD5zTwWU2gnXdwZNN"; }
            else { qbdz = r; }

            string url2 ;
            if (url1 == "") { url2 = "stardustco.org"; }
            else { url2 = url1; }

            string por2 ;
            if (por1 == "") {
                MessageBox.Show("You did not set the port, so the port is set to default 5555");
                por2 = "5555"; }
            else { por2 = por1; }

            string th2;// 
            if (thead1 == "0") {
                MessageBox.Show("Threads can not be 0, automatically set to default 2");
                th2 = "2";
            }
            else { th2 = thead1; }





            string json = @"{
                      'algo': 'cryptonight',  // cryptonight (default) or cryptonight-lite
    'av': 0,                // algorithm variation, 0 auto select
    'background': false,    // true to run the miner in the background
    'colors': true,         // false to disable colored output    
    'cpu-affinity': null,   // set process affinity to CPU core(s), mask '0x3' for cores 0 and 1
    'cpu-priority': null,   // set process priority (0 idle, 2 normal to 5 highest)
    'donate-level': 0,      // 软件抽水我已经降到了0.5 就是你赚100块钱 我得0.5块钱
    'log-file': null,       // log all output to a file, example: 'c:/some/path/xmrig.log'
    'max-cpu-usage': 75,    // maximum CPU usage for automatic mode, usually limiting factor is CPU cache not this option.  
    'print-time': 60,       // print hashrate report every N seconds
    'retries': 5,           // number of times to retry before switch to backup server
    'retry-pause': 5,       // time to pause between retries
    'safe': false,          // true to safe adjust threads and av settings for current CPU
    'threads': "+th2+ @",        // 这个设置越大CPU占有量越大
    'pools': [
        {
            'url': '" + url2 + @":" + por2 + @"',   // 矿池地址 :端口号
            'user': '" + qbdz + @"', // 复制上你的钱包地址
            'pass': 'x',                       // password for mining server
            'keepalive': true,                 // send keepalived for prevent timeout (need pool support)
            'nicehash': true,                  // enable nicehash/xmrig-proxy support
            'variant': 1  
        }
    ],
    'api': {
        'port': 0,                             // port for the miner API https://github.com/xmrig/xmrig/wiki/API
        'access-token': null,                  // access token for API
        'worker-id': null                      // custom worker-id for API
    }
}";

            JObject o = JObject.Parse(json);

            string p = @"config.json";
            //found the file exist 
            if (!File.Exists(p))
            {
                FileStream fs1 = new FileStream(p, FileMode.Create, FileAccess.ReadWrite);
                fs1.Close();
            }
            //write the json to file 
            File.WriteAllText(p, o.ToString());
        }
    }



