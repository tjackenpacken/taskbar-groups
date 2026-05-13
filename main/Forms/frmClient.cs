using client.Classes;
using client.User_controls;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Data.Json;
using System.Net.Http;

namespace client.Forms
{
    public partial class frmClient : Form
    {
        private static readonly HttpClient client = new HttpClient();
        // ADDED: Link label used to credit the original Taskbar Groups author.
        private LinkLabel originalAuthorLink;

        // ADDED: Link Label used only when a newer GitHub release is available.
        private LinkLabel githubVersionUpdateLink;

        public frmClient()
        {
            System.Runtime.ProfileOptimization.StartProfile("frmClient.Profile");
            InitializeComponent();

            // ADDED: Lock main window size to prevent non-responsive layout issues.
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // ADDED: Add original author credit/link above the issues/bugs section.
            AddOriginalAuthorLink();

            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            Reload();

            // CHANGED: Store current/local version and latest GitHub version so display can be normalized.
            string currentAssemblyVersion = System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();
            string latestGitHubVersion = Task.Run(() => getVersionData()).Result;

            // ADDED: Normalize display text and show Latest Version as a link only when an update is available.
            UpdateVersionDisplay(currentAssemblyVersion, latestGitHubVersion);

        }

        // ADDED: Adds an original author credit link above the existing "Have Issues or bugs?" section.
        private void AddOriginalAuthorLink()
        {
            const int addedHeight = 28;

            // ADDED: Keep the bottom of pnlVersionInfo anchored in the same place
            // while making room above the existing contents.
            pnlVersionInfo.Top -= addedHeight;
            pnlVersionInfo.Height += addedHeight;

            // ADDED: Move existing controls down to make room for the original author link.
            foreach (Control control in pnlVersionInfo.Controls)
            {
                control.Top += addedHeight;
            }

            originalAuthorLink = new LinkLabel();

            originalAuthorLink.Text = "Original Author: tjackenpacken";
            originalAuthorLink.AutoSize = false;
            originalAuthorLink.Width = 243;
            originalAuthorLink.Height = 22;
            originalAuthorLink.Left = label4.Left;
            originalAuthorLink.Top = 1;
            originalAuthorLink.TextAlign = ContentAlignment.MiddleCenter;
            originalAuthorLink.LinkArea = new LinkArea(0, originalAuthorLink.Text.Length);

            originalAuthorLink.Font = new Font("Segoe UI", 9.75F);
            originalAuthorLink.LinkColor = Color.White;
            originalAuthorLink.ActiveLinkColor = Color.FromArgb(120, 170, 255);
            originalAuthorLink.VisitedLinkColor = Color.White;
            originalAuthorLink.BackColor = Color.Transparent;
            originalAuthorLink.Cursor = Cursors.Hand;

            originalAuthorLink.LinkClicked += originalAuthorLink_LinkClicked;

            // ADDED: Add to pnlVersionInfo, which is the actual container for the GitHub/issues section.
            pnlVersionInfo.Controls.Add(originalAuthorLink);
            originalAuthorLink.BringToFront();
        }

