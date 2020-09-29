/*
' Copyright (c) 2020  GIBS.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/
using GIBS.Modules.GIBSMLSImageCleaner.Components;
using System;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace GIBS.Modules.GIBSMLSImageCleaner
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from GIBSMLSImageCleanerModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class View : GIBSMLSImageCleanerModuleBase, IActionable
    {

        public string _SourcePath = "Setting Needs to be Set";
        public string _TargetPath = "Setting Needs to be Set";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Settings.Contains("SourcePath"))
                {
                    LabelSource.Text = Settings["SourcePath"].ToString();
                    _SourcePath = Settings["SourcePath"].ToString();
                    Button1.Enabled = true;
                }

                if (Settings.Contains("TargetPath"))
                {
                    LabelTarget.Text = Settings["TargetPath"].ToString();
                    _TargetPath = Settings["TargetPath"].ToString();

                }


                //foreach (string foundFile in Directory.GetFiles(@"C:\Websites\DNN941.com\Website\images\", "u*.gif", System.IO.SearchOption.TopDirectoryOnly))
                //{
                //  //   File.Copy(foundFile, @"C:\Websites\DNN941.com\Website\imagescopy\" + Path.GetFileName(foundFile));
                //    LabelShowStatus.Text += "File copied: " + foundFile + "<br />";
                //}


            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        public void RunJob()
        {
            try
            {

                List<MLSNumbersInfo> items;
                items = MLSNumbersController.GetListingNumbers();

                for (var i = 0; i < items.Count; i++)
                {
                    LabelShowStatus.Text += items[i].ListingNumber.ToString() + "<br />";
                    GetListingImages(items[i].ListingNumber.ToString());

                }

                    //foreach (string foundFile in items)
                    //{
                    //    //   File.Copy(foundFile, @"C:\Websites\DNN941.com\Website\imagescopy\" + Path.GetFileName(foundFile));
                    //    LabelShowStatus.Text += "File copied: " + foundFile + "<br />";
                    //}

                    //ImageNicheSection.ImageUrl = Settings["ImagePath"].ToString() + items[0].Photo.ToString();
                    //ImageNicheSection.AlternateText = "Niche " + items[0].SectionName.ToString();

                    //lblSectionTitle.Text = "Niche " + items[0].SectionName.ToString();


                    //var _NumRows = items[0].NumberOfRows.ToString();

                    //int _ItemsPerRow = items.Count / Int32.Parse(_NumRows.ToString());

                    //lblTotalNiches.Text = "TOTAL NICHES THIS SECTION: " + items.Count.ToString();
                    //lblNumberPerRow.Text = "NUMBER PER ROW: " + _ItemsPerRow.ToString();

                    //lblNumberPerRow.Visible = Convert.ToBoolean(Settings["ShowPriceOnCheckout"].ToString());

                    //DataList1.RepeatColumns = _ItemsPerRow;
                    //DataList1.DataSource = items;
                    //DataList1.DataBind();


                }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }


        public void GetListingImages(string mlsNumber)
        {
            foreach (string foundFile in Directory.GetFiles(_SourcePath.ToString(), mlsNumber + "*.jpg", System.IO.SearchOption.TopDirectoryOnly))
            {
                File.Copy(foundFile, _TargetPath.ToString() + Path.GetFileName(foundFile),true);
                LabelShowStatus.Text = "Last File copied: " + foundFile + "<br />";
            }


        }

        public static string[] FindAllFiles(string rootDir)
        {
            var pathsToSearch = new Queue<string>();
            var foundFiles = new List<string>();

            pathsToSearch.Enqueue(rootDir);

            while (pathsToSearch.Count > 0)
            {
                var dir = pathsToSearch.Dequeue();

                try
                {
                    var files = Directory.GetFiles(dir);
                    foreach (var file in Directory.GetFiles(dir))
                    {
                        foundFiles.Add(file);
                    }

                    foreach (var subDir in Directory.GetDirectories(dir))
                    {
                        pathsToSearch.Enqueue(subDir);
                    }

                }
                catch (Exception /* TODO: catch correct exception */)
                {
                    // Swallow.  Gulp!
                }
            }

            return foundFiles.ToArray();
        }

        public List<string> LoadPathToAllFiles(string pathToFolder, int numberOfFilesToReturn)
        {

            try
            {
                var dirInfo = new DirectoryInfo(pathToFolder);
                var firstFiles = dirInfo.EnumerateFiles().Take(numberOfFilesToReturn).ToList();
                return firstFiles.Select(l => l.FullName).ToList();
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
                return new List<string>();
            }
        }


        public ModuleActionCollection ModuleActions
        {
            get
            {
                var actions = new ModuleActionCollection
                    {
                        {
                            GetNextActionID(), Localization.GetString("EditModule", LocalResourceFile), "", "", "",
                            EditUrl(), false, SecurityAccessLevel.Edit, true, false
                        }
                    };
                return actions;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            RunJob();
        }
    }
}