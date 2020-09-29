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

using DotNetNuke.Entities.Modules;

namespace GIBS.Modules.GIBSMLSImageCleaner
{
    public class GIBSMLSImageCleanerModuleSettingsBase : ModuleSettingsBase
    {

        public string SourcePath
        {
            get
            {
                if (Settings.Contains("SourcePath"))
                    return Settings["SourcePath"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "SourcePath", value.ToString());
            }
        }

        public string TargetPath
        {
            get
            {
                if (Settings.Contains("TargetPath"))
                    return Settings["TargetPath"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateModuleSetting(ModuleId, "TargetPath", value.ToString());
            }
        }



    }
}