        public void Reload()
        {
            // flush and reload existing groups
            pnlExistingGroups.Controls.Clear();
            pnlExistingGroups.Height = 0;

            string configPath = @MainPath.path + @"\config";
            string[] subDirectories = Directory.GetDirectories(configPath);
            foreach (string dir in subDirectories)
            {
                try
                {
                    LoadCategory(dir);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (pnlExistingGroups.HasChildren) // helper if no group is created
            {
                lblHelpTitle.Text = "Click on a group to add a taskbar shortcut";
                pnlHelp.Visible = true;
            }
            else // helper if groups are created
            {
                lblHelpTitle.Text = "Press on \"Add Taskbar group\" to get started";
                pnlHelp.Visible = false;
            }
            pnlBottomMain.Top = pnlExistingGroups.Bottom + 20; // spacing between existing groups and add new group btn

            Reset();
        }

        public void LoadCategory(string dir)
        {
            Category category = new Category(dir);
            ucCategoryPanel newCategory = new ucCategoryPanel(this, category);
            pnlExistingGroups.Height += newCategory.Height;
            pnlExistingGroups.Controls.Add(newCategory);
            newCategory.Top = pnlExistingGroups.Height - newCategory.Height;
            newCategory.Show();
            newCategory.BringToFront();
            newCategory.MouseEnter += new System.EventHandler((sender, e) => EnterControl(sender, e, newCategory));
            newCategory.MouseLeave += new System.EventHandler((sender, e) => LeaveControl(sender, e, newCategory));
        }

        public void Reset()
        {
            if (pnlBottomMain.Bottom > this.Bottom)
                pnlLeftColumn.Height = pnlBottomMain.Bottom;
            else
                pnlLeftColumn.Height = this.RectangleToScreen(this.ClientRectangle).Height; // making left column pnl dynamic
        }

        private void cmdAddGroup_Click(object sender, EventArgs e)
        {
            // CHANGED: Open the New Group form as a modal dialog.
            // This prevents multiple hidden New Group windows from being created.
            using (frmGroup newGroup = new frmGroup(this))
            {
                newGroup.ShowDialog(this);
            }
        }

        private void pnlAddGroup_MouseLeave(object sender, EventArgs e)
        {
            pnlAddGroup.BackColor = Color.FromArgb(3, 3, 3);
        }

        private void pnlAddGroup_MouseEnter(object sender, EventArgs e)
        {
            pnlAddGroup.BackColor = Color.FromArgb(31, 31, 31);
        }

        public void EnterControl(object sender, EventArgs e, Control control)
        {
            control.BackColor = Color.FromArgb(31, 31, 31);
        }
        public void LeaveControl(object sender, EventArgs e, Control control)
        {
            control.BackColor = Color.FromArgb(3, 3, 3);
        }

        private static async Task<String> getVersionData()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "taskbar-groups");

                // CHANGED: Point to hummbugg fork instead of original repo
                var res = await client.GetAsync("https://api.github.com/repos/hummbugg/taskbar-groups/releases");
                res.EnsureSuccessStatusCode();

                string responseBody = await res.Content.ReadAsStringAsync();

                JsonArray responseJSON = JsonArray.Parse(responseBody);

                // ADDED: Safely find the latest non-prerelease version
                foreach (var item in responseJSON)
                {
                    JsonObject jsonObjectData = item.GetObject();

                    // Skip prereleases if present
                    if (!jsonObjectData.GetNamedBoolean("prerelease", false))
                    {
                        return jsonObjectData["tag_name"].GetString();
                    }
                }

                // ADDED: Fallback if all releases are prerelease (unlikely)
                if (responseJSON.Count > 0)
                {
                    return responseJSON[0].GetObject()["tag_name"].GetString();
                }

                return "Not found";
            }
            catch
            {
                return "Not found";
            }
        }

        // ADDED: Updates Current Version and Latest Version display.
        // Latest Version becomes a clickable link only when GitHub has a newer version.
        private void UpdateVersionDisplay(string currentAssemblyVersion, string latestGitHubVersion)
        {
            Version currentNumericVersion = ParseNumericVersion(currentAssemblyVersion);
            Version latestNumericVersion = ParseNumericVersion(latestGitHubVersion);

            bool latestVersionFound = latestNumericVersion > new Version(0, 0, 0, 0);
            string latestSuffix = latestVersionFound ? GetVersionSuffix(latestGitHubVersion) : "";

            // ADDED: Display current version using GitHub's suffix for visual consistency.
            currentVersion.Text = BuildDisplayVersion(currentNumericVersion, latestSuffix);

            if (latestVersionFound && currentNumericVersion < latestNumericVersion)
            {
                // ADDED: Newer GitHub version exists, so show Latest Version as a hyperlink.
                ShowLatestVersionAsLink(latestGitHubVersion);
            }
            else
            {
                // ADDED: No update available, so show Latest Version as plain text.
                ShowLatestVersionAsPlainText(latestGitHubVersion);
            }
        }

