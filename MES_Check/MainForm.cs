
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace MES_Check
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private string logFolder = Path.Combine(workFolder, "log");
		public const string workFolder = @"c:\program files\reportmover";
		public MainForm()
		{
			
			InitializeComponent();
			do{
				Parse();
			} while(true);
		}
		public void Parse()
		{
			List<string> check_result = new List<string>();
			List<string> check_sn = new List<string>();
			List<string> ser_name = new List<string>();
			List<string> ser_name_f = new List<string>();
			string result = " ";
			int x = 0;
			int z = 0;
			int m = 0;
			
			string puth = " ";
			string data = " ";
//			foreach(var proc in System.Diagnostics.Process.GetProcesses())
//			{
//				try
//				{
//					if(proc.MainModule.FileName.ToUpper().StartsWith(@""))
//					{
//					//puth =
//					//data =
//					
//					} else if(proc.MainModule.FileName.ToUpper().StartsWith(@""))
//					{
//					//puth =
//					//data =
//					}
//				}catch(Exception e)
//				{
//					MessageBox.Show(e.Message);
//				
//				}
//			
//			}
			//find process  depend on proces choose path for File stream and file read all text
			Thread.Sleep(2000);
			try{
			var fs = new FileStream(@"C:\Users\plyskay\Desktop\Test\2119123178_and_5_SN_8_55_35 hh.log", FileMode.Open, FileAccess.Read, FileShare.Read | FileShare.Delete | FileShare.Write);
		
				using (var sf = new StreamReader(fs)) {
					string[] r = { "\r", "\n" };
			 
					result = sf.ReadToEnd();
					string[] par = result.Split(r, System.StringSplitOptions.RemoveEmptyEntries);
					string res = File.ReadAllText(@"C:\Users\plyskay\Desktop\Test\time.txt");//show the path where wrote:Start testing at [c=008000]Tuesday, January 29, 2019 02:14:42[/c]
					if (par[2] == res) {
						return;
					} else {
						foreach (string si in par) {
							if ((si.Contains("==============================================")) && (m == 0)) {
							
								m++;
							
								if (check_result.Count <= 2) {	
									File.WriteAllText(@"C:\Users\plyskay\Desktop\Test\time.txt", par[2]);
									return;
								}
								x = check_result.Count;
							}
					
							if (si.Contains("Result for UUT #")) { 
								check_result.Add(si);
							}	
						}
						foreach (var t in check_result) {
							if (t.Contains("FAILED")) {
								check_sn.Add(t);
								z++;
							}
						}
						if (z >= x) {
							foreach (string sew in check_sn) {
								string b = sew.Substring(0, 17);
								
								ser_name.Add(b);
							}
						}
						foreach(var dublicate in ser_name)
						{
						
							if (!ser_name_f.Contains(dublicate))
								ser_name_f.Add(dublicate);
							
						
						}
							
//						
//							for (int q = 0; q < ser_name.Count - 1;) {
//							for (int o = q + 1; o < ser_name.Count; o++) {
//								if (ser_name[q] == ser_name[o]) {
//									ser_name.Remove(ser_name[o]);
//								} 
//								
//								else{
//									q++;
//								    }
//								
//									
//							}	
//							
//						}
//						for (int q = 0; q < ser_name.Count - 1;) {
//							for (int o = q + 1; o < ser_name.Count; o++) {
//								if (ser_name[q] == ser_name[o]) {
//									ser_name.Remove(ser_name[o]);
//								} 
//								
//								else{
//									q++;
//								    }
//								
//									
//							}	
//							
//						}
//						for (int q = 0; q < ser_name.Count - 1;) {
//							for (int o = q + 1; o < ser_name.Count; o++) {
//								if (ser_name[q] == ser_name[o]) {
//									ser_name.Remove(ser_name[o]);
//								} 
//								
//								else{
//									q++;
//								    }
//								
//									
//							}	
//							
//						}
						
						if (ser_name_f.Count == x) {
							
							
							File.WriteAllText(@"C:\Users\plyskay\Desktop\Test\time.txt", par[2]);
							//rewrite file "res" with new data
							//add log write
							MessageBox.Show("KIll soft");
							return;
						}
//								File.WriteAllText(@"C:\Users\plyskay\Desktop\Test\time.txt", par[2]);
//								//rewrite file "res" with new data
//								MessageBox.Show("KIll soft");
//								return;
						
					}
				}	
			} catch (Exception e) 
			{
				_logToFile(e.ToString());
				MessageBox.Show(e.ToString());
			}
			
		}
		private void _logToFile(string text)
        {
            try
            {
                if (!Directory.Exists(logFolder))
                {
                    Directory.CreateDirectory(logFolder);
                }
                File.AppendAllText(Path.Combine(logFolder, DateTime.Now.ToString("ddMMyyyy") + ".log"), DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss:ffff") + "\t" + text + "\r\n");
            }
            catch
            { 
            }
        }

	}
}
