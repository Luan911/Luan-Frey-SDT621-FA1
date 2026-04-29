using System;
using System.Drawing;
using System.Windows.Forms;

namespace FavProgLang_Q3
{
    public partial class Form1 : Form
    {
        // UI Controls
        private TextBox? txtLanguage;
        private Button? btnAdd;
        private Button? btnRemove;
        private ListBox? lstLanguages;
        private Label? lblStatus;
        private Label? lblHeader;

        // Stores when each language was added (case-insensitive).
        private readonly System.Collections.Generic.Dictionary<string, DateTime> _addedAt =
            new System.Collections.Generic.Dictionary<string, DateTime>(StringComparer.OrdinalIgnoreCase);

        public Form1()
        {
            InitializeComponent();

            // Setup the Form Window
            this.Text = "Favorite Languages";
            this.Size = new Size(360, 480);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            SetupUI();
        }

        private void SetupUI()
        {
            // Header Label
            lblHeader = new Label();
            lblHeader.Text = "Favorite Languages";
            lblHeader.Font = new Font("Arial", 10, FontStyle.Bold);
            lblHeader.Location = new Point(25, 15);
            lblHeader.Size = new Size(200, 20);

            // TextBox for input
            txtLanguage = new TextBox();
            txtLanguage.Location = new Point(25, 40);
            txtLanguage.Size = new Size(280, 25);
            txtLanguage.Font = new Font("Segoe UI", 9);
            txtLanguage.PlaceholderText = "Programming Language...";

            // Add Button
            btnAdd = new Button();
            btnAdd.Text = "Add Language";
            btnAdd.Location = new Point(25, 75);
            btnAdd.Size = new Size(135, 35);
            btnAdd.BackColor = Color.LightGreen;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Click += new EventHandler(btnAdd_Click);

            // Remove Button
            btnRemove = new Button();
            btnRemove.Text = "Remove";
            btnRemove.Location = new Point(170, 75);
            btnRemove.Size = new Size(135, 35);
            btnRemove.BackColor = Color.LightCoral;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Click += new EventHandler(btnRemove_Click);

            // ListBox to display items
            lstLanguages = new ListBox();
            lstLanguages.Location = new Point(25, 125);
            lstLanguages.Size = new Size(280, 220);
            lstLanguages.Font = new Font("Segoe UI", 10);

            // Status Label for Timestamp
            lblStatus = new Label();
            lblStatus.Text = "Ready";
            lblStatus.Location = new Point(25, 360);
            lblStatus.Size = new Size(280, 70);
            lblStatus.ForeColor = Color.DimGray;
            lblStatus.TextAlign = ContentAlignment.TopLeft;

            // Add all controls to the form
            this.Controls.Add(lblHeader);
            this.Controls.Add(txtLanguage);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnRemove);
            this.Controls.Add(lstLanguages);
            this.Controls.Add(lblStatus);
        }

        // --- Logic Events ---

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            string entry = txtLanguage!.Text.Trim();

            if (string.IsNullOrWhiteSpace(entry))
            {
                MessageBox.Show("Please enter a programming language.", "Input Empty");
                return;
            }

            if (_addedAt.ContainsKey(entry))
            {
                MessageBox.Show("That language is already in the list!", "Duplicate");
            }
            else
            {
                lstLanguages!.Items.Add(entry);
                DateTime addedAt = DateTime.Now;
                _addedAt[entry] = addedAt;

                lblStatus!.Text = $"Successfully added: {entry}\nDate: {addedAt:dd MMM yyyy HH:mm:ss}";
                txtLanguage!.Clear();
                txtLanguage!.Focus();
            }
        }

        private void btnRemove_Click(object? sender, EventArgs e)
        {
            if (lstLanguages!.SelectedIndex != -1 && lstLanguages.SelectedItem is string item)
            {
                lstLanguages.Items.RemoveAt(lstLanguages.SelectedIndex);
                _addedAt.Remove(item);

                lblStatus!.Text = $"Removed: {item}\nAt: {DateTime.Now:HH:mm:ss}";
            }
            else
            {
                MessageBox.Show("Please select an item from the list to remove.", "Selection Required");
            }
        }
    }
}