        // ADDED: Extracts numeric version from values like "1.1.0.0", "v1.1.0-unofficial", or "v1.1.0".
        private Version ParseNumericVersion(string versionText)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(versionText))
                    return new Version(0, 0, 0, 0);

                string cleaned = versionText.Trim();

                if (cleaned.StartsWith("v", StringComparison.OrdinalIgnoreCase))
                    cleaned = cleaned.Substring(1);

                int endIndex = 0;

                while (endIndex < cleaned.Length &&
                       (char.IsDigit(cleaned[endIndex]) || cleaned[endIndex] == '.'))
                {
                    endIndex++;
                }

                if (endIndex == 0)
                    return new Version(0, 0, 0, 0);

                string numericPart = cleaned.Substring(0, endIndex).TrimEnd('.');

                return new Version(numericPart);
            }
            catch
            {
                return new Version(0, 0, 0, 0);
            }
        }

        // ADDED: Gets suffix from GitHub tag, such as "-unofficial" or "-official".
        private string GetVersionSuffix(string latestGitHubVersion)
        {
            if (string.IsNullOrWhiteSpace(latestGitHubVersion))
                return "";

            string cleaned = latestGitHubVersion.Trim();

            if (cleaned.StartsWith("v", StringComparison.OrdinalIgnoreCase))
                cleaned = cleaned.Substring(1);

            int endIndex = 0;

            while (endIndex < cleaned.Length &&
                   (char.IsDigit(cleaned[endIndex]) || cleaned[endIndex] == '.'))
            {
                endIndex++;
            }

            if (endIndex >= cleaned.Length)
                return "";

            return cleaned.Substring(endIndex);
        }

        // ADDED: Builds display version like "v1.1.0-unofficial" from EXE version plus GitHub suffix.
        private string BuildDisplayVersion(Version version, string suffix)
        {
            if (version == null)
                return "v0.0.0";

            string numericVersion;

            if (version.Build >= 0)
                numericVersion = $"{version.Major}.{version.Minor}.{version.Build}";
            else
                numericVersion = $"{version.Major}.{version.Minor}";

            return "v" + numericVersion + suffix;
        }

        // ADDED: Shows Latest Version as plain non-clickable text.
        private void ShowLatestVersionAsPlainText(string latestGitHubVersion)
        {
            if (githubVersionUpdateLink != null)
                githubVersionUpdateLink.Visible = false;

            githubVersion.Visible = true;
            githubVersion.Text = latestGitHubVersion;
        }

        // ADDED: Shows Latest Version as a clickable hyperlink when an update is available.
        private void ShowLatestVersionAsLink(string latestGitHubVersion)
        {
            githubVersion.Visible = false;

            if (githubVersionUpdateLink == null)
            {
                githubVersionUpdateLink = new LinkLabel();

                githubVersionUpdateLink.AutoSize = true;
                githubVersionUpdateLink.Font = githubVersion.Font;
                githubVersionUpdateLink.BackColor = Color.Transparent;
                githubVersionUpdateLink.LinkColor = Color.White;
                githubVersionUpdateLink.ActiveLinkColor = Color.FromArgb(120, 170, 255);
                githubVersionUpdateLink.VisitedLinkColor = Color.White;
                githubVersionUpdateLink.Location = githubVersion.Location;
                githubVersionUpdateLink.LinkClicked += githubVersionUpdateLink_LinkClicked;

                pnlVersionInfo.Controls.Add(githubVersionUpdateLink);
                githubVersionUpdateLink.BringToFront();
            }

            githubVersionUpdateLink.Text = latestGitHubVersion;
            githubVersionUpdateLink.Visible = true;
        }

        // ADDED: Opens hummbugg release page when Latest Version indicates an update is available.
        private void githubVersionUpdateLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/hummbugg/taskbar-groups/releases");
        }

        // ADDED: Opens the original Taskbar Groups project page for attribution/reference.
        private void originalAuthorLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/tjackenpacken/taskbar-groups");
        }

        private void githubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // CHANGED: Point to hummbugg releases page
            System.Diagnostics.Process.Start("https://github.com/hummbugg/taskbar-groups/releases");
        }

        private void frmClient_Resize(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
