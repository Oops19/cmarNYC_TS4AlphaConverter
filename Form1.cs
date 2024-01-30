using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime;
using s4pi.Package;
using s4pi.ImageResource;
using s4pi.Interfaces;
using Ookii.Dialogs;

namespace TS4AlphaConverter
{
    public partial class Form1 : Form
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        static string PackageFilter = "Package files (*.package)|*.package|All files (*.*)|*.*";
        //  static string PNGFilter = "PNG files (*.png)|*.png|All files (*.*)|*.*";

        public Form1()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "Ready";
            toolStripStatusLabel2.Text = "";
            toolStripStatusLabel3.Text = "";
        }

        internal string GetFilename(string title, string filter)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = filter;
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.Title = title;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog1.FileName;
            }
            else
            {
                return "";
            }
        }

        internal Package OpenPackage(string packagePath, bool readwrite)
        {
            try
            {
                Package package = (Package)Package.OpenPackage(0, packagePath, readwrite);
                return package;
            }
            catch
            {
                MessageBox.Show("Unable to read valid package data from " + packagePath);
                return null;
            }
        }

        internal string GetSaveFilename(string title, string filter, string defaultFilename)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = PackageFilter;
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.Title = title;
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "package";
            saveFileDialog1.OverwritePrompt = true;
            if (String.CompareOrdinal(defaultFilename, " ") > 0) saveFileDialog1.FileName = defaultFilename;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog1.FileName;
            }
            else
            {
                return "";
            }
        }

        internal bool WritePackage(string filename, Package pack)
        {
            try
            {
                pack.SaveAs(filename);
                pack.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not write file " + filename + ". Original error: " + ex.Message + Environment.NewLine + ex.StackTrace.ToString());
                return false;
            }
        }

        private void PackageSelect_button_Click(object sender, EventArgs e)
        {
            string packpath = GetFilename("Select package to convert", PackageFilter);
            Package pack = null;
            pack = OpenPackage(packpath, false);
            if (pack == null) return;

            toolStripStatusLabel1.Text = "";
            DateTime time = DateTime.Now;
            bool wasFixed = ProcessPackage(pack, Path.GetFileName(packpath));
            TimeSpan elapsed = DateTime.Now - time;
            if (!wasFixed)
            {
                MessageBox.Show("No changes were made!");
                pack.Dispose();
                toolStripStatusLabel1.Text = "Ready";
                toolStripStatusLabel2.Text = "";
                toolStripStatusLabel3.Text = "";
                return;
            }

            string newpackname = Path.GetFileNameWithoutExtension(packpath) + (NoRename_checkBox.Checked ? "" : "_Fixed"); ;
            string filename = GetSaveFilename("Save converted package", PackageFilter, newpackname);
            if (string.Compare(filename, " ") <= 0)
            {
                pack.Dispose();
                toolStripStatusLabel1.Text = "Ready";
                toolStripStatusLabel2.Text = "";
                toolStripStatusLabel3.Text = "";
                return;
            }

            toolStripStatusLabel1.Text = "Saving";
            toolStripStatusLabel2.Text = "";
            toolStripStatusLabel3.Text = "";
            statusStrip1.Refresh();
            while (!WritePackage(filename, pack))
            {
                DialogResult res = MessageBox.Show("Try again?", "Could not save package", MessageBoxButtons.RetryCancel);
                if (res == DialogResult.Cancel)
                {
                    break;
                }
            }
            toolStripStatusLabel1.Text = "Processing time: " + elapsed.Hours.ToString() + ":" + elapsed.Minutes.ToString("d2") + ":" + elapsed.Seconds.ToString("d2");
            toolStripStatusLabel2.Text = "Ready";
        }

        private bool ProcessPackage(Package pack, string packname)
        {
            Predicate<IResourceIndexEntry> predLRLE = r => r.ResourceType == (uint)ResourceTypes.LRLE;
            List<IResourceIndexEntry> iriesl = pack.FindAll(predLRLE);
            Predicate<IResourceIndexEntry> predRLE2 = r => r.ResourceType == (uint)ResourceTypes.RLE2;
            List<IResourceIndexEntry> iries2 = pack.FindAll(predRLE2);
            Predicate<IResourceIndexEntry> predCASP = r => r.ResourceType == (uint)ResourceTypes.CASP;
            List<IResourceIndexEntry> iriesc = pack.FindAll(predCASP);
            int tot = iriesl.Count;
            bool wasFixed = false;

            List<ulong> linked = new List<ulong>();
            foreach (IResourceIndexEntry irie in iriesc)
            {
                using (Stream s = pack.GetResource(irie))
                {
                    try
                    {
                        CASP casp = new CASP(new BinaryReader(s));
                        bool updateCASP = ConvertAll_radioButton.Checked;
                        if (!linked.Contains(casp.LinkList[casp.TextureIndex].Instance))
                        {
                            if (DoAll_checkBox.Checked)
                            {
                                linked.Add(casp.LinkList[casp.TextureIndex].Instance);
                                updateCASP = true;
                            }
                            else if (DoHair_checkBox.Checked)
                            {
                                if (casp.PartType == CASP.BodyType.Hair || casp.PartType == CASP.BodyType.FacialHair)
                                {
                                    linked.Add(casp.LinkList[casp.TextureIndex].Instance);
                                    updateCASP = true;
                                }
                            }
                            else if (DoSkinDetails_checkBox.Checked)
                            {
                                if (casp.PartType == CASP.BodyType.DimpleLeft || casp.PartType == CASP.BodyType.DimpleRight ||
                                    casp.PartType == CASP.BodyType.ForeheadCrease || casp.PartType == CASP.BodyType.Freckles ||
                                    casp.PartType == CASP.BodyType.MoleLeftCheek || casp.PartType == CASP.BodyType.MoleLeftLip ||
                                    casp.PartType == CASP.BodyType.MoleRightCheek || casp.PartType == CASP.BodyType.MoleRightLip ||
                                    casp.PartType == CASP.BodyType.MouthCrease || casp.PartType == CASP.BodyType.SkinDetailAcne ||
                                    casp.PartType == CASP.BodyType.SkinDetailScar || casp.PartType == CASP.BodyType.SkinOverlay)
                                {
                                    linked.Add(casp.LinkList[casp.TextureIndex].Instance);
                                    updateCASP = true;
                                }
                            }
                            else if (DoMakeup_checkBox.Checked)
                            {
                                if (casp.PartType == CASP.BodyType.Blush || casp.PartType == CASP.BodyType.Eyeliner ||
                                    casp.PartType == CASP.BodyType.Eyeshadow || casp.PartType == CASP.BodyType.Facepaint ||
                                    casp.PartType == CASP.BodyType.Lipstick || casp.PartType == CASP.BodyType.Mascara)
                                {
                                    linked.Add(casp.LinkList[casp.TextureIndex].Instance);
                                    updateCASP = true;
                                }
                            }
                        }
                        if (ConvertLRLE_radioButton.Checked && updateCASP && casp.LinkList[casp.TextureIndex].Type == (uint)ResourceTypes.LRLE)
                        {
                            TGI link = casp.LinkList[casp.TextureIndex];
                            casp.setLink(casp.TextureIndex, new TGI((uint)ResourceTypes.RLE2, link.Group, link.Instance));
                            Stream sc = new MemoryStream();
                            casp.Write(new BinaryWriter(sc));
                            sc.Position = 0;
                            pack.ReplaceResource(irie, new Resource(1, sc));
                            wasFixed = true;
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

            int current = 1;
            // int savecount = 0;
            toolStripStatusLabel2.Text = packname + ": ";

            foreach (IResourceIndexEntry irie in iriesl)
            {
                if (LinkedOnly_radioButton.Checked && !linked.Contains(irie.Instance)) continue;
                if (ConvertRLE2_radioButton.Checked) continue;

                SetThreadExecutionState(EXECUTION_STATE.ES_SYSTEM_REQUIRED);
                //   GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
                //   GC.Collect(2, GCCollectionMode.Forced, true, true);

                toolStripStatusLabel3.Text = "LRLE Texture " + current.ToString() + " of " + tot.ToString();
                statusStrip1.Refresh();
                current++;

                Predicate<IResourceIndexEntry> pred = r => r.ResourceType == irie.ResourceType & r.ResourceGroup == irie.ResourceGroup & r.Instance == irie.Instance;
                IResourceIndexEntry ie = pack.Find(pred);
                using (Stream s = pack.GetResource(ie))
                {
                    if (s.Length < 16) continue;
                    Bitmap image;
                    try
                    {
                        LRLE lrle = new LRLE(new BinaryReader(s));
                        image = lrle.image;
                        lrle = null;
                    }
                    catch
                    {
                        continue;
                    }
                    if (image == null) continue;

                    if (UpdateLRLE_radioButton.Checked)
                    {
                        LRLE lrle = new LRLE(image);
                        pack.ReplaceResource(irie, new Resource(1, lrle.Stream));
                        wasFixed = true;
                    }
                    else if (ConvertLRLE_radioButton.Checked)
                    {
                        DdsFile dds = new DdsFile();
                        dds.CreateImage(image, false);
                        dds.GenerateMipMaps();
                        Stream s1 = new MemoryStream();
                        dds.Save(s1);
                        s1.Position = 0;
                        RLEResource rle2 = new RLEResource(1, null);
                        rle2.ImportToRLE(s1);
                        TGIBlock tmp = new TGIBlock(1, null, (uint)ResourceTypes.RLE2, irie.ResourceGroup, irie.Instance);
                        pack.AddResource(tmp, rle2.Stream, true);
                        pack.DeleteResource(irie);
                        wasFixed = true;
                    }
                    if (image != null) image.Dispose();
                }
            }

            foreach (IResourceIndexEntry irie in iries2)
            {
                if (LinkedOnly_radioButton.Checked && !linked.Contains(irie.Instance)) continue;

                SetThreadExecutionState(EXECUTION_STATE.ES_SYSTEM_REQUIRED);
                //   GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
                //   GC.Collect(2, GCCollectionMode.Forced, true, true);

                Predicate<IResourceIndexEntry> pred = r => r.ResourceType == irie.ResourceType & r.ResourceGroup == irie.ResourceGroup & r.Instance == irie.Instance;
                IResourceIndexEntry ie = pack.Find(pred);
                Bitmap image;
                using (Stream s = pack.GetResource(ie))
                {
                    if (s.Length < 16) continue;
                    if (ConvertRLE2_radioButton.Checked)
                    {
                        try
                        {
                            RLEResource rle2 = new RLEResource(1, s);
                            DdsFile dds = new DdsFile();
                            dds.Load(rle2.ToDDS(), false);
                            image = dds.Image;
                            toolStripStatusLabel3.Text = "RLE2 texture " + current.ToString();
                            statusStrip1.Refresh();
                            current++;
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    else
                    {
                        try
                        {
                            LRLE lrle = new LRLE(new BinaryReader(s));
                            image = lrle.image;
                            lrle = null;
                            toolStripStatusLabel3.Text = "Additional LRLE Texture labeled as RLE2 " + current.ToString();
                            statusStrip1.Refresh();
                            current++;
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    if (image == null) continue;

                    if (ConvertRLE2_radioButton.Checked || UpdateLRLE_radioButton.Checked)
                    {
                        LRLE lrle = new LRLE(image);
                        TGIBlock tmp = new TGIBlock(1, null, (uint)ResourceTypes.LRLE, irie.ResourceGroup, irie.Instance);
                        pack.AddResource(tmp, lrle.Stream, true);
                        pack.DeleteResource(irie);
                        wasFixed = true;
                    }
                    else if (ConvertLRLE_radioButton.Checked)
                    {
                        DdsFile dds = new DdsFile();
                        dds.CreateImage(image, false);
                        dds.GenerateMipMaps();
                        Stream s1 = new MemoryStream();
                        dds.Save(s1);
                        s1.Position = 0;
                        RLEResource rle2 = new RLEResource(1, null);
                        rle2.ImportToRLE(s1);
                        pack.ReplaceResource(irie, new Resource(1, rle2.Stream));
                        wasFixed = true;
                    }
                    if (image != null) image.Dispose();
                }
            }
            return wasFixed;
        }

        private void FolderSelect_button_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog folder = new VistaFolderBrowserDialog();
            folder.ShowNewFolderButton = false;
            folder.Description = "Select folder containing packages to be converted";
            folder.UseDescriptionForTitle = true;
            folder.ShowDialog();
            FolderName.Text = folder.SelectedPath;
        }

        private void OutputSelect_button_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog folder = new VistaFolderBrowserDialog();
            folder.ShowNewFolderButton = true;
            folder.Description = "Select folder for converted packages";
            folder.UseDescriptionForTitle = true;
            folder.ShowDialog();
            OutputName.Text = folder.SelectedPath;
        }

        private void FolderGo_button_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(FolderName.Text) || !Directory.Exists(OutputName.Text))
            {
                MessageBox.Show("You have not selected valid input and output folders!");
                return;
            }
            if (String.Compare(FolderName.Text, OutputName.Text) == 0 && NoRename_checkBox.Checked)
            {
                MessageBox.Show("You must have different input and output folders if packages are not renamed!");
                return;
            }
            string[] paths = Directory.GetFiles(FolderName.Text, "*.package", Subfolders_checkBox.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            Array.Sort(paths);
            int counter = 0;
            DialogResult res = DialogResult.Retry;
            bool applyAll = false;
            string errorPacks = "";
            int numFixed = 0, numNotFixed = 0;
            DateTime time = DateTime.Now;
            foreach (string packpath in paths)
            {
                counter++;
                toolStripStatusLabel1.Text = "Package " + counter.ToString() + " of " + paths.Length.ToString() + " : ";
                statusStrip1.Refresh();
                Package pack = null;
                pack = OpenPackage(packpath, false);
                if (pack == null) continue;
                bool wasFixed;
                try
                {
                    wasFixed = ProcessPackage(pack, Path.GetFileName(packpath));
                    if (wasFixed) numFixed++;
                    if (!wasFixed) numNotFixed++;
                }
                catch (Exception ep)
                {
                    errorPacks += packpath + " (" + ep.Message + ")" + Environment.NewLine;
                    wasFixed = false;
                }

                Application.DoEvents();

                if (!wasFixed && NoCopy_checkBox.Checked) continue;
                string newpath = packpath.Replace(FolderName.Text, OutputName.Text);
                string newdir = Path.GetDirectoryName(newpath);
                string status = wasFixed ? "_Fixed" : "_NotFixed";
                if (!Directory.Exists(newdir)) Directory.CreateDirectory(newdir);
                string newpackname = newdir + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(packpath) +
                    (NoRename_checkBox.Checked ? ".package" : status + ".package");
                if (File.Exists(newpackname))
                {
                    if (!applyAll)
                    {
                        using (DupFileDialog dup = new DupFileDialog("A package already exists with the name: " + Environment.NewLine + newpackname))
                        {
                            res = dup.ShowDialog();
                            applyAll = dup.ApplyToAll;
                        }
                    }
                    if (res == DialogResult.OK)
                    {
                        // go on to save package
                    }
                    else if (res == DialogResult.Retry)         //get a non-duplicate file name
                    {
                        int append = 1;
                        newpackname = newdir + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(packpath) +
                                    (NoRename_checkBox.Checked ? "" : status) + append.ToString() + ".package";
                        while (File.Exists(newpackname))
                        {
                            append++;
                            newpackname = newdir + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(packpath) +
                                    (NoRename_checkBox.Checked ? "" : status) + append.ToString() + ".package";
                        }
                    }
                    else if (res == DialogResult.Ignore)        //discard new package
                    {
                        continue;
                    }
                    else if (res == DialogResult.Cancel)
                    {
                        toolStripStatusLabel1.Text = "Ready";
                        toolStripStatusLabel2.Text = "";
                        toolStripStatusLabel3.Text = "";
                        return;
                    }
                }

                toolStripStatusLabel3.Text = "Saving";
                pack.SaveAs(newpackname);
                pack.Dispose();
            }
            TimeSpan elapsed = DateTime.Now - time;

            if (errorPacks.Length > 0)
            {
                MessageBox.Show("The following package(s) were not successfully converted." + Environment.NewLine + Environment.NewLine +
                    errorPacks + Environment.NewLine + "Please convert them individually to get detailed error messages.");
            }
            if (numNotFixed > 0)
            {
                MessageBox.Show(numNotFixed.ToString() + " packages did not require changes.");
            }
            toolStripStatusLabel1.Text = "Processing time: " + elapsed.Hours.ToString() + ":" + elapsed.Minutes.ToString("d2") + ":" + elapsed.Seconds.ToString("d2");
            toolStripStatusLabel2.Text = "Ready";
            toolStripStatusLabel3.Text = "";
        }

        internal class Resource : AResource
        {
            internal Resource(int APIversion, Stream s) : base(APIversion, s) { }

            public override int RecommendedApiVersion
            {
                get { return 1; }
            }

            protected override Stream UnParse()
            {
                return this.stream;
            }
        }

        public enum ResourceTypes : uint
        {
            LRLE = 0x2BC04EDFU,
            RLE2 = 0x3453CF95U,
            RLES = 0xBA856C78,
            DDS = 0x00B2D882,
            SKIN = 0xB6C8B6A0,
            CASP = 0x034AEECB
        }

        public enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_SYSTEM_REQUIRED = 0x00000001
        }

        private void ConvertAll_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            LinkedOptions_panel.Enabled = LinkedOnly_radioButton.Checked;
        }

        private void DoOnlyHairSkin_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DoAll_checkBox.Checked)
            {
                if (DoHair_checkBox.Checked) DoHair_checkBox.Checked = false;
                if (DoSkinDetails_checkBox.Checked) DoSkinDetails_checkBox.Checked = false;
                if (DoMakeup_checkBox.Checked) DoMakeup_checkBox.Checked = false;
            }
        }

        private void DoOnlyHair_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DoHair_checkBox.Checked)
            {
                if (DoAll_checkBox.Checked) DoAll_checkBox.Checked = false;
                if (DoSkinDetails_checkBox.Checked) DoSkinDetails_checkBox.Checked = false;
                if (DoMakeup_checkBox.Checked) DoMakeup_checkBox.Checked = false;
            }
        }

        private void DoOnlySkinDetails_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DoSkinDetails_checkBox.Checked)
            {
                if (DoAll_checkBox.Checked) DoAll_checkBox.Checked = false;
                if (DoHair_checkBox.Checked) DoHair_checkBox.Checked = false;
                if (DoMakeup_checkBox.Checked) DoMakeup_checkBox.Checked = false;
            }
        }

        private void DoExceptMakeup_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DoMakeup_checkBox.Checked)
            {
                if (DoAll_checkBox.Checked) DoAll_checkBox.Checked = false;
                if (DoHair_checkBox.Checked) DoHair_checkBox.Checked = false;
                if (DoSkinDetails_checkBox.Checked) DoSkinDetails_checkBox.Checked = false;
            }
        }

        private void UpdateLRLE_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdateLRLE_radioButton.Checked)
            {
                ConvertAll_radioButton.Checked = true;
            }
            else
            {
                LinkedOnly_radioButton.Checked = true;
            }
        }
    }
}
