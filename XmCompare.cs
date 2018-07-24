using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.XmlDiffPatch;
using System.Configuration;




namespace XmlCompare
{
    public partial class XmCompare : Form
    {
        public XmCompare()
        {
            InitializeComponent();
        }

        static string logFilePath;
        static string excludeAttributesAdd;
        static string excludeAttributesChange;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string zipfilepath,extractpath,filetypetoextract;
                zipfilepath = txtzipfilepath.Text;
                extractpath = txtextractpath.Text;
                filetypetoextract = txtfiletype.Text;
                Unzipfiles(zipfilepath, extractpath, filetypetoextract);
            }
            catch(Exception ex)
            {
                Log("Unzip " + ex.Message);
            }

        }

        private Boolean Unzipfiles(string zipfilepath, string extractpath, string filetypetoextract)
        {
            try
            {
                string batchNumber;
                Int64 intFileCount;

                this.Cursor = Cursors.WaitCursor;
                var zipFiles = Directory.GetFiles(zipfilepath, "*.*").Select(f => Path.GetFileName(f));
                intFileCount= Directory.GetFiles(zipfilepath, "*.*").Length;
                if (intFileCount == 0 )
                {
                    MessageBox.Show("No Files to Unzip");
                }
                foreach (string filename in zipFiles)
                {
                    
                    batchNumber = filename.Substring(12, 8) + filename.Substring(25, 10);
                    if (Directory.Exists(extractpath) == false)
                    {
                        Directory.CreateDirectory(extractpath);
                    }
                    
                    using (ZipArchive archive = ZipFile.OpenRead(zipfilepath + @"\" + filename))
                    {
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            if (entry.FullName.EndsWith(filetypetoextract, StringComparison.OrdinalIgnoreCase))
                            {
                                entry.ExtractToFile(Path.Combine(extractpath, batchNumber + "_" + entry.FullName));
                            }
                        }
                    }

                }
                MessageBox.Show("Unzip Successfull");
                this.Cursor = Cursors.Default;
                return true;
            }
            catch (Exception ex)
            {
                Log("Exception occured while Unzipping."  + ex.Message);
                this.Cursor = Cursors.Default;
                return false;
            }

        }

       
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string pathSource, pathDestination, diffFilePath;
                pathSource = ConfigurationManager.AppSettings["SourceFoldertoCompare"];
                pathDestination = ConfigurationManager.AppSettings["DestFoldertoCompare"];
                diffFilePath = ConfigurationManager.AppSettings["DiffFilesFolder"];
                excludeAttributesAdd = ConfigurationManager.AppSettings["ExcludeAttributesAdd"];
                excludeAttributesChange = ConfigurationManager.AppSettings["ExcludeAttributesChange"];
                CompareFiles(pathSource, pathDestination, diffFilePath);
                this.Cursor = Cursors.Default;
                MessageBox.Show("Comparison Completed");
            }
            catch (Exception ex)
            {
                Log("Exception occured while compare." + ex.Message);
                this.Cursor = Cursors.Default;
            }
                      
        }

        private bool CompareFiles(string pathSource, string pathDestination, string diffFilePath)
        {
            string indexfiletocompare1="",  diffFile;
            string[] excludeAttributesAddarr;
            string[] excludeAttributesChangearr;
            bool compareFragments = false;
            bool deletediffFile = false;
            bool isEqual = false;
            int i;
            try
            {
                var Indexfiles = Directory.GetFiles(pathSource, "*.xml").Select(f => Path.GetFileName(f));
                excludeAttributesAddarr = excludeAttributesAdd.Split(',');
                excludeAttributesChangearr = excludeAttributesChange.Split(',');
                foreach (string filename in Indexfiles)
                {
                    string[] indexfiletocompare = Directory.GetFiles(pathDestination, filename);
                    if (indexfiletocompare.Length > 0)
                    {
                        deletediffFile = false;
                        indexfiletocompare1 = Path.Combine(pathSource, filename);
                        XmlDiff diff = new XmlDiff();
                        diffFile = diffFilePath + filename ;
                        XmlTextWriter tw = new XmlTextWriter(new StreamWriter(diffFile));
                        tw.Formatting = Formatting.Indented;
                        isEqual = diff.Compare(indexfiletocompare1, indexfiletocompare[0], compareFragments, tw);
                        tw.Close();
                        if (isEqual == false)
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.Load(diffFile);
                            XmlNodeList elemList = doc.GetElementsByTagName("xd:change");
                            for (i = 0; i <= (elemList.Count - 1); i++)
                            {
                                if (excludeAttributesChangearr.Contains(elemList[i].Attributes[0].InnerText) == false)
                                {
                                    deletediffFile = true;
                                    break;
                                 
                                }
                                                              
                            }
                            XmlNodeList elemListadd = doc.GetElementsByTagName("xd:add");
                            for (i = 0; i <= (elemListadd.Count - 1); i++)
                            {
                                if (excludeAttributesAddarr.Contains(elemListadd[i].Attributes[0].Name) == false)
                                {
                                    deletediffFile = true;
                                    break;
                                }

                            }
                            if (!deletediffFile)
                            {
                                File.Delete(diffFile);
                            }
                        }
                        else
                        {
                            File.Delete(diffFile);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Log("Exception while comparing" + indexfiletocompare1 + ex.Message);
                this.Cursor = Cursors.Default;
                return false;
            }
        }

        private void XmCompare_Load(object sender, EventArgs e)
        {
            logFilePath = ConfigurationManager.AppSettings["LogFilePath"];
        }

        public  static void Log(string logMessage)
        {
            using (StreamWriter w = File.AppendText(logFilePath))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                w.WriteLine("  :");
                w.WriteLine("  :{0}", logMessage);
                w.WriteLine("-------------------------------");
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            int i;
            string[] excludeAttributesAddarr = { };
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\.Net TFC Test\201805280007183919_Index.xml");
            XmlNodeList elemList = doc.GetElementsByTagName("xd:change");
            for (i = 0; i <= elemList.Count -1 ; i++)
            {
                if (excludeAttributesAddarr.Contains(elemList[i].Attributes[0].InnerText) == false)
                {
                    //break;
                }   

            }
            XmlNodeList elemListAdd = doc.GetElementsByTagName("xd:add");
            for (i = 0; i <= elemListAdd.Count -1; i++)
            {
                if (excludeAttributesAddarr.Contains(elemListAdd[i].Attributes[0].Name) == false)
                {
                    //break;
                }

            }
        }



    }
}
