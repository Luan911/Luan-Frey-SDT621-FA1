namespace DigitalIdentityProcessor
{
    public partial class Form1 : Form
    {
        private const string LogoFileName = "logo.png";
        private CitizenProfile? currentProfile;
        private string lastValidationResult = "ID not validated yet.";

        public Form1()
        {
            InitializeComponent();
            cmbCitizenship.Items.AddRange(new object[] { "Citizen", "Permanent Resident", "Visitor" });
            cmbCitizenship.SelectedIndex = 0;
            LoadLogoImage();
        }

        private void LoadLogoImage()
        {
            string logoPath = Path.Combine(AppContext.BaseDirectory, LogoFileName);
            if (!File.Exists(logoPath))
            {
                LoadLogoImageFallback();
                return;
            }

            byte[] imageBytes = File.ReadAllBytes(logoPath);
            using MemoryStream stream = new MemoryStream(imageBytes);
            using Image image = Image.FromStream(stream);
            pictureBoxLogo.Image = new Bitmap(image);
        }

        private static string? FindLogoPath()
        {
            string baseDir = AppContext.BaseDirectory;
            string[] fileNames =
            {
                LogoFileName,
                "SA_Symbol-Photoroom-44d0c4f3-330b-435a-b85f-df2f5678e2dc.png"
            };

            string[] candidateFolders =
            {
                baseDir,
                Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..")),
                Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..", "..")),
                Environment.CurrentDirectory
            };

            foreach (string folder in candidateFolders.Distinct(StringComparer.OrdinalIgnoreCase))
            {
                foreach (string fileName in fileNames)
                {
                    string candidatePath = Path.Combine(folder, fileName);
                    if (File.Exists(candidatePath))
                    {
                        return candidatePath;
                    }
                }
            }

            return null;
        }
        
        private void LoadLogoImageFallback()
        {
            string? logoPath = FindLogoPath();
            if (logoPath is null)
            {
                return;
            }

            using FileStream stream = new FileStream(logoPath, FileMode.Open, FileAccess.Read);
            using Image image = Image.FromStream(stream);
            pictureBoxLogo.Image = new Bitmap(image);
        }

        private void btnValidateId_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string idNumber = txtIdNumber.Text.Trim();
            string citizenship = cmbCitizenship.SelectedItem?.ToString() ?? "Citizen";

            if (string.IsNullOrWhiteSpace(fullName))
            {
                lblValidationResult.Text = "Please enter a full name.";
                return;
            }

            currentProfile = new CitizenProfile(fullName, idNumber, citizenship);
            lastValidationResult = currentProfile.ValidateID();
            lblValidationResult.Text = lastValidationResult;
        }

        private void btnGenerateProfile_Click(object sender, EventArgs e)
        {
            if (currentProfile is null)
            {
                btnValidateId_Click(sender, e);
                if (currentProfile is null)
                {
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(lastValidationResult) || lastValidationResult == "ID not validated yet.")
            {
                lastValidationResult = currentProfile.ValidateID();
            }

            txtSummary.Text =
                "==== DIGITAL CITIZEN SUMMARY ====\r\n" +
                $"Name: {currentProfile.FullName}\r\n" +
                $"ID Number: {currentProfile.IDNumber}\r\n" +
                $"Age: {currentProfile.Age}\r\n" +
                $"Citizenship: {currentProfile.CitizenshipStatus}\r\n" +
                $"Validation: {lastValidationResult}\r\n" +
                "Processed at: Home Affairs Digital Desk\r\n" +
                $"Timestamp: {DateTime.Now:yyyy/MM/dd HH:mm}";
        }
    }
